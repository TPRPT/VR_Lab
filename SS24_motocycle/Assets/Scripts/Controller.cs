using UnityEngine;

public class Controller : MonoBehaviour
{
    RaycastHit hit;
    float moveInput, steerInput, rayLength, currentVelocityOffset;

    [HideInInspector] public Vector3 velocity;
    public Rigidbody sphereRB, BikeBody;
    public GameObject Handle;
    public AudioSource engineSound;
    public GameObject ForntTyre;
    public GameObject BackTyre;
    public AnimationCurve turningCurve;


<<<<<<< HEAD
    public float power, maxSpeed, acceleration, steerStrength, gravity, bikeTiltIncrement = .09f,
=======
    public float maxSpeed, acceleration, steerStrength, gravity, bikeTiltIncrement = .09f,
>>>>>>> 82d24ce08c83b0e707b8f496fdd21b79cf9c1c69
        zTiltAngle = 45f, handleRotVal = 30f, handleRotSpeed = .15f, tyreRotSpeed = 10000f,
        norDrag = 2f, driftDrag = 0.5f;
    
    
    [Range(1,10)] public float brakingFactor;
    public float minPitch = 0;
    public float maxPitch;
    public LayerMask derivableSurface;
<<<<<<< HEAD
=======

>>>>>>> 82d24ce08c83b0e707b8f496fdd21b79cf9c1c69
    
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
<<<<<<< HEAD
        moveInput = GameObject.Find("Motocycle").GetComponent<MotorcycleControlVR>().GetAceleration();
        steerInput = GameObject.Find("Motocycle").GetComponent<MotorcycleControlVR>().GetSteering() * power;

        // moveInput = Input.GetAxis("Vertical");
        // steerInput = Input.GetAxis("Horizontal");

        // Debug.Log("move:" + moveInput + "steer" + steerInput);
=======
        Driving();
>>>>>>> 82d24ce08c83b0e707b8f496fdd21b79cf9c1c69

        transform.position = sphereRB.transform.position;
        BikeBody.MoveRotation(transform.rotation);

        velocity = BikeBody.transform.InverseTransformDirection(BikeBody.velocity);
        currentVelocityOffset = velocity.z / maxSpeed;
    }

    private void FixedUpdate()
    {
        Movement();

        ForntTyre.transform.Rotate(Vector3.right, Time.deltaTime * tyreRotSpeed *currentVelocityOffset);
        BackTyre.transform.Rotate(Vector3.right, Time.deltaTime * tyreRotSpeed *currentVelocityOffset);

        EngineSound();
    }

<<<<<<< HEAD
=======
    void Driving()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput += Input.GetAxis("Mouse X") / 10;
    }

>>>>>>> 82d24ce08c83b0e707b8f496fdd21b79cf9c1c69
    void Movement()
    {
        if (Grounded())
        {
            if(!Input.GetKey(KeyCode.Space))
            {
                Acceleration();
                Rotation();
            }
            Rotation();
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
        transform.Rotate(0, steerInput * moveInput * turningCurve.Evaluate(Mathf.Abs(currentVelocityOffset)) * steerStrength * Time.fixedDeltaTime, 0, Space.World);

        Handle.transform.localRotation = Quaternion.Slerp(Handle.transform.localRotation, Quaternion.Euler(Handle.transform.localRotation.eulerAngles.x, handleRotVal * steerInput, Handle.transform.localRotation.eulerAngles.z), handleRotSpeed);
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
            sphereRB.drag = driftDrag;
        }
        else
        {
            sphereRB.drag = norDrag;
        }
    }

    bool Grounded()
    {
        float radius = rayLength - 0.02f;
        Vector3 origin = sphereRB.transform.position + radius * Vector3.up;

        if (Physics.SphereCast(origin, radius + 0.02f, -transform.up, out hit, rayLength, derivableSurface))
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
