using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // The animator for the player
    private Animator playerAnimator;

    // The animator for the sword effects
    private Animator swordAnimator;

    // To flipPlayer the sprite
    private SpriteRenderer playerSprite;

    // To flipPlayer the sword effect sprite
    private SpriteRenderer swordArcSprite;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to Animator
        this.playerAnimator = GetComponentInChildren<Animator>();

        // Get reference to SwordAnimator
        this.swordAnimator = transform.GetChild(1).GetComponent<Animator>();

        // Get reference to PlayerRenderer
        this.playerSprite = GetComponentInChildren<SpriteRenderer>();

        // Get reference to SwordArcRenderer
        this.swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    public void move(float move)
    {
        // move = -1, 0, 1. The animation start when the move greater than 0. That is why use abs.
        float moveAbs = Mathf.Abs(move);
        
        this.playerAnimator.SetFloat("move", moveAbs);

        if (moveAbs == 0)
        {
            this.jump(false);
        }
    }

    public void flipPlayer(float move)
    {
        if (move > 0)
        {
            // Face right
            this.playerSprite.flipX = false;
            this.flipSwordArc(false);
        }
        else if (move < 0)
        {
            // Face left
            this.playerSprite.flipX = true;
            this.flipSwordArc(true);
        }
    }

    public void flipSwordArc(bool faceRight)
    {
        this.swordArcSprite.flipX = faceRight;
        this.swordArcSprite.flipY = faceRight;

        Vector3 newPosition = this.swordArcSprite.transform.localPosition;
        if (faceRight)
        {
            if (newPosition.x > 0)
            {
                newPosition.x *= -1;
            }

            this.swordArcSprite.transform.localPosition = newPosition;
        }
        else
        {
            if (newPosition.x < 0)
            {
                newPosition.x *= -1;
            }

            this.swordArcSprite.transform.localPosition = newPosition;
        }
    }

    public void jump(bool jumping)
    {
        this.playerAnimator.SetBool("jumping", jumping);
    }

    public void attack()
    {
        this.playerAnimator.SetTrigger("attack");
        this.swordAnimator.SetTrigger("swordAnimation");
    }
}
