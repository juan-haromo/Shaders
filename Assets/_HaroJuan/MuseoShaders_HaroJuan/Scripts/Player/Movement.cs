using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Input = new PlayerInput();
            Input.PlayerMovement.Enable();
        }
        else
        {
            Destroy(this);
        }
    }

    public PlayerInput Input {  get; private set; }

    public Transform orientation;
    public Rigidbody rb;
    public float xSense, ySense, speed;

    float mouseX, mouseY;
    float rotationX = 0, rotationY = 0; 
    float xMovement, yMovement;
    Vector3 moveDirection;

    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject canvasPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        HideInteraction();
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

    public void ShowInteraction()
    {
        canvasPanel.SetActive(true);
    }

    public void HideInteraction()
    {
        canvasPanel.SetActive(false);
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
    }
}
