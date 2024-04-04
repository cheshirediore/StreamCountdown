using Godot;
using System;

public partial class UIController : CenterContainer
{
	[ExportGroup("Visibility Parents")]
	[Export]
	Control configurationMenu;

	[Export]
	Control clockUI;


	[ExportGroup("Text Edit Fields")]
	[Export]
	TextEdit days;

	[Export]
	TextEdit hours;

	[Export]
	TextEdit minutes;

	[Export]
	TextEdit seconds;

	
	[ExportGroup("Sub-Controllers")]
	[Export]
	Clock.Clock clockController;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		clockUI.Visible = false;
		configurationMenu.Visible = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void _on_start_button_pressed()
	{
		int startTime = 0;
		if (days.Text.IsValidInt())
		{
			startTime += (int)days.Text.ToInt() * 84600;
		}
		if (hours.Text.IsValidInt())
		{
			startTime += (int)hours.Text.ToInt() * 3600;
		}
		if (minutes.Text.IsValidInt())
		{
			startTime += (int)minutes.Text.ToInt() * 60;
		}
		if (seconds.Text.IsValidInt())
		{
			startTime += (int)seconds.Text.ToInt();
		}

		clockController.StartCountdown(startTime);

		clockUI.Visible = true;
		configurationMenu.Visible = false;
	}

}
