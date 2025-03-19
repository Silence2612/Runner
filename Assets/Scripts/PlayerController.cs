using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 50;
    [SerializeField] float xClamp = 3f;
    [SerializeField] float zClamp = 2f;

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
        MoveVector.x = Mathf.Clamp(MoveVector.x , -xClamp , +xClamp);
        MoveVector.z = Mathf.Clamp(MoveVector.z , -zClamp , +zClamp);
        
        rb.MovePosition(MoveVector);

    }
}
