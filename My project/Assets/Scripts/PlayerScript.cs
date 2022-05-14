using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    private float speed = 12f;
    private float jumpHeight = 5f;
    private Vector3 velocity;
    private bool isGrounded = false;
    private float gravity = -9.81f;

    private void Start()
    {
        jumpHeight = speed / 2;
    }
    void Update() {
        isGrounded = controller.isGrounded;
        if(isGrounded && velocity.y < 0) velocity.y = 0;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDir = transform.right * x + transform.forward * z;
        controller.Move(moveDir * speed * Time.deltaTime);
        
        if(Input.GetButtonDown("Jump") && isGrounded) velocity.y += Mathf.Sqrt(jumpHeight * -3f * gravity);
        
        velocity.y += 2 * gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
