using Godot;
using System;

public partial class Global : Node
{
	public const float gravity = 10.0f;

	public override void _Ready()
	{
		GD.Print("in_global");
	}
}
