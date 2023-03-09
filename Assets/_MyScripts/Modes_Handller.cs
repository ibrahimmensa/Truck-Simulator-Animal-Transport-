using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modes_Handller : MonoBehaviour
{
    private void OnEnable()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Back() { Handllers_Manager.Instance.switchMenu(Screens.Garage); }
    public void ForestMode()
    {
        Handllers_Manager.Instance.switchMenu(Screens.Forest_Levels);
    }
    public void FarmMode() { }
    public void OffRoadMode() { }
    public void CityMode() { }
}
