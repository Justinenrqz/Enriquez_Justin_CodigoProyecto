using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Enemy : Entity
{

	private bool playerDetected;

	[Header("Movement Details")]
	[SerializeField] protected float moveSpeed = 3.5f;
	[SerializeField] private GameObject damageTextPrefab;



	protected override void Update()
	{
		base.Update();
		HandleAttack();
	}

	protected override void HandleAttack()
	{
		if(playerDetected) 
			anim.SetTrigger("attack");
	}

	protected override void HandleMovement()
	{
		if (canMove)
			rb.linearVelocity = new Vector2(facingDir * moveSpeed, rb.linearVelocity.y);
		else
			rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
	}

	protected override void HandleCollision()
	{
		base.HandleCollision();
		playerDetected = Physics2D.OverlapCircle(AttackPoint.position, AttackRadius, whatIsTarget);
	}

	protected override void Die()
	{
		base.Die();
		UI.instance.addKillCount();
	}
}
