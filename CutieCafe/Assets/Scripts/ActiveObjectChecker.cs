using UnityEngine;
using System.Collections.Generic;


public class ActiveObjectChecker : MonoBehaviour
{
    [SerializeField] private GameObject ingredient1, ingredient2, ingredient3, ingredient4, ingredient5, ingredient6;
    public bool greenItems, purpleItems, orangeItems, allItems, noItems;

    private void Start()
    {
        greenItems = purpleItems = orangeItems = noItems = allItems = false;

    }
    void Update()
    {
        CheckImageStates();
    }

    void CheckImageStates()
    {
        
        if (ingredient1.activeSelf && ingredient2.activeSelf)
        {
            greenItems = true;
        }
        else if (ingredient3.activeSelf && ingredient4.activeSelf)
        {
            purpleItems = true;
        }
        else if (ingredient5.activeSelf && ingredient6.activeSelf)
        {
            orangeItems = true;
        }
        else if (!ingredient1.activeSelf && !ingredient2.activeSelf && !ingredient3.activeSelf && !ingredient4.activeSelf && !ingredient5.activeSelf && !ingredient6.activeSelf)
        {
            noItems = true;
        }
        else
        {
            allItems = true;
        }
    }

}
