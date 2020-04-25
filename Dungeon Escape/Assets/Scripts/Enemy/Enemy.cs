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

	public virtual void Attack()
    {
		Debug.Log("BaseAttack Called.");
    }

	public abstract void Update();
}
