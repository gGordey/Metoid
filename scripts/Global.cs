using Godot;
using System;

public partial class Global : Node
{
	public override void _Ready()
	{
		GD.Print("in_global");
	}
}
