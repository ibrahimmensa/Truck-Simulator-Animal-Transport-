using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Handller : MonoBehaviour
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
    public void Play()
    {
        Handllers_Manager.Instance.switchMenu(Screens.Garage);
    }
    public void Settings() { }
    public void Shop() { }
    public void MoreGames() { }
    public void RateUs() { }
    public void pillowFight() { }
    public void bikeRace() { }
    public void FreeCoins() { }
}
