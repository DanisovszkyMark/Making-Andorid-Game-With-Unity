using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health 
    {
        get
        {
            return base.health;
        }

        set
        {
            this.health = value;
        }
    }

    public override void Init()
    {
        base.Init();
    }

    public void Damage()
    {
        Debug.Log("Skeleton Damaged!");
        this.Health -= 1;

        if (this.Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
