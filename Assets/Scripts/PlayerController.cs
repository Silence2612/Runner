using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 50;
    Rigidbody rb;
    Vector2 Movement;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Move (InputAction.CallbackContext context) 
    {
        Movement = context.ReadValue<Vector2>();
        Debug.Log(Movement);
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 MoveVector = new Vector3(Movement.x* (MoveSpeed * Time.deltaTime) + transform.position.x, 0, Movement.y* (MoveSpeed * Time.deltaTime) + transform.position.z);
        rb.MovePosition(MoveVector);
    }
}
