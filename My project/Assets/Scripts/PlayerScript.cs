using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    private float jumpHeight = 5f;
    private Vector3 velocity;
    private bool isGrounded = false;
    private float gravity = -9.81f;
    public int maxHealth;
    public int currentHealth;
    public int speed = 20;
    public int speedUpgradeIncrement;
    public int damage;
    public int damageUpgradeIncrement;
    private GameObject[] shops;


    private void Start() {
        Game component = GetComponentInParent(typeof(Game)) as Game; 
        speed += component.playerDict["BootsPurchased"] * speedUpgradeIncrement;
        jumpHeight = speed / 2;
        damage += component.playerDict["GunPurchased"] * damageUpgradeIncrement;
        currentHealth = maxHealth;
        shops = GameObject.FindGameObjectsWithTag("Shop");

    }

    private void Update() {
        isGrounded = controller.isGrounded;
        if(isGrounded && velocity.y < 0) velocity.y = 0;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDir = transform.right * x + transform.forward * z;
        controller.Move(moveDir * speed * Time.deltaTime);
        
        if(Input.GetButtonDown("Jump") && isGrounded) velocity.y += Mathf.Sqrt(jumpHeight * -3f * gravity);
        
        velocity.y += 2 * gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        foreach( GameObject shop in shops)
        {
            
            if (Vector3.Distance(shop.transform.position, transform.position) < 5 && Input.GetKeyDown("e"))
            {
                Debug.Log("e");
                Game component = GetComponentInParent(typeof(Game)) as Game;
                component.E();

            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.GetComponent<Rigidbody>() != null) {
            if (hit.gameObject.CompareTag("Portal")){
                Game component = GetComponentInParent(typeof(Game)) as Game;
                component.ChangeLevel();
            }
           
            Rigidbody hitBody = hit.collider.attachedRigidbody;
            if(hitBody != null) {
                Vector3 moveDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
                hitBody.AddForce(moveDir * 10.0f);
            }
        }
    }
}
