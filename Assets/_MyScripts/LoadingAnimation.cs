using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject Loading;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Gamplay()
    {
        Loading.SetActive(false);
    }
}
