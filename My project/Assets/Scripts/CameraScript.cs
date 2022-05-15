using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform player;
    private StaticValues staticValues;
    private float mouseSens = 15f;
    private float xRotation = 0f;

    void Awake() {
        staticValues = new StaticValues();
    }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        //transform.localRotation = Quaternion.Euler(0, 0f, 0f);
        //player.rotation = Quaternion.Euler(0, 0f, 0f);
    }

    private void Update() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime * staticValues.GetXSens();
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime * staticValues.GetYSens();

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
