﻿using System.Collections;
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

	public virtual void Attack()
    {
		Debug.Log("BaseAttack Called.");
    }

	public abstract void Update();
}
