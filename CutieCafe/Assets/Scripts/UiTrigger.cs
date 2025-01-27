using UnityEngine;
using UnityEngine.Events;

public class UiTrigger : MonoBehaviour
{

    public UnityEvent enteredTrigger, exitedTrigger, stayInTrigger;
    public bool isInsideTrigger;
    public GameObject Uithing;
    public GameObject poopDrink;
    public MilkshakeTrigger milkshakeTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Uithing.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && milkshakeTrigger.noItems == true)
        {
            enteredTrigger.Invoke();
            isInsideTrigger = true;
            Uithing.SetActive(true);
            Debug.Log("Enter player no drink");
        }
        else if (other.CompareTag("Player") && milkshakeTrigger.noItems == false)
        {

            Uithing.SetActive(false);
            Debug.Log("Enter player with drink");
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && milkshakeTrigger.noItems == true)
        {
            stayInTrigger.Invoke();
            Debug.Log("Stay player");
        }
        else if (other.CompareTag("Player") && milkshakeTrigger.noItems == false)
        {

            Uithing.SetActive(false);
            Debug.Log("Enter player with drink");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitedTrigger.Invoke(); 
            isInsideTrigger = false; 
            Uithing.SetActive(false); 
            Debug.Log("Exit player");
        }
    }
}
