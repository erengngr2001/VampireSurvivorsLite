using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configs")]
    public float moveSpeed = 6f; // world units per second
    //public GameObject backgroundPrefab; // Prefab for the background

    [Header("Input")]
    public InputActionAsset actionsAsset;         // assign your PlayerControls.inputactions asset

    private Rigidbody2D rb;
    private Vector2 moveInput = Vector2.zero;

    // InputAction for movement (created in code so you don't need an asset yet)
    private InputAction moveAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("Rigidbody2D missing on Player!");
        if (actionsAsset == null) Debug.LogError("Assign InputActionAsset in inspector (PlayerControls).");

        // Create the InputAction for movement for mobile game
        //moveAction = new InputAction("Move", binding: "<Touchscreen>/primaryTouch/delta");
        //moveAction = new InputAction("PlayerMove");

        //moveAction.AddCompositeBinding("2DVector")
        //    .With("Up", "<Keyboard>/w")
        //    .With("Up", "<Keyboard>/upArrow")
        //    .With("Down", "<Keyboard>/s")
        //    .With("Down", "<Keyboard>/downArrow")
        //    .With("Left", "<Keyboard>/a")
        //    .With("Left", "<Keyboard>/leftArrow")
        //    .With("Right", "<Keyboard>/d")
        //    .With("Right", "<Keyboard>/rightArrow");

        //moveAction = new InputAction("Move", binding: "<Gamepad>/leftStick"); // BU NE KÝ


    }

    void OnEnable()
    {
        moveAction = actionsAsset.FindAction("Player/Move");
        if (moveAction == null) Debug.LogError("Move action not found in asset (expect Player/Move).");
        if (moveAction != null) moveAction.Enable();
    }

    void OnDisable()
    {
        if (moveAction != null) moveAction.Disable();
    }

    private void FixedUpdate()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        if (moveInput.sqrMagnitude > 1f)
            moveInput = moveInput.normalized; // clamp diagonal speed

        Vector2 newPos = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
