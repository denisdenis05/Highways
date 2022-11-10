using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "loading")
        {
            PlayerData data = SaveLoading.LoadPlayer();
            if (data != null)
                SceneManager.LoadScene("main");
            else
                SceneManager.LoadScene("first_boot");


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
