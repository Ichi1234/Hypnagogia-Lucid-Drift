using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;

    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    private Vector3 velocity;
    private Vector2 moveInput;

    private PlayerInputSet3D input;

    private void Awake()
    {
        input = new PlayerInputSet3D();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += _ => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        if (input.UI.Menu.WasPressedThisFrame())
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        Vector3 move = cameraTransform.right * moveInput.x +
                       cameraTransform.forward * moveInput.y;

        move.y = 0f;

        controller.Move(move * speed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
   
}