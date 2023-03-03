using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager : MonoBehaviour
{
    public Animator[] Animals; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(animationSequances());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator animationSequances() 
    {
        for(int i = 0; i<Animals.Length; i++)
        {
            Animals[i].enabled = true;
            yield return new WaitForSeconds(2.0f);
        }
        yield return null;
    }
}
