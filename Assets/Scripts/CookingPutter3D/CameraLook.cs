using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform playerBody;
    public float sensitivity = 0.1f;

    private PlayerInputSet3D input;
    private Vector2 lookInput;
    private float xRotation;

    void Awake()
    {
        input = new PlayerInputSet3D();
    }

    void OnEnable()
    {
        input.Enable();
        input.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        input.Player.Look.canceled += _ => lookInput = Vector2.zero;
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        float mouseX = lookInput.x * sensitivity;
        float mouseY = lookInput.y * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}