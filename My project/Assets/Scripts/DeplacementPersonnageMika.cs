using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementPersonnageMika : MonoBehaviour
{
    public Rigidbody rigidbodyPerso;
    public GameObject playerCamera;
    float vitesseDeplacement; 
    public float hauteurSaut;
    public float ajoutGravite;
    private float forceDuSaut;
    private bool auSol;
    public bool saut;

    public int health = 10;
    
    void Start()
    {
        rigidbodyPerso = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hDeplacement = Input.GetAxisRaw("Horizontal");
        float vDeplacement = Input.GetAxisRaw("Vertical");
        Vector3 directionDep = playerCamera.transform.forward * vDeplacement + playerCamera.transform.right * hDeplacement;
        directionDep.y = 0;
        if(directionDep != Vector3.zero)
        {
            transform.forward = directionDep;
            rigidbodyPerso.velocity = (transform.forward * vitesseDeplacement) + new Vector3(0, rigidbodyPerso.velocity.y, 0);
        }
        else
        {
            rigidbodyPerso.velocity = new Vector3(0, rigidbodyPerso.velocity.y, 0);
        }

        if(vitesseDeplacement <= 15f && (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d")))
        {
            vitesseDeplacement += 0.08f;
        }
        else if (vitesseDeplacement >= 5 && (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d")))
        {
            vitesseDeplacement = 15;
        }
        else
        {
            vitesseDeplacement = 0;
        } 

        RaycastHit infoCollision;
        auSol = Physics.SphereCast(transform.position + new Vector3(0f, 0.5f, 0f), 0.2f, -Vector3.up, out infoCollision, 0.8f);
        if(Input.GetKeyDown(KeyCode.Space) && auSol)
        {
            forceDuSaut = hauteurSaut;
            saut = true;
        }    
    }
    void FixedUpdate()
    {
        if (auSol)
        {
            GetComponent<Rigidbody>().AddRelativeForce(0f, forceDuSaut, 0f, ForceMode.VelocityChange);
            rigidbodyPerso.drag = 5;
            rigidbodyPerso.angularDrag = 5;
        }
        else
        {
            GetComponent<Rigidbody>().AddRelativeForce(0f, ajoutGravite, 0f, ForceMode.VelocityChange);
        }
        forceDuSaut = 0f;
    }
}
