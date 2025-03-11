using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UITextAI_1 : MonoBehaviour
{
    //declare our state variables as simple types for now
    string playerName;
    int highScore;
    int currentLevel;
    //reference to a game object
    string spawnPoint;
    int health;
    int coins;
    //reference to UI Text Object
    TextMeshProUGUI scoreUI;
    //setup properties for all of our state variables

    public int HealthLevel
    {
        get { return health; }
        //the value keyword specifies the setter value passed in
        set { health = value; }
    }
    public int Economy
    {
        get { return coins; }
        //the value keyword specifies the setter value passed in
        set { coins = value; }
    }

    void Start()
    {
        playerName = "KeithO";
        highScore = 0;
        currentLevel = 1;
        spawnPoint = "beginning";
        health = 100;
        coins = 0;

        // Get the correct component type
        scoreUI = GetComponent<TextMeshProUGUI>();

        // If it's null, log an error to help debug
        if (scoreUI == null)
        {
            Debug.LogError("TextMeshProUGUI component not found! Make sure this script is attached to a UI Text object.");
        }
    }

    void Update()
    {
        if (scoreUI != null) // Ensure it's assigned before updating
        {
            scoreUI.text = 
                           //$"highScore: {highScore}\n" +
                           //$"currentLevel: {currentLevel}\n" +
                           //$"spawnPoint: {spawnPoint}\n" +
                           //$"health: {health}\n" +
                           $"coins: {coins}";
        }
    }
}


