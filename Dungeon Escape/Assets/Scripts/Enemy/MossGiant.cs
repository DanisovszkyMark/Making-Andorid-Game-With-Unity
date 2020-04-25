using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    // TODO: Create an interface: IMoveable
    private Vector3 currentWayPoint;

    // 
    private Animator mossGiantAnimator;

    // 
    private SpriteRenderer mossGiantSprite;

    private void Start()
    {
        this.mossGiantAnimator = GetComponentInChildren<Animator>();
        this.mossGiantSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("MossGiantAttack called.");
    }

    public override void Update()
    {
        if (this.mossGiantAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        this.movement();
    }

    private void movement()
    {
        if (currentWayPoint == wayPointA.position)
        {
            this.mossGiantSprite.flipX = true;
        }
        else
        {
            this.mossGiantSprite.flipX = false;
        }

        if (transform.position == wayPointA.position)
        {
            this.currentWayPoint = wayPointB.position;
            this.mossGiantAnimator.SetTrigger("idle");
        }
        else if (transform.position == wayPointB.position)
        {
            this.currentWayPoint = wayPointA.position;
            this.mossGiantAnimator.SetTrigger("idle");
        }

        this.moveTowards();
    }

    private void moveTowards()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            this.currentWayPoint,
            speed * Time.deltaTime);
    }
}
