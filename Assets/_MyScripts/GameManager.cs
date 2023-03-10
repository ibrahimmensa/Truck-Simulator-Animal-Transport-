using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("PreLoadings Game Env")]
    public GameObject Jungle;
    public GameObject Farm;
    public GameObject OffRoad;
    [Space()]

    [Header("PlayerRefrances")]
    public RCC_Camera Camera;
    public GameObject Player;
    public GameObject PlayerObj;
    [Space()]

    public GameObject P_Levelcomplete;
    public GameObject P_LevelFail;
    public GameObject P_Pause;
    public GameObject P_Loading;
    public GameObject P_BlackScreen;

    //levels
    int level;
    bool levelCom;
    //public Text Leveltxt;
   // public Text dubbleScore;
    public GameObject LevelsManagr;
    public GameObject LevelPosition;

    //coins
    //public Text Cointxt;

    //sound and music
    public GameObject SoundManager;
    public GameObject BG_MusicManager;
    // Start is called before the first frame update.
    private void OnEnable()
    {
        Camera.TPSDistance = 15f;
        Camera.TPSHeight = 7;
    }
    void Start()
    {
        PlayerPrefs.SetInt("Level", 1);
        if (PlayerPrefs.HasKey("Truck"))
        {
            Player = PlayerObj.transform.GetChild(PlayerPrefs.GetInt("Truck")).gameObject;
            Player.SetActive(true);
        }
        else
        {
            Player = PlayerObj.transform.GetChild(0).gameObject;
            Player.SetActive(true);
        }

        //OPen saved level or start with level 1
        if (PlayerPrefs.HasKey("Level"))
        {
            if (PlayerPrefs.GetInt("Level") > LevelsManagr.transform.childCount)
            {
                PlayerPrefs.SetInt("Level", 0);
            }
            LevelsManagr.transform.GetChild(PlayerPrefs.GetInt("Level")).gameObject.SetActive(true);
            Player.transform.position = LevelPosition.transform.GetChild(PlayerPrefs.GetInt("Level")).transform.position;
            Player.transform.rotation = LevelPosition.transform.GetChild(PlayerPrefs.GetInt("Level")).transform.rotation;
        }
        else
        {
            LevelsManagr.transform.GetChild(0).gameObject.SetActive(true);
            Player.transform.position = LevelPosition.transform.GetChild(0).transform.position;
            Player.transform.rotation = LevelPosition.transform.GetChild(0).transform.rotation;
            PlayerPrefs.SetInt("Level", 0);
        }


        //check vibration settings
        if (!PlayerPrefs.HasKey("Vibrate"))
        {
            PlayerPrefs.SetInt("Vibrate", 1);
        }


        //check Sound settings
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {
                SoundManager.SetActive(true);
            }
            else
            {
                SoundManager.SetActive(false);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
        }


        //check Music settings
        if (PlayerPrefs.HasKey("Music"))
        {
            if (PlayerPrefs.GetInt("Music") == 1)
            {
                BG_MusicManager.SetActive(true);
            }
            else
            {
                BG_MusicManager.SetActive(false);
            }

        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
        }

        //Cointxt.text = PlayerPrefs.GetInt("Coins").ToString();
        level = PlayerPrefs.GetInt("Level") + 1;
        //Leveltxt.text = "Level " + "- " + level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pauseBtn()
    {
        P_Pause.transform.Find("Coins").transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
        P_Pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void resumebtn()
    {
        P_Pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void levelComplete()
    {
        //AdsInitializer.Instance.ShowAdInterstitial();
        //GoogleAds.Instance.showInterstitial();
        levelCom = true;
        StartCoroutine(LevelCompleted());
    }
    public void levelFail()
    {
        //AdsInitializer.Instance.ShowAdInterstitial();
        StartCoroutine(LevelFailed());
    }
    public void Home()
    {
        //if (AdsInitializer.Instance)
        //{
        //    AdsInitializer.Instance.ShowAdInterstitial();
        //}
        if (levelCom)
        {
            Debug.Log("LevelComplete Home");

            if (level == LevelsManagr.transform.childCount)
            {
                PlayerPrefs.SetInt("Level", -1);
            }
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            levelCom = false;
        }
        else
        {
            Time.timeScale = 1;
            Debug.Log("Pause Home");
        }
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    public void NextLevel()
    {

        if (level == LevelsManagr.transform.childCount)
        {
            PlayerPrefs.SetInt("Level", -1);
        }
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene(2);
    }
    public int totl;
    IEnumerator LevelCompleted()
    {
        P_BlackScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        P_Levelcomplete.SetActive(true);
        P_BlackScreen.SetActive(false);
        totl = 20 + 5 * (PlayerPrefs.GetInt("Level") + 1);
        //dubbleScore.text = totl.ToString();
        if (PlayerPrefs.GetInt("Level") == 0 && PlayerPrefs.GetInt("Coins") == 0)
        {
            PlayerPrefs.SetInt("Coins", totl);
        }
        else
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + totl);
        }
        //P_Levelcomplete.transform.Find("Coins").transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
        Debug.Log("score is:" + PlayerPrefs.GetInt("Coins"));
        yield return null;
        StopCoroutine(LevelCompleted());
    }
    IEnumerator LevelFailed()
    {
        P_LevelFail.transform.Find("Coins").transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
        P_BlackScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        P_LevelFail.SetActive(true);
        P_BlackScreen.SetActive(false);
        yield return null;
        StopCoroutine(LevelFailed());
    }

}
