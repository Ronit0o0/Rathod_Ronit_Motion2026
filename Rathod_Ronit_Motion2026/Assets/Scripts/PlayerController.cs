using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;


public class PlayerController : MonoBehaviour
{
    private bool isMoving = false;
    private Rigidbody2D playerRB;
    public float Maxspeed;
    private float acceleration;
    public float accelerationTime;

    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();

        //How fast the player should be able to move at max speed and how long it should take to reach that speed.
        acceleration = Maxspeed / accelerationTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        Vector2 playerInput = new Vector2();
        MovementUpdate(playerInput);

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x += Maxspeed;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput.x -= Maxspeed;
        }
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        //This function should manage the movement of the player based on the input that is passed to it. It should also manage the acceleration and deceleration of the player.
        Vector2 newVelocity = playerRB.linearVelocity;
        if (playerInput.x != 0)
        {
            newVelocity += playerInput * acceleration * Time.deltaTime;
            //accelerate
        }
        else
        {
            //?????
        }
        playerRB.linearVelocity = newVelocity;
    }

    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
