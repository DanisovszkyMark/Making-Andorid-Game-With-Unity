using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	[SerializeField]
	protected int health;

	[SerializeField]
	protected int speed;

	[SerializeField]
	protected int gems;

	[SerializeField]
	protected Transform wayPointA;

	[SerializeField]
	protected Transform wayPointB;

	// TODO: Create an interface: IMoveable
	protected Vector3 currentWayPoint;

	// 
	protected Animator enemyAnimator;

	// 
	protected SpriteRenderer enemySprite;

	public void Start()
	{
		Init();
	}

	public virtual void Update()
	{
		if (this.enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			return;
		}

		this.Movement();
	}

	public virtual void Init()
	{
		this.enemyAnimator = GetComponentInChildren<Animator>();
		this.enemySprite = GetComponentInChildren<SpriteRenderer>();
	}

	public virtual void Movement()
	{
		if (currentWayPoint == wayPointA.position)
		{
			this.enemySprite.flipX = true;
		}
		else
		{
			this.enemySprite.flipX = false;
		}

		if (transform.position == wayPointA.position)
		{
			this.currentWayPoint = wayPointB.position;
			this.enemyAnimator.SetTrigger("idle");
		}
		else if (transform.position == wayPointB.position)
		{
			this.currentWayPoint = wayPointA.position;
			this.enemyAnimator.SetTrigger("idle");
		}

		this.moveTowards();
	}

	public virtual void moveTowards()
	{
		transform.position = Vector3.MoveTowards(transform.position,
			this.currentWayPoint,
			speed * Time.deltaTime);
	}

	public virtual void Attack()
    {
		Debug.Log("BaseAttack Called.");
    }
}
