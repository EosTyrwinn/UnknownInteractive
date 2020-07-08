using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] Transform Camera;
    [SerializeField] float WalkSpeed;
    [SerializeField] float RunSpeed;
    public static float AngularSpeed = 30;

    CharacterController Controller;
    Transform Trans;
    Vector2 Move;
    Vector2 Look;
    float FallVelocity;
    float g;
    float Vertical;
    bool Run;

    /// <summary>
    /// Sets up some initial values
    /// </summary>
    private void Awake()
    {
        Trans = transform;
        Controller = GetComponent<CharacterController>();
        g = Physics.gravity.y / 2f;
    }

    /// <summary>
    /// Called when the player moves
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Called when the player runs
    /// </summary>
    /// <param name="context"></param>
    public void OnRun(InputAction.CallbackContext context)
    {
        Run = (context.phase == InputActionPhase.Performed);
    }

    /// <summary>
    /// Called when the player mvoes the mouse to look
    /// </summary>
    /// <param name="context"></param>
    public void OnLook(InputAction.CallbackContext context)
    {
        Look = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        // Hide the cursor if the game isn't paused and the notepad isn't open
        if (PauseMenu.Paused || Notepad.NotepadOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        float deltaTime = Time.deltaTime;
        FallVelocity += g * deltaTime * deltaTime;
        float oldY = Trans.position.y;
        float speed = Run ? RunSpeed : WalkSpeed;

        //Move
        Controller.Move(Trans.right * Move.x * speed * deltaTime + Vector3.up * FallVelocity);
        Controller.Move(Trans.forward * Move.y * speed * deltaTime + Vector3.up * FallVelocity);

        //Look
        Vertical = Mathf.Clamp(Vertical - Look.y * deltaTime * AngularSpeed, -90.0f, 90.0f);
        Camera.localRotation = Quaternion.Euler(Vertical, 0.0f, 0.0f);
        Trans.Rotate(Vector3.up * Look.x * deltaTime * AngularSpeed);

        
        if(oldY == Trans.position.y)
        {
            FallVelocity = 0.0f;
        }
    }

    // This is a comment to show you fetching
}
