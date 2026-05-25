using UnityEngine;

public class ObjectToProtect : Entity
{

	private Transform player;	
	protected override void Awake()
	{
		base.Awake();
		player = FindFirstObjectByType<Player>().transform;
	}

	protected override void Update()
	{
		HandleFlip();
	}

	protected override void HandleFlip()
	{

		if (player == null)
			return;

		// Si el jugador está a la DERECHA y la niña mira a la izquierda -> Voltear
		if (player.transform.position.x > transform.position.x && facingRight == false)
			Flip();

		// Si el jugador está a la IZQUIERDA (<) y la niña mira a la derecha -> Voltear
		else if (player.transform.position.x < transform.position.x && facingRight == true)
			Flip();
	}


	protected override void Die()
	{
		base.Die();
		UI.instance.EnableGameOverUI();
	}
}