using Godot;

public partial class Clock : Timer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.WaitTime = 1.0f;
		this.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void TogglePause()
	{
		this.Paused = !this.Paused;
	}

}
