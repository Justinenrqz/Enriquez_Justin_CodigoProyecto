using System;
using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{
	protected Animator anim;
	protected Rigidbody2D rb;
	protected Collider2D col;
	protected SpriteRenderer sr;

	[Header("Health")]
	[SerializeField] protected int maxHealth = 1; // Cambiado a protected para facilidad de lectura
	[SerializeField] protected int currentHealth;
	[SerializeField] private Material damageMaterial;
	[SerializeField] private float damageFeedbackDuration = .1f;
	private Coroutine damageFeedbackCoroutine;

	
	[Header("UI Component")]
	[SerializeField] private UI_HealthBar healthBar;

	[Header("Attack Details")]
	[SerializeField] protected float AttackRadius;
	[SerializeField] protected Transform AttackPoint;
	[SerializeField] protected LayerMask whatIsTarget;

	[Header("Collision Details")]
	[SerializeField] private float groundcheckDistace;
	[SerializeField] private LayerMask whatIsGround;
	protected bool isGrounded;

	protected int facingDir = 1;
	protected bool facingRight = true;
	protected bool canMove = true;

	protected virtual void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<Collider2D>();
		anim = GetComponentInChildren<Animator>();
		sr = GetComponentInChildren<SpriteRenderer>();

		currentHealth = maxHealth;
	}

	
	protected virtual void Start()
	{
		if (healthBar != null)
		{
			healthBar.UpdateHealthBar(currentHealth, maxHealth);
		}
	}

	protected virtual void Update()
	{
		HandleCollision();
		HandleMovement();
		HandleAnimations();
		HandleFlip();
	}

	public void DamageTargets()
	{
		Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRadius, whatIsTarget);

		foreach (Collider2D enemy in enemyColliders)
		{
			Entity entityTarget = enemy.GetComponent<Entity>();
			if (entityTarget != null)
			{
				entityTarget.TakeDamage();
			}
		}
	}

	// MODIFICADO: Cambiado de private a public para recibir daños externos correctamente
	public void TakeDamage()
	{
		currentHealth = currentHealth - 1;

		PlayDamageFeedback();

		if (healthBar != null)
		{
			healthBar.UpdateHealthBar(currentHealth, maxHealth);
		}

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	private void PlayDamageFeedback()
	{
		if (damageFeedbackCoroutine != null)
			StopCoroutine(damageFeedbackCoroutine);

		StartCoroutine(DamageFeedbackCo());
	}

	private IEnumerator DamageFeedbackCo()
	{
		Material originalMat = sr.material;
		sr.material = damageMaterial;

		yield return new WaitForSeconds(damageFeedbackDuration);
		sr.material = originalMat;
	}

	protected virtual void Die()
	{
		anim.enabled = false;
		col.enabled = false;

		rb.gravityScale = 12;
		rb.linearVelocity = new Vector2(rb.linearVelocity.x, 15);

		Destroy(gameObject, 3);
	}

	public virtual void EnableMovement(bool enable)
	{
		canMove = enable;
	}

	protected void HandleAnimations()
	{
		anim.SetBool("isGrounded", isGrounded);
		anim.SetFloat("xVelocity", rb.linearVelocity.x);
		anim.SetFloat("yVelocity", rb.linearVelocity.y);
	}

	protected virtual void HandleAttack()
	{
		if (isGrounded)
			anim.SetTrigger("attack");
	}

	protected virtual void HandleMovement()
	{
	}

	protected virtual void HandleCollision()
	{
		isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundcheckDistace, whatIsGround);
	}

	protected virtual void HandleFlip()
	{
		if (rb.linearVelocity.x > 0 && facingRight == false)
			Flip();
		else if (rb.linearVelocity.x < 0 && facingRight == true)
			Flip();
	}

	public void Flip()
	{
		transform.Rotate(0, 180, 0);
		facingRight = !facingRight;
		facingDir = facingDir * -1;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundcheckDistace));

		if (AttackPoint != null)
			Gizmos.DrawWireSphere(AttackPoint.position, AttackRadius);
	}


	
	public void IncreaseMaxHealth(int bonusHealth)
	{
		maxHealth += bonusHealth;
		currentHealth = maxHealth; // Esto inicializa la vida actual con el nuevo máximo

		if (healthBar != null)
		{
			healthBar.UpdateHealthBar(currentHealth, maxHealth);
		}
	}
}