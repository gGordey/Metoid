using Godot;
using System;

public partial class Player : Entity
{
	private RayCast2D DownCast;
	private RayCast2D LeftCast;
	private RayCast2D RightCast;

	public bool IsGrounded {get {return DownCast.IsColliding();}}
	public bool IsTouchingWall {get {return RightCast.IsColliding() || LeftCast.IsColliding();}}
	

	public override void InhReady()
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
		if (Input.IsActionPressed("moveLeft"))
		{
			CurrentDir = new Vector2 (-1,CurrentDir.Y);
		}
		else if (Input.IsActionPressed("moveRight"))
		{
			CurrentDir = new Vector2 (1,CurrentDir.Y);
		}
		else {CurrentDir = new Vector2();}
	}
}
