using Godot;
using System;

public partial class Player : Entity
{
	private RayCast2D DownCast;
	private RayCast2D LeftCast;
	private RayCast2D RightCast;

	public bool IsGrounded {get {return DownCast.IsColliding();}}
	public bool IsTouchingWall {get {return RightCast.IsColliding() || LeftCast.IsColliding();}}
	

	public override void _Ready()
	{
		DownCast = GetNode<RayCast2D>("Down");
		LeftCast = GetNode<RayCast2D>("Left");
		RightCast = GetNode<RayCast2D>("Right");

	}
	public override void InhProcess(double delta)
	{
		if (Input.IsActionJustPressed("jump") && IsGrounded)
		{
			Jump();
		}
	}

}
