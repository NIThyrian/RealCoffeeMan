using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    private float speed = 20.0f;

    private Vector3 velocity;
    private bool isGrounded = false;
    private float gravity = -9.81f;

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0) velocity.y = 0;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDir = transform.right * x + transform.forward * z;
        controller.Move(moveDir * speed * Time.deltaTime);
       
        if(Input.GetButtonDown("Jump") && isGrounded) velocity.y += Mathf.Sqrt(5f * -3f *gravity);
        
        velocity.y += 2 * gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}