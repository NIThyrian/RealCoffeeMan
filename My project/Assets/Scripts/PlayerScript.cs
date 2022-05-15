using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded = false;
    private float gravity = -9.81f;

    public int speed = 20;
    public int speedUpgradeIncrement = 5;
    public int damage = 50;
    public int damageUpgradeIncrement = 5;
    private float jumpHeight;
    private bool nearShop;

    private GameObject[] shops;
    private Game game;

    private void Start() {
        game = GetComponentInParent(typeof(Game)) as Game; 
        speed += game.playerDict["BootsPurchased"] * speedUpgradeIncrement;
        damage += game.playerDict["GunPurchased"] * damageUpgradeIncrement;
        jumpHeight = speed / 2;
        
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

        foreach(GameObject shop in shops) {
            if(Vector3.Distance(shop.transform.position, transform.position) < 5) {
                nearShop = true;
                break;
            } else nearShop = false;
        }

        if(nearShop) {
            if(Input.GetKeyDown("e")) {
                game.E();
                game.eText.SetActive(false);
            }
            if(!Cursor.visible) game.eText.SetActive(true);
        } else game.eText.SetActive(false);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.CompareTag("Coin")) {

            switch(hit.gameObject.name) {
                case("CaCoin(Clone)"):
                    game.playerDict["CaHeld"] += 1;
                    break;
                case("RocketCoin(Clone)"):
                    game.playerDict["RocketHeld"] += 1;
                    break;
                case("NotACubeCoin(Clone)"):
                    game.playerDict["NotACubeHeld"] += 1;
                    break;
                case("PoopCoin(Clone)"):
                    game.playerDict["PoopHeld"] += 1;
                    break;
                default:
                    game.playerDict["GoldHeld"] += 1;
                    break;
            }
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.GetComponent<Rigidbody>() != null) {
            if (hit.gameObject.CompareTag("Portal")) game.ChangeLevel();
            
            Rigidbody hitBody = hit.collider.attachedRigidbody;
            if(hitBody != null) {
                Vector3 moveDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
                hitBody.AddForce(moveDir * 10.0f);
            }
        }


    }
}
