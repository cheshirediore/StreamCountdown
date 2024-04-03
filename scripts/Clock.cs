using Godot;
using System;

namespace Clock
{
public partial class Clock : Control
{
	[Export] 
	private LabelComponent label;

	[Export]
	private TimerComponent timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void StartCountdown(float time)
	{
		label.Start(time);
	}

}
}
