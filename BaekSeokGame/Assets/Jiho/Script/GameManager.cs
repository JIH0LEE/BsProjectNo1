using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuUI;
    bool isActive;
    public GameObject menuButton;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    public void saveData()
    {
        DataController.Instance.SaveGameData();
    }
    public void changeActive()
    {
        isActive = !isActive;   
    }
    void Update()
    {
       
            menuUI.SetActive(isActive);
        
    }
}
