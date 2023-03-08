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
    [Header("*Objects options")]
    [Space()]
    public GameObject[] objects;
    private GameObject activeObject;
    public int activeObjectIndex;


    [Header("*Selection Buttons and Texts")]

    public Text purchasePrice;
    public GameObject selectBtn;
    public GameObject purchaseBtn;
    public GameObject lockedImage;

    [Header("Vehicle Stats")]
    public Text vehicleName;
    public Slider enigneVal;
    public Slider accValue;
    public Slider handlingValue;
    public Slider brakesVal;

    float e_Val, a_Val, h_Val, b_Val;

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



    float timeElapsed;
    float lerpDuration = 0.2f;



    private float E_CV, E_PV,
        A_CV, A_PV,
        H_CV, H_PV,
        B_CV, B_PV = 0;
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
        activeObjectIndex = PlayerPrefs.GetInt("CarSelected");
        objects[activeObjectIndex].SetActive(true);

        //E_CV = objects[activeObjectIndex].GetComponent<CarsValues>().engine / 3500;
        //A_CV = objects[activeObjectIndex].GetComponent<CarsValues>().accleration / 30;
        //H_CV = objects[activeObjectIndex].GetComponent<CarsValues>().handling / 50;
        //B_CV = objects[activeObjectIndex].GetComponent<CarsValues>().brakes / 2000;
        //==============================//
        switchMenu(Screens.Mainmenu);
    }

    // Update is called once per frame
    void Update()
    {
    //    if (timeElapsed < lerpDuration)
    //    {
    //        e_Val = Mathf.Lerp(E_PV, E_CV, timeElapsed / lerpDuration);
    //        a_Val = Mathf.Lerp(A_PV, A_CV, timeElapsed / lerpDuration);
    //        h_Val = Mathf.Lerp(H_PV, H_CV, timeElapsed / lerpDuration);
    //        b_Val = Mathf.Lerp(B_PV, B_CV, timeElapsed / lerpDuration);
    //        timeElapsed += Time.deltaTime;
    //    }
    //    else
    //    {
    //        e_Val = E_CV;
    //        a_Val = A_CV;
    //        h_Val = H_CV;
    //        b_Val = B_CV;

    //    }

    //    enigneVal.value = e_Val;
    //    accValue.value = a_Val;
    //    handlingValue.value = h_Val;
    //    brakesVal.value = b_Val;

    //    if (PlayerPrefs.GetInt(car + activeObjectIndex) == 0)
    //    {
    //        purchasePrice.gameObject.SetActive(true);
    //        selectBtn.SetActive(false);
    //        purchaseBtn.SetActive(true);
    //        lockedImage.SetActive(true);
    //    }
    //    else
    //    {
    //        purchasePrice.gameObject.SetActive(false);
    //        selectBtn.SetActive(true);
    //        purchaseBtn.SetActive(false);
    //        lockedImage.SetActive(false);
    //    }
    //    totalCashEarnedText.text = ((int)(totalCashEarned)).ToString();
    //    MtotalCashEarnedText.text = ((int)(totalCashEarned)).ToString();
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
    public void _Next()
    {
        timeElapsed = 0;
        objects[activeObjectIndex].SetActive(false);
        //E_PV = enigneVal.value;
        //A_PV = objects[activeObjectIndex].GetComponent<CarsValues>().accleration / 30;
        //H_PV = objects[activeObjectIndex].GetComponent<CarsValues>().handling / 50;
        //B_PV = objects[activeObjectIndex].GetComponent<CarsValues>().brakes / 2000;
        activeObjectIndex++;
        if (activeObjectIndex >= objects.Length)
        {
            activeObjectIndex = 0; // for car selection moving the car selection index forward to see the next car
        }
        objects[activeObjectIndex].SetActive(true);

        //E_CV = objects[activeObjectIndex].GetComponent<CarsValues>().engine / 3500;
        //A_CV = objects[activeObjectIndex].GetComponent<CarsValues>().accleration / 30;
        //H_CV = objects[activeObjectIndex].GetComponent<CarsValues>().handling / 50;
        //B_CV = objects[activeObjectIndex].GetComponent<CarsValues>().brakes / 2000;
       // errorMessage.SetActive(false);
    }

    public void _Previous()
    {
        timeElapsed = 0;
        objects[activeObjectIndex].SetActive(false);
        //E_PV = enigneVal.value;
        //A_PV = objects[activeObjectIndex].GetComponent<CarsValues>().accleration / 30;
        //H_PV = objects[activeObjectIndex].GetComponent<CarsValues>().handling / 50;
        //B_PV = objects[activeObjectIndex].GetComponent<CarsValues>().brakes / 2000;
        activeObjectIndex--;
        if (activeObjectIndex < 0)
        {
            activeObjectIndex = objects.Length - 1; // for car selection moving the scroll backward to see the previous car
        }
        objects[activeObjectIndex].SetActive(true);

        //E_CV = objects[activeObjectIndex].GetComponent<CarsValues>().engine / 3500;
        //A_CV = objects[activeObjectIndex].GetComponent<CarsValues>().accleration / 30;
        //H_CV = objects[activeObjectIndex].GetComponent<CarsValues>().handling / 50;
        //B_CV = objects[activeObjectIndex].GetComponent<CarsValues>().brakes / 2000;
       // errorMessage.SetActive(false);
    }
}
