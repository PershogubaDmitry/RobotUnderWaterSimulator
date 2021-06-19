using UnityEngine;

public class FPSController : MonoBehaviour
{
    public Transform myCamera;
    public Rigidbody rb;

    public float camRotationSpeed = 5f;
    public float cameraMinimumY = -60f;
    public float cameraMaximumY = 75f;
    public float rotationSmoothSpeed = 10f;

    public float walkSpeed = 9f;
    public float runSpeed = 14f;
    public float maxSpeed = 20f;
    public float jumpPower = 30f;
    public float extraGravity = 45;

    float bodyRotationX;
    float camRotationY;
    Vector3 directionIntentX;
    Vector3 directionintentY;

    float speed;

    public bool grounded;

    private void Start() {
        
    }
    void Update()
    {
        LookRotation();
        Movement();
        ExtraGravity();
        GroundCheck();

        if(Input.GetButton("Jump"))
        {
            moveUp();  
        }
    }
    void LookRotation()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        bodyRotationX += Input.GetAxis("Mouse X") * camRotationSpeed;
        camRotationY += Input.GetAxis("Mouse Y") * camRotationSpeed;

        camRotationY = Mathf.Clamp(camRotationY, cameraMinimumY, cameraMaximumY);

        Quaternion camTargetRotation = Quaternion.Euler(-camRotationY, 0, 0);
        Quaternion bodyTargetRotation = Quaternion.Euler(0, bodyRotationX, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, bodyTargetRotation, Time.deltaTime * rotationSmoothSpeed);

        myCamera.localRotation = Quaternion.Lerp(myCamera.localRotation, camTargetRotation, Time.deltaTime * rotationSmoothSpeed);

    }

    void Movement()
    {
        directionIntentX = myCamera.right;
        directionIntentX.y = 0;
        directionIntentX.Normalize();

        directionintentY = myCamera.forward;
        directionintentY.y = 0;
        directionintentY.Normalize();

        rb.velocity = directionintentY*Input.GetAxis("Vertical")*speed + directionIntentX * Input.GetAxis("Horizontal")*speed+ Vector3.up*rb.velocity.y;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        if(!Input.GetKey(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }
    }


    void ExtraGravity()
    {
        rb.AddForce(Vector3.down*extraGravity);
    }

    void GroundCheck()
    {
        RaycastHit groundHit;
        grounded = Physics.Raycast(transform.position, -transform.up, out groundHit, 1.25f);
    }

    void moveUp()
    {
        if(rb.transform.position.y<=27)
        {
            rb.AddForce(Vector3.up * jumpPower*Time.deltaTime, ForceMode.Impulse);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
}
