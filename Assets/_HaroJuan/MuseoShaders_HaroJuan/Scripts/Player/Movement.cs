using UnityEngine;

public class Movement : MonoBehaviour
{

    public PlayerInput Input {  get; private set; }

    public Transform orientation;
    public Rigidbody rb;
    public float xSense, ySense, speed;

    float mouseX, mouseY;
    float rotationX = 0, rotationY = 0; 
    float xMovement, yMovement;
    Vector3 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Input = new PlayerInput();
        Input.PlayerMovement.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        
    }

    private void OnDestroy()
    {
        Input.PlayerMovement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.PlayerMovement.RotationY.ReadValue<float>() * xSense * Time.deltaTime;
        mouseY = Input.PlayerMovement.RotationX.ReadValue<float>() * ySense * Time.deltaTime;

        rotationX += mouseX;
        rotationY += mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        orientation.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        transform.rotation = Quaternion.Euler(0, rotationY, 0);

        xMovement = Input.PlayerMovement.Side.ReadValue<float>();
        yMovement = Input.PlayerMovement .Forward.ReadValue<float>();
        moveDirection = (transform.forward * yMovement) + (transform.right * xMovement);

        if(moveDirection != Vector3.zero)
        {
            moveDirection = moveDirection.normalized * speed;
            moveDirection.y = rb.linearVelocity.y + (-9.81f* Time.deltaTime);
            rb.linearVelocity = moveDirection;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
        Shader.SetGlobalVector("_PlayerPosition", transform.position);
    }
}
