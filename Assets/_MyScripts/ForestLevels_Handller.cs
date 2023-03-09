using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestLevels_Handller : MonoBehaviour
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
    public void Back() { Handllers_Manager.Instance.switchMenu(Screens.Modes); }
    public void MissionBtn () { Debug.Log("Button pressed"); }
}
