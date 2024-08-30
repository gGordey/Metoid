using System;
using Godot;

[GlobalClass]
public partial class Entity : CharacterBody2D
{
	[Export] public float weight = 3.0f;
	[Export] public float jumpHeight = 300;
	[Export] public float speed = 50;
	
	public Vector2 CurrentDir = new Vector2();
	private Global Global;

	public override void _Ready()
	{
		InhReady();
		Global = GetNode<Global>("/root/Global");
	}
	public virtual void InhReady() {}
	public override void _Process(double delta)
	{
		Gravitate();
		Move();
		InhProcess(delta);
		MoveAndSlide();
	}	

	public virtual void InhProcess(double delta) {}
	
	public void Move()
	{
		Velocity = new Vector2 (0, Velocity.Y);
		if (CurrentDir == new Vector2(0,0)) {return;}
		Velocity += new Vector2 (CurrentDir.X * speed, CurrentDir.Y * speed);
	}
	private void Gravitate()
	{
		Velocity += new Vector2 (0, weight*Global.gravity);
	}
	public void Jump()
	{
		Velocity = new Vector2 (Velocity.X, -jumpHeight);
	}
}
