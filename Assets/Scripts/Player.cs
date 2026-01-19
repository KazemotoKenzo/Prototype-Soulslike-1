using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private InputActionReference moveAction;
    [SerializeField]
    private InputActionReference jumpAction;
    [SerializeField]
    private CharacterController _controller;
    
    
    public Transform cam;

    public bool isGrounded;
    public Vector2 playerVel;
    public float rotationSpeed;
    public float gravityScale;
    public float jumpforce;
    public float move_speed;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
    }


    public void OnMove()
    {
        isGrounded = _controller.isGrounded;

        if (isGrounded)
        {
            if(playerVel.y < 2f) playerVel.y = -2f;
        }

        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = cam.forward * input.y + cam.right * input.x;
        move.y = 0;
        move.Normalize();

        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation  = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        if(isGrounded && jumpAction.action.WasPressedThisFrame()) playerVel.y = Mathf.Sqrt(jumpforce * -2 * gravityScale);

        playerVel.y += gravityScale * Time.deltaTime;
        
        _controller.Move((move * move_speed + Vector3.up * playerVel.y) * Time.deltaTime);
    }
}
