using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private void Start()
    {
        this.Attack();
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("MossGiantAttack called.");
    }

    public override void Update()
    {
        Debug.Log("MossGiantUpdate called.");
    }
}
