using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRB;

    public float maxSpeed;

    public float accelerationTime;
    private float acceleration;
   

    Vector3 currentVelocity;

    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
    }

    void FixedUpdate()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        Vector2 playerInput = new Vector2();

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x += 1f;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput.x -= 1f;
        }

        MovementUpdate(playerInput);

        //Debug.Log(playerRB.linearVelocityX);

        Debug.Log("Nothing Under My Feet");

        Debug.DrawRay(transform.position, -Vector2.up, Color.red);
        
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        Vector2 newVelocity = playerRB.linearVelocity;
        if (playerInput.x != 0)
        {
            //accelerate
            newVelocity += playerInput * acceleration * Time.deltaTime;
        }
        else
        {
            newVelocity += -newVelocity.normalized * acceleration * Time.deltaTime;
        }
        playerRB.linearVelocity = newVelocity;
    }

    public bool IsWalking()
    {
        if (playerRB.linearVelocityX !> 0.5 || playerRB.linearVelocityX! < -0.5)
        {
            return true;
        }
        return false;
        
    }
    public bool IsGrounded()
    {
        RaycastHit2D onGround = Physics2D.Raycast(transform.position, -Vector2.up, transform.position.y + 2f);

        if (!onGround)
        {
            Debug.Log("I'm good");
            return false;
        }
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
        if (playerRB.linearVelocityX! > 0.1) 
        { 
            return FacingDirection.right;
        }        
        if (playerRB.linearVelocityX! < -0.1)
        {
            return FacingDirection.left;
        }
            
        return FacingDirection.left;
    }
}
