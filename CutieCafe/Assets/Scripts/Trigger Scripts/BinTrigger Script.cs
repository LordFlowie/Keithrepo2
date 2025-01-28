using UnityEngine;
using UnityEngine.Events;

public class BinTriggerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UnityEvent enteredTrigger, exitedTrigger, stayInTrigger;
    public bool isInsideTrigger;
    [SerializeField] private GameObject[] images;
    public GameObject poopDrink;
    public MilkshakeTrigger milkshakeTrigger;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enteredTrigger.Invoke();
            isInsideTrigger = true;
            poopDrink.SetActive(false);
            DisableAllImages();
            DisableAllComponents();
            Debug.Log("Enter player Bin");
        }
    }
    void DisableAllImages()
    {
        foreach (GameObject image in images)
        {
            image.SetActive(false);
        }
    }
    public void DisableAllComponents()
    {
        milkshakeTrigger.greenItems = milkshakeTrigger.purpleItems = milkshakeTrigger.orangeItems = milkshakeTrigger.allItems = false;
        milkshakeTrigger.noItems = true;

    }

}
