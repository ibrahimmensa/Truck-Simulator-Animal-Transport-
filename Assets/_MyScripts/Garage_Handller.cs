using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garage_Handller : MonoBehaviour
{
    public GameObject Garage;

    private float E_CV, E_PV,
        A_CV, A_PV,
        H_CV, H_PV,
        B_CV, B_PV = 0;

    [Header("*Objects options")]
    [Space()]
    public GameObject[] objects;
    private GameObject activeObject;
    public int activeObjectIndex;


    float timeElapsed;
    float lerpDuration = 0.2f;

    [Header("*Selection Buttons and Texts")]

    public Text purchasePrice;
    public GameObject SelectBtn;
    public GameObject purchaseBtn;
    public GameObject lockedImage;

    [Header("Vehicle Stats")]
    public Text vehicleName;
    public Slider enigneVal;
    public Slider accValue;
    public Slider handlingValue;
    //public Slider brakesVal;

    float e_Val, a_Val, h_Val;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Garage.SetActive(true);
    }
    void Start()
    {

        activeObjectIndex = PlayerPrefs.GetInt("CarSelected");
        objects[activeObjectIndex].SetActive(true);

        E_CV = objects[activeObjectIndex].GetComponent<CarsValues>().engine / 3500;
        A_CV = objects[activeObjectIndex].GetComponent<CarsValues>().accleration / 30;
        H_CV = objects[activeObjectIndex].GetComponent<CarsValues>().handling / 50;
        B_CV = objects[activeObjectIndex].GetComponent<CarsValues>().brakes / 2000;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Car0", 1);
        /*Selection Setting From here*/
        if (Input.GetKey(KeyCode.L))
        {
            PlayerPrefs.SetInt("Car0", 1);
            PlayerPrefs.SetInt("Car1", 0);
            PlayerPrefs.SetInt("Car2", 0);
            PlayerPrefs.SetInt("Car3", 0);
            PlayerPrefs.SetInt("Car4", 0);
            PlayerPrefs.SetInt("Car5", 0);
            PlayerPrefs.SetInt("Car6", 0);
            PlayerPrefs.SetInt("Car7", 0);
            PlayerPrefs.SetFloat("TotalCashEarned", 0);
            PlayerPrefs.SetInt("TotalXpsEarned", 0);
        }

        purchasePrice.text = (objects[activeObjectIndex].GetComponent<CarsValues>().price).ToString();
        if (timeElapsed < lerpDuration)
        {
            e_Val = Mathf.Lerp(E_PV, E_CV, timeElapsed / lerpDuration);
            a_Val = Mathf.Lerp(A_PV, A_CV, timeElapsed / lerpDuration);
            h_Val = Mathf.Lerp(H_PV, H_CV, timeElapsed / lerpDuration);
            //b_Val = Mathf.Lerp(B_PV, B_CV, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            e_Val = E_CV;
            a_Val = A_CV;
            h_Val = H_CV;
            //b_Val = B_CV;

        }

        enigneVal.value = e_Val;
        accValue.value = a_Val;
        handlingValue.value = h_Val;
        ///brakesVal.value = b_Val;

        if (PlayerPrefs.GetInt("Car" + activeObjectIndex) == 0)
        {
            purchasePrice.gameObject.SetActive(true);
            SelectBtn.GetComponent<Button>().interactable = false;
            purchaseBtn.GetComponent<Button>().interactable  = true;
            lockedImage.SetActive(true);
        }
        else
        {
            purchasePrice.gameObject.SetActive(false);
            SelectBtn.GetComponent<Button>().interactable = true;
            purchaseBtn.GetComponent<Button>().interactable = false;
            lockedImage.SetActive(false);
        }
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
    public void _Next()
    {
        timeElapsed = 0;
        objects[activeObjectIndex].SetActive(false);
        E_PV = enigneVal.value;
        A_PV = objects[activeObjectIndex].GetComponent<CarsValues>().accleration / 30;
        H_PV = objects[activeObjectIndex].GetComponent<CarsValues>().handling / 50;
        B_PV = objects[activeObjectIndex].GetComponent<CarsValues>().brakes / 2000;
        activeObjectIndex++;
        if (activeObjectIndex >= objects.Length)
        {
            activeObjectIndex = 0; // for car selection moving the car selection index forward to see the next car
        }
        objects[activeObjectIndex].SetActive(true);

        E_CV = objects[activeObjectIndex].GetComponent<CarsValues>().engine / 3500;
        A_CV = objects[activeObjectIndex].GetComponent<CarsValues>().accleration / 30;
        H_CV = objects[activeObjectIndex].GetComponent<CarsValues>().handling / 50;
        B_CV = objects[activeObjectIndex].GetComponent<CarsValues>().brakes / 2000;
        // errorMessage.SetActive(false);
    }

    public void _Previous()
    {
        timeElapsed = 0;
        objects[activeObjectIndex].SetActive(false);
        E_PV = enigneVal.value;
        A_PV = objects[activeObjectIndex].GetComponent<CarsValues>().accleration / 30;
        H_PV = objects[activeObjectIndex].GetComponent<CarsValues>().handling / 50;
        B_PV = objects[activeObjectIndex].GetComponent<CarsValues>().brakes / 2000;
        activeObjectIndex--;
        if (activeObjectIndex < 0)
        {
            activeObjectIndex = objects.Length - 1; // for car selection moving the scroll backward to see the previous car
        }
        objects[activeObjectIndex].SetActive(true);

        E_CV = objects[activeObjectIndex].GetComponent<CarsValues>().engine / 3500;
        A_CV = objects[activeObjectIndex].GetComponent<CarsValues>().accleration / 30;
        H_CV = objects[activeObjectIndex].GetComponent<CarsValues>().handling / 50;
        B_CV = objects[activeObjectIndex].GetComponent<CarsValues>().brakes / 2000;
        // errorMessage.SetActive(false);
    }
}
