using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class changepfp : MonoBehaviour
{
    main script;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("Canvas").GetComponent<main>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change(int i)
    {
        script.selectedpfp = i;
        GameObject.Find("Poza profil change").GetComponent<Image>().sprite = script.pfp[i];
        GameObject.Find("Poza profil buton").GetComponent<Image>().sprite = script.pfp[i];
        script.Save();
    }
}
