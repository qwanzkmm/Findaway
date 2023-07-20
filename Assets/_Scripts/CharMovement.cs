using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CharMovement : MonoBehaviour
{
    public float MovementSpeed;
    
    
    private CharacterController charController;

    private float horizontalAxis;
    private float verticalAxis;
    [SerializeField] private LayerMask groundLayer;
    private Vector3 moveVector;

    private bool isGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.3f, groundLayer))
        {
            return true;
        }
        
        return false;
    }
    
    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        horizontalAxis = Input.GetAxis(AXIS_CONSTS.HORIZONTAL);
        verticalAxis = Input.GetAxis(AXIS_CONSTS.VERTICAL);

        moveVector = horizontalAxis * transform.right + verticalAxis * transform.forward;
        
        if (!isGrounded())
        {
            moveVector += Vector3.down * 2;
        }
        
        charController.Move(moveVector * Time.deltaTime * MovementSpeed);
    }
}
