using Godot;

public partial class ClockLabel : Label
{
	public float startTime = 3600f;
	public float currentTime;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.currentTime = startTime;
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
		int hours = (int)(currentTime / 3600); // Floor division of the seconds divided by (seconds per hour)
		int minutes = (int)(currentTime / 60) % 60; // Floor division of the seconds divided by (seconds per minute) mod 60. 
													// The mod 60 keeps it from counting total minutes for multiple hours.
		int seconds = (int)(currentTime) % 60; // Seconds mod 60. Same reason as mod 60 on minutes.
		
		// lpad the time strings with 0s, and use the last two digits. This limits output hours to mod 100, but that's okay for the use case.
		string hourString 	= $"00{hours}".Substring($"0{hours}".Length - 1);
		string minuteString = $"00{minutes}".Substring($"0{minutes}".Length - 1);
		string secondString = $"00{seconds}".Substring($"0{seconds}".Length - 1);

		this.Text = $"{hourString}:{minuteString}:{secondString}";
	}

	public void _on_timer_timeout()
	{
		DecrementTimer();
	}
}
