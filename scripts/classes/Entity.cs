using System;
using Godot;

public partial class Entity : CharacterBody2D
{
	[Export] private float weight = 0.0f;
	[Export] private float jumpHeight = 0.0f;
	[Export] private float speed = 0.0f;
	
	public Vector2 CurrentDir = new Vector2();
	

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Gravitate();
		Move();
		InhProcess(delta);
	}	

	public virtual void InhProcess(double delta) {}
	
	public void Move()
	{
		Velocity = new Vector2 (0, Velocity.Y);
		if (CurrentDir == new Vector2(0,0)) {return;}
		Velocity += new Vector2 (CurrentDir.X * speed, CurrentDir.Y * speed);
		MoveAndSlide();
	}
	private void Gravitate()
	{
		Velocity += new Vector2 (0, weight*Global.gravity);
	}
	public void Jump()
	{
		Velocity = new Vector2 (0, jumpHeight);
	}
}

