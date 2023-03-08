using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Screens
{
    Mainmenu,
    Garage,
    Settings,
    shop,
    Modes,
    Forest_Levels,
    Farm_Levels,
    Offroad_Levels
}
public class Handllers_Manager : Singleton<Handllers_Manager>
{

    [Space()]
    [Header("*IAP Panels")]


    //public GameObject UnlockAllCarsPOPUP;
    //public GameObject UnlockCareerLevelsPOPUP;
    //public GameObject UnlockTrolleyLevelsPOPUP;
    //public GameObject UnlockAllLevelsPOPUP;

    public static int Cars_IAP_Counter, Career_IAP_Counte, Trolley_IAP_Counte, AllLevels_IAP_Counte = 0;


    [Header("--Selection Settings--")]
    [Space()]


   

    [Space()]
    [Header("Others")]
    [Space()]
    public float totalCashEarned = 0;
    public Text totalCashEarnedText;
    public Text MtotalCashEarnedText;
    public GameObject errorMessage;

    [Header("Level Selection")]
    public GameObject[] lockedLevel;

    [Header("*Sound Settings")]
    public GameObject musicObj, SoundObj;
    [Header("====================")]
    [Header("*LoadingTimer")]
    public float loadingTimer = 0.0f;
    string car = "Car";
    public GameObject currentControls;
    public GameObject[] controlsBtn;
    
    //=============================================================================================//
    public MainMenu_Handller MainMenu_Handller;
    public Garage_Handller Garage_Handller;
    public Settings_Handller Settings_Handller;
    public Shop_Handller Shop_Handller;
    public Modes_Handller Modes_Handller;
    public ForestLevels_Handller ForestLevels_Handller;
    public FarmLevels_Handller FarmLevels_Handller;
    public OffroadLevels_Handller OffroadLevels_Handller;
    public Screens CurrentState;
    // Start is called before the first frame update
    void Start()
    {

        //==============================//
        switchMenu(Screens.Mainmenu);
    }

    // Update is called once per frame
    void Update()
    {
       
        //totalCashEarnedText.text = ((int)(totalCashEarned)).ToString();
        //MtotalCashEarnedText.text = ((int)(totalCashEarned)).ToString();
    }
    public void switchMenu(Screens CurrentState)
    {
        DisableAllPanels();
        switch (CurrentState)
        {
            case Screens.Mainmenu:
                MainMenu_Handller.gameObject.SetActive(true);
                CurrentState = Screens.Mainmenu;
                break;
            case Screens.Settings:
                Settings_Handller.gameObject.SetActive(true);
                CurrentState = Screens.Settings;
                break;
            case Screens.shop:
                Shop_Handller.gameObject.SetActive(true);
                CurrentState = Screens.shop;
                break;
            case Screens.Modes:
                Modes_Handller.gameObject.SetActive(true);
                CurrentState = Screens.Modes;
                break;
            case Screens.Forest_Levels:
                ForestLevels_Handller.gameObject.SetActive(true);
                CurrentState = Screens.Forest_Levels;
                break;
            case Screens.Farm_Levels:
                FarmLevels_Handller.gameObject.SetActive(true);
                CurrentState = Screens.Farm_Levels;
                break;
            case Screens.Offroad_Levels:
                OffroadLevels_Handller.gameObject.SetActive(true);
                CurrentState = Screens.Offroad_Levels;
                break;
            case Screens.Garage:
                Garage_Handller.gameObject.SetActive(true);
                CurrentState = Screens.Garage;
                break;
        }
    }
    private void DisableAllPanels()
    {
        MainMenu_Handller.gameObject.SetActive(false);
        Garage_Handller.gameObject.SetActive(false);
        Settings_Handller.gameObject.SetActive(false);
        Shop_Handller.gameObject.SetActive(false);
        Modes_Handller.gameObject.SetActive(false);
        ForestLevels_Handller.gameObject.SetActive(false);
        FarmLevels_Handller.gameObject.SetActive(false);
        OffroadLevels_Handller.gameObject.SetActive(false);
    }
}
