using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private void Start()
    {
        this.Attack();
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("SpiderAttack called.");
    }

    public override void Update()
    {
        Debug.Log("SpiderUpdate called.");
    }
}
