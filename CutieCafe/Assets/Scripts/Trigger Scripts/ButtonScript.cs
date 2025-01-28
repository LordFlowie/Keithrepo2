using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject pic;


    public void Trigger()
    {
        if (pic.activeInHierarchy == false)
        {
            pic.SetActive(true);

        }
        else
        {
            pic.SetActive(false);
        }
    }
}