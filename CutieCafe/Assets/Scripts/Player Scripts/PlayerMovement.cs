using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    [SerializeField] float speed = 5;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Read movement direction from input
        Vector2 direction = moveAction.ReadValue<Vector2>();

        // If there's movement, update position and rotation
        if (direction.sqrMagnitude > 0.01f) // Use a small threshold to avoid jittering at low input
        {
            Vector3 movement = new Vector3(direction.x, 0, direction.y);
            transform.position += movement * speed * Time.deltaTime;

            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10); 
        }
    }
}
