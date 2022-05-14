using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCameraMika : MonoBehaviour
{
    public GameObject personnage; 
    public GameObject camera; 
    public GameObject positionRayCastCamera; 
    public float hauteurPivot; 
    public float distanceCamera; 
    public float vitesseCameraX; 
    public float vitesseCameraY; 
    private float rotationY = 0f;
    
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.position = personnage.transform.position + new Vector3(0, hauteurPivot, 0);
        transform.Rotate(-Input.GetAxis("Mouse Y") * vitesseCameraY, Input.GetAxis("Mouse X") * vitesseCameraX, 0);

        rotationY += Input.GetAxis ("Mouse Y") * vitesseCameraY; 
        rotationY = Mathf.Clamp (rotationY, -55, 35);
        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        camera.transform.localPosition = new Vector3(0, 0, distanceCamera); 
    }
}
