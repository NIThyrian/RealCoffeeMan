using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    private float speed = 12f;

    private Vector3 velocity;
    
    private bool isGrounded = false;

    public int CaCount = 0;
    public int GoldCount = 0;
    public int NotACubeCount = 0;
    public int PoopCount = 0;
    public int RocketCount = 0;

    void Update() {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
        if(isGrounded) velocity.y = 0f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDir = transform.right * x + transform.forward * z;
        controller.Move(moveDir * speed * Time.deltaTime);

        velocity.y += -9.81f * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && isGrounded) {
            transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+1f);
            velocity.y = Mathf.Sqrt(10f * 2f * 9.81f);
        }
        
        controller.Move(velocity * Time.deltaTime);
    }
}
