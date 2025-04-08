using UnityEngine;

[CreateAssetMenu(fileName = "DataStoringObject", menuName = "Scriptable Objects/DataStoringObject")]
public class DataStoringObject : ScriptableObject
{
    public string playerName;
    public string milkshakeType;
    public int money;
    public int level;
    public Vector3 position;
    public Quaternion rotation;

}
