using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // The player's rigidbody
    private Rigidbody2D rigidbody;

    // Variable for the run
    [SerializeField]
    private float speed;

    // Variables for the jump
    [SerializeField] // Shows the element in the Unity UI
    private float jumpForce;

    [SerializeField]
    private LayerMask groundLayer;

    private float groundDistance = 0.6f;

    // The player's Animation
    private PlayerAnimation playerAnimation;

    void Start()
    {
        // Get reference to rigidbody
        this.rigidbody = GetComponent<Rigidbody2D>();

        // Get reference to PlayerAnimation (which in the Player Object)
        this.playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        this.moveLeftAndRight();
        this.moveHorizontal();
        this.attack();

        // To developing
        this.DrawRay();
    }

    private void moveLeftAndRight()
    {
        // Horizontal input for left / right ( a - d || <- - -> )
        // Raw for avoid the smooth
        float horizontalInput = Input.GetAxisRaw("Horizontal");
  
        // Only want to move on the x about the horizontalInput what can be -1, 0, 1
        this.rigidbody.velocity = new Vector2(horizontalInput * speed, this.rigidbody.velocity.y);

        // Start the animations if it needed
        this.playerAnimation.move(horizontalInput);
        this.playerAnimation.flipPlayer(horizontalInput);
    }

    private void moveHorizontal()
    {
        // TODO: Feature: double jumping
        if (this.isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            this.jump();
        }
    }

    private void jump()
    {
        this.rigidbody.velocity = new Vector2(this.rigidbody.velocity.x, this.jumpForce);
    }

    public void attack()
    {
        // 0 means the left click
        if (Input.GetMouseButtonDown(0) && this.isGrounded())
        {
            this.doAttack();
        }
    }

    public void doAttack()
    {
        this.playerAnimation.attack();
    }

    private bool isGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,
            Vector2.down, 
            this.groundDistance, 
            this.groundLayer.value);

        if (hitInfo.collider != null)
        {
            this.playerAnimation.jump(false);
            return true;
        }

        // TODO: Avoid the code repeat
        this.playerAnimation.jump(true);
        return false;
    }

    private void DrawRay()
    {
        Debug.DrawRay(transform.position, Vector2.down * this.groundDistance, Color.green);
    }
}
