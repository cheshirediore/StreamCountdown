using System.Security.AccessControl;
using Godot;

namespace Clock
{
public partial class LabelComponent : Label
{
	public float startTime = 3600f;
	public float currentTime;
	private bool running = true;
	private Utility.ClockFormat clockFormat;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Initialize the clock to the start time
		this.currentTime = startTime;

		// Select the format from the start time length
		switch (this.startTime)
		{
			// Over 24 hours
			case >= 86400:
				this.clockFormat = Utility.ClockFormat.DAYS;
				break;
			// Greater than 60 minutes
			case >= 3600:
				this.clockFormat = Utility.ClockFormat.HOURS;
				break;
			// Greater than 60 seconds
			case >= 60:
				this.clockFormat = Utility.ClockFormat.MINUTES;
				break;
			// Some positive amount of seconds
			case > 0:
				this.clockFormat = Utility.ClockFormat.SECONDS;
				break;
			// Starting time is negative or zero, so just output as is instead of trying to make sense of it
			default:
				GD.PushWarning("Non-Positive value given for time. Defaulting to raw output format.");
				this.clockFormat = Utility.ClockFormat.RAW;
				break;
		}

		// Update the label to reflect the start time
		UpdateUI();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateUI();
	}

	private void DecrementTimer()
	{
		this.currentTime--;
	}

	private void UpdateUI()
	{
		this.Text = Utility.ClockStringFromFloat(this.currentTime, this.clockFormat); // TODO: Fix UI to be wide enough for DAYS
	}

	public void _on_timer_timeout()
	{
		// If the clock is running, update the label
		// NOTE: This is independent of the timer component running. The timer component always runs as a heartbeat,
		//		 and this component just hooks in when it needs time info.
		if (this.running)
		{
			DecrementTimer();
		}
	}

	public void Start()
	{
	
	}

	public void DelayedStart(float delaySeconds)
	{
		
	}
}
}
