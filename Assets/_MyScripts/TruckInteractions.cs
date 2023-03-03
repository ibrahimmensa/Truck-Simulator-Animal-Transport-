using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckInteractions : MonoBehaviour
{

    public bool IsGamePlay;

    private void OnEnable()
    {
        IsGamePlay = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LevelCom"))
        {
            if (!IsGamePlay)
                return;
            IsGamePlay = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            if (PlayerPrefs.GetInt("Vibrate") == 1)
            {
                Handheld.Vibrate();
            }
            //collision.collider.enabled = false;
            GameManager.Instance.Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GameManager.Instance.levelComplete();
        }
    }
}
