using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UITextAI_1 : MonoBehaviour
{

    string spawnPoint;
    int health;
    int coins;
    
    TextMeshProUGUI scoreUI;
    

    public int HealthLevel
    {
        get { return health; }
        set { health = value; }
    }
    public int Economy
    {
        get { return coins; }
        set { coins = value; }
    }

    void Start()
    {

        spawnPoint = "beginning";
        health = 100;
        coins = 0;

        scoreUI = GetComponent<TextMeshProUGUI>();

        if (scoreUI == null)
        {
            Debug.LogError("TextMeshProUGUI component not found! Make sure this script is attached to a UI Text object.");
        }
    }

    void Update()
    {
        if (scoreUI != null) 
        {
            scoreUI.text = 
                          
                           $"Berries: {coins}";
        }
    }
}


