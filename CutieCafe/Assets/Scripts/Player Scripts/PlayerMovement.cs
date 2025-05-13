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
        Vector2 direction = moveAction.ReadValue<Vector2>();

        if (direction.sqrMagnitude > 0.01f) 
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
            animator.SetBool("runBool", true);
            Debug.Log("Run");
        }
        else
        {
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
           
            verticalMovement = Input.GetAxis("Vertical");
            horizontalMovement = Input.GetAxis("Horizontal");
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

        if (col.gameObject.name == "Grass")
        {
            col.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            textUI.GetComponent<UITextAI_1>().Economy += 1;
        }
        else
        {
            if (col.gameObject.name == "AIBall")
            {
                Destroy(col.gameObject);
                textUI.GetComponent<UITextAI_1>().Economy -= 1;
            }
        }
    }

    public void Load(Vector3 position, Quaternion rotatingRotating)
    {
        transform.position = position;
        transform.rotation = rotatingRotating;
    }

}
