using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    Animator animator;
    float vertInput;
    float horizInput;

    float verticalMovement;
    float horizontalMovement;

    public GameObject textUI;

    [SerializeField] float speed = 5;

    public static GameObject player; 
    public DataSaveLoad dataSaveLoad = player.AddComponent<DataSaveLoad>();
    UITextAI_2 uiText22;

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
        if (Keyboard.current[Key.P].wasPressedThisFrame)
        {
            dataSaveLoad.SaveMethod(transform.position.x, transform.position.y, transform.position.z, transform.rotation);
            dataSaveLoad.SaveMoney(uiText22.dataStoringObject.money);
        }
        if (Keyboard.current[Key.L].wasPressedThisFrame)
        {
            dataSaveLoad.Load();
        }
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
        //DELETING PLAYER OBJ
        if (textUI.GetComponent<UITextAI_1>().HealthLevel <= 0)
        {
            // MonoBehaviour has a gameObject property for the current game object
            //Destroy(gameObject);
            
        }
        else
        {
            // Get the input values for the horizontal and vertical axes
            verticalMovement = Input.GetAxis("Vertical");
            horizontalMovement = Input.GetAxis("Horizontal");
            // Now a compound if statement to determine the direction of the vector
            Vector3 myDirectionVector = new Vector3();
            if (verticalMovement > 0)
            {
                myDirectionVector = Vector3.forward * verticalMovement;
            }
            else if (verticalMovement < 0)
            {
                myDirectionVector = Vector3.back * -verticalMovement;
            }
            else if (horizontalMovement > 0)
            {
                myDirectionVector = Vector3.right * horizontalMovement;
            }
            else if (horizontalMovement < 0)
            {
                myDirectionVector = Vector3.left * -horizontalMovement;
            }
            // Add force to the sphere to move it-
            GetComponent<Rigidbody>().AddForce(myDirectionVector / 5, ForceMode.Impulse);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        // the collision will return the gameObject itself- the name property allows different
        //hitting a cube benefits the economy!
        if (col.gameObject.name == "Grass")
        {// change the colour of the object
            col.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            //now update the state data
            textUI.GetComponent<UITextAI_1>().Economy += 1;
        }
        else
        {//hitting anything else is bad for our health!!
            if (col.gameObject.name == "AIBall")
            {
                Destroy(col.gameObject);
                //reduce health level
                textUI.GetComponent<UITextAI_1>().Economy -= 1;
            }
        }//end of collision condition
    }

    public void Load(Vector3 position, Quaternion rotatingRotating)
    {
        transform.position = position;
        transform.rotation = rotatingRotating;
    }

}
