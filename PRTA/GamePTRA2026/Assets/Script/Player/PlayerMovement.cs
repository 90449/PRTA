using Ilumisoft.HealthSystem.UI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpheight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float sprintSpeed = 12f;
    public float health = 100f;
    public Slider healthBar;
    public Transform SpawnPoint;
    //bool isSprinting = Input.GetKey(KeyCode.LeftShift);
    //float currentSpeed = isSprinting ? sprintSpeed : speed;

    Vector3 velocity;

    bool isGrounded;

    // Update is called once per frame
    private void Update()
    {
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isSprinting ? sprintSpeed : speed;
        //Checking if we hit the ground to reset out falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);

        //check if the player is on the ground so he can jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        string tag = hit.gameObject.tag;

        if (tag == "Health") health += 1;
        if (tag == "Health2") health += 10;
        if (tag == "Health3") health += 100;
        if (tag == "Damage") health -= 1;

        // Zorg dat health binnen 0-100 blijft
        health = Mathf.Clamp(health, 0f, 100f);
        healthBar.value = health;

        if (health <= 0)
        {
            controller.enabled = false;
            transform.position = SpawnPoint.position;
            controller.enabled = true;
            health = 100f;
            healthBar.value = health;
        }
    }
}
