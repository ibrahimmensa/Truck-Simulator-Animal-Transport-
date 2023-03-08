using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garage_Handller : MonoBehaviour
{
    public GameObject Garage;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Garage.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Back() 
    {
        Handllers_Manager.Instance.switchMenu(Screens.Mainmenu);
        Garage.SetActive(false);
    }
    public void selectBtn() 
    { 
        Handllers_Manager.Instance.switchMenu(Screens.Modes);
        Garage.SetActive(false);

    }
}
