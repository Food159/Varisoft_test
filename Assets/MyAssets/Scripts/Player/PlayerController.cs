using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;
    [SerializeField] private InputActionReference inputMove; // Input movement joystick ref

    Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>(); // GetComponent from children
    }
    private void FixedUpdate()
    {
        Vector2 inputVector = inputMove.action.ReadValue<Vector2>(); // Get Value Vector2 from joystick
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = rb2d.position + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rb2d.MovePosition(newPos);
    }
}
