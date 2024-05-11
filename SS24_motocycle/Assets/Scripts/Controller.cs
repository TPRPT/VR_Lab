using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class NewBehaviourScript : MonoBehaviour
{
    RaycastHit hit;
    float moveInput, steerInput, rayLength, currentVelocityOffset;

    [HideInInspector] public Vector3 velocity;
    public Rigidbody sphereRB, BikeBody;
    // public GameObject Handle;
    public AudioSource engineSound;
    public GameObject ForntTyre;
    public GameObject BackTyre;


    public float maxSpeed, acceleration, steerStrength, gravity, bikeTiltIncrement = .09f,
        zTiltAngle = 45f, handleRotVal = 30f, handleRotSpeed = .15f, tyreRotSpeed = 10000f;
    
    
    [Range(1,10)]
    public float brakingFactor;
    public float minPitch = 0;
    public float maxPitch;
    public LayerMask derivableSurface;

    
    // Start is called before the first frame update
    void Start()
    {
        sphereRB.transform.parent = null;
        BikeBody.transform.parent = null;

        rayLength = sphereRB.GetComponent<SphereCollider>().radius + 0.2f;


    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");

        transform.position = sphereRB.transform.position;
        BikeBody.MoveRotation(transform.rotation);

        velocity = BikeBody.transform.InverseTransformDirection(BikeBody.velocity);
        currentVelocityOffset = velocity.z / maxSpeed;
    }

    private void FixedUpdate()
    {
        Movement();

        // ForntTyre.transform.Rotate(Vector3.right, Time.deltaTime * tyreRotSpeed *currentVelocityOffset);
        // BackTyre.transform.Rotate(Vector3.right, Time.deltaTime * tyreRotSpeed *currentVelocityOffset);

        EngineSound();
    }

    void Movement()
    {
        if (Grounded())
        {
            if(!Input.GetKey(KeyCode.Space))
            {
                Acceleration();
                Rotation();
            }
            Brake();
        }
        else
        {
            Gravity();
        }
        BikeTilt();
    }

    void Acceleration()
    {
        sphereRB.velocity = Vector3.Lerp(sphereRB.velocity, maxSpeed * moveInput * transform.forward, Time.fixedDeltaTime * acceleration);
    }

    void Rotation()
    {
        transform.Rotate(0, steerInput * moveInput * currentVelocityOffset * steerStrength * Time.fixedDeltaTime, 0, Space.World);

        // Handle.transform.localRotation = Quaternion.Slerp(Handle.transform.localRotation, Quaternion.Euler(Handle.transform.localRotation.eulerAngles.x, handleRotVal * steerInput, Handle.transform.localRotation.eulerAngles.z), handleRotSpeed);
    }

    void BikeTilt()
    {
        float xRot = (Quaternion.FromToRotation(BikeBody.transform.up, hit.normal) * BikeBody.transform.rotation).eulerAngles.x;
        float zRot = 0;

        if(currentVelocityOffset > 0)
        {
            zRot = -zTiltAngle * steerInput * currentVelocityOffset;
        }

        Quaternion targetRot = Quaternion.Slerp(BikeBody.transform.rotation, Quaternion.Euler(xRot, transform.eulerAngles.y, zRot), bikeTiltIncrement);

        Quaternion newRotation = Quaternion.Euler(targetRot.eulerAngles.x, transform.eulerAngles.y, targetRot.eulerAngles.z);

        BikeBody.MoveRotation(newRotation);
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sphereRB.velocity *= brakingFactor / 10;
        }
    }

    bool Grounded()
    {
        if (Physics.Raycast(sphereRB.position, Vector3.down, out hit, rayLength, derivableSurface))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Gravity()
    {
        sphereRB.AddForce(gravity * Vector3.down, ForceMode.Acceleration);
    }

    void EngineSound()
    {
        engineSound.pitch = Mathf.Lerp(minPitch, maxPitch, Mathf.Abs(currentVelocityOffset));
    }
}
