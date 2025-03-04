using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    public Animator animator;
    float vertInput;
    float horizInput;


    [SerializeField] float speed = 5;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        vertInput = Input.GetAxis("Vertical");
        horizInput = Input.GetAxis("Horizontal");
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
    void FixedUpdate()
    {
        float movementMagnitude = Mathf.Clamp01(Mathf.Abs(vertInput) + Mathf.Abs(horizInput));

        animator.SetFloat("Movement", movementMagnitude);
        animator.SetFloat("vAxisInput", vertInput);
        animator.SetFloat("hAxisInput", horizInput);
        if (Input.GetKey(KeyCode.Z))
        {
            // Set runBool to true if pressed
            animator.SetBool("runBool", true);
            Debug.Log("Run");
        }
        else
        {
            // Set runBool to false if not pressed
            animator.SetBool("runBool", false);
            Debug.Log("No Run");
        }
    }
}
