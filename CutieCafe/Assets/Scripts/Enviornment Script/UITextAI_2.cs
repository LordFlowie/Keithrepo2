using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UITextAI_2 : MonoBehaviour
{
    //declare our state variables as simple types for now
    string playerName;
    int highScore;
    int currentLevel;
    //reference to a game object
    int health;
    public int coins;
    //reference to UI Text Object
    TextMeshProUGUI scoreUI;


    public DataStoringObject dataStoringObject; // ← THIS is the fix
    public DataSaveLoad dataSaveLoad;

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
        playerName = "KittyCat";
        highScore = 0;
        currentLevel = 1;

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
       /* if (scoreUI != null && dataStoringObject != null)
        {
            scoreUI.text = $"coins: {dataStoringObject.money}";
        }*/

    }
    public void Load(int money)
    {
        coins = money;
    }
}

