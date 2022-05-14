using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpForce = 300f;
    private bool _shouldJump;
    private float speed = 300.0f;

    // private Vector3 velocity;
    
    private bool isGrounded = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_shouldJump == false)
            _shouldJump = Input.GetButtonDown("Jump");

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
        

    }


    void FixedUpdate() {


        if (_shouldJump)
        {
            Debug.Log("Adding force");
            // controller.Move(jumpForce * Vector3.up);
            rb.AddForce(jumpForce * Vector3.up);
            _shouldJump = false;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDir = transform.right * x + transform.forward * z;
        // controller.Move(moveDir * speed * Time.deltaTime);

        rb.AddForce(moveDir);
    }
}
