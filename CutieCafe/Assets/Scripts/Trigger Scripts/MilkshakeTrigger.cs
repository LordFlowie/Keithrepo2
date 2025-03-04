using UnityEngine;
using UnityEngine.Events;

public class MilkshakeTrigger : MonoBehaviour
{

    public UnityEvent enteredTrigger, exitedTrigger, stayInTrigger;
    public bool isInsideTrigger;
    [SerializeField] private GameObject[] images;
    public GameObject poopDrink;
    [SerializeField] private GameObject ingredient1, ingredient2, ingredient3, ingredient4, ingredient5, ingredient6;
    public bool greenItems, purpleItems, orangeItems, allItems, noItems;

    public Animator anim;

    void Start()
    {
        poopDrink.SetActive(false);
        greenItems = purpleItems = orangeItems = noItems = allItems = false;
        noItems = true;
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && noItems == true)
        {
            enteredTrigger.Invoke();
            FindDrinkCombo();
            isInsideTrigger = true;
            DisableAllImages();
            Debug.Log("Enter player MilkBlender");
            anim.SetBool("pickupItem", true);
        }
        else if (other.CompareTag("Player") && noItems == false)
        {
            poopDrink.SetActive(false);
            anim.SetBool("pickupItem", true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitedTrigger.Invoke();
            isInsideTrigger = false;
            anim.SetBool("pickupItem", false);
            Debug.Log("Exit player");
        }
    }

    public void FindDrinkCombo()
    {
         if (!ingredient1.activeSelf && !ingredient2.activeSelf && !ingredient3.activeSelf && !ingredient4.activeSelf && !ingredient5.activeSelf && !ingredient6.activeSelf)
        {
            noItems = true;
            poopDrink.SetActive(false);
        }
        if (ingredient1.activeSelf && ingredient2.activeSelf && !ingredient3.activeSelf && !ingredient4.activeSelf && !ingredient5.activeSelf && !ingredient6.activeSelf)
        {
            greenItems = true;
            poopDrink.SetActive(true);
            noItems = false;
        }
        else if (ingredient3.activeSelf && ingredient4.activeSelf && !ingredient1.activeSelf && !ingredient2.activeSelf && !ingredient5.activeSelf && !ingredient6.activeSelf)
        {
            purpleItems = true;
            poopDrink.SetActive(true);
            noItems = false;

        }
        else if (ingredient5.activeSelf && ingredient6.activeSelf && !ingredient3.activeSelf && !ingredient4.activeSelf && !ingredient1.activeSelf && !ingredient2.activeSelf)
        {
            orangeItems = true;
            poopDrink.SetActive(true);
            noItems = false;

        }
        else
        {
            allItems = true;
            poopDrink.SetActive(true);
            noItems = false;

        }
    }
    void DisableAllImages()
    {
        foreach (GameObject image in images)
        {
            image.SetActive(false);
        }
    }
}
