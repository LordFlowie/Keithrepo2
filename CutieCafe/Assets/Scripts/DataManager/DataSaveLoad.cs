using UnityEngine;
using System.IO;
public class DataSaveLoad : MonoBehaviour
{
    
    public DataStoringObject dataStoringObject;
    public PlayerMovement playerMovement;
    public UITextAI_2 uiText2;
    private float posX, posY, posZ;
    private string playerName;
    private string milkshakeType;
    private int money;
    private int level;
    private Vector3 position;
    private Quaternion rotation;

    [System.Serializable]
    public class SavingPoo
    {
        /*public string playerName;
        public string milkshakeType;
        
        public int level;*/
        public Vector3 position;
        public Quaternion rotation;
        public int money;
    }

    private string SaveFileLocation()
    {
        string saveFileLocation = Application.persistentDataPath + "/savedatafile.poo";
        return saveFileLocation;
    }

    public void SaveMethod(float positionX, float positionY, float positionZ, /* string playerNaming, string Milkshakle,  int levelLevel,*/ Quaternion rotatingRotating)
    {
        dataStoringObject.position = new Vector3(positionX, positionY, positionZ);
        /*dataStoringObject.playerName = playerNaming;
        dataStoringObject.milkshakeType = Milkshakle;
        
        dataStoringObject.level = levelLevel;*/
        
        dataStoringObject.rotation = rotatingRotating;

        SavingPoo savingPoo = new SavingPoo
        {
            /*playerName = playerNaming,
            milkshakeType = Milkshakle,
            
            level = levelLevel,*/
            
            position = new Vector3(positionX, positionY, positionZ),
            rotation = rotatingRotating

        };
        File.WriteAllText(SaveFileLocation(), JsonUtility.ToJson(savingPoo));
    }
    public void SaveMoney(int moneyMoney)
    {
        dataStoringObject.money = moneyMoney;
        SavingPoo savingPoo = new SavingPoo
        {
            money = moneyMoney
        };
        File.WriteAllText(SaveFileLocation(), JsonUtility.ToJson(savingPoo));
    }
    public void Load()
    {
        SavingPoo loadingPoo = JsonUtility.FromJson<SavingPoo>(File.ReadAllText(SaveFileLocation()));
        playerMovement.Load(loadingPoo.position, loadingPoo.rotation);
        uiText2.Load(loadingPoo.money);
    }

}
