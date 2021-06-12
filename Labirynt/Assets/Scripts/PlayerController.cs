using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public float gravaity = -10f;
    Vector3 velocity;
    CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;
    float verticalSpeed;
    public float jumpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckIsGrounded();
        CheckTerrainType();
    }
    
    private void CheckIsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            verticalSpeed = -2;
        }
    }

    private void CheckTerrainType()
    {
        RaycastHit hit;
        if (Physics.Raycast(
                groundCheck.position,
                transform.TransformDirection(Vector3.down),
                out hit,
                0.4f,
                groundMask))
        {
            string terrainType;
            terrainType = hit.collider.gameObject.tag;
            switch (terrainType)
            {
                default:
                    speed = 12;
                    break;
                case "LowPlane":
                    speed = 3;
                    break;
                case "HighPlane":
                    speed = 20;
                    break;
            }
        }
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        verticalSpeed += gravaity * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            verticalSpeed = jumpSpeed;
        }
        characterController.Move((x * transform.right + z * transform.forward + verticalSpeed * transform.up) * Time.deltaTime * speed);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
        {
            GetComponent<Ammo>().AddCurrentAmmo(5);
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
