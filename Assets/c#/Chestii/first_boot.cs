using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class first_boot : MonoBehaviour
{
    string nume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void erase()
    {
        GameObject.Find("errortext").GetComponent<Text>().text = " ";

    }

    public void submit()
    {
        nume = GameObject.Find("numeintrodus").GetComponent<Text>().text;
        if (nume.Length > 18)
            GameObject.Find("errortext").GetComponent<Text>().text = "Numele introdus este prea lung.";
        else
        {
            GameObject.Find("Canvas").GetComponent<main>().nume = nume;
            GameObject.Find("Canvas").GetComponent<main>().Save();
            SceneManager.LoadScene("main");
        }
    }
}
