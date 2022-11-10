using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    // Start is called before the first frame update

    public int selectedpfp = 0, money=0;
    public string nume;
    public float speed = 0,volum=1;
    public int[] nrautostrada = new int[6], pretautostrada = new int[6], statusachievements = new int[2];
    public int[,] tilemapinfo = new int[251, 251], tilemapbuildings = new int[251, 251];
    public float gigaoras = 500, weightmare = 200, weightmic = 60, secunde = 0;
    public bool toggledemolare = false, togglecosturi = false, alreadyplayed=false;
    public Dictionary<string, int> infopolicejudete = new Dictionary<string, int>(), infostrazijudete = new Dictionary<string, int>(), infopumpjudete = new Dictionary<string, int>();

    public PlayerData(main player)
    {
        selectedpfp = player.selectedpfp;
        if (selectedpfp == null)
            selectedpfp = 0;
        money = player.money;
        if (money == null)
            money = 0;
        nume = player.nume;
        speed = player.speed;
        if (speed == null)
            speed = 0;
        volum = player.volum;
        if (volum == null)
            volum = 1;
        toggledemolare = player.toggledemolare;
        if (toggledemolare == null)
            toggledemolare = false;
        togglecosturi = player.togglecosturi;
        if (togglecosturi == null)
            togglecosturi = false;
        gigaoras = player.gigaoras;
        if (gigaoras == null)
            gigaoras = 500;
        weightmare = player.weightmare;
        if (weightmare == null)
            weightmare = 200;
        weightmic = player.weightmic;
        if (weightmic == null)
            weightmic = 60;
        secunde = player.secunde;
        if (secunde == null)
            secunde = 0;
        alreadyplayed = player.alreadyplayed;
        for (int i = 0; i <= 3; i++)
        {
            nrautostrada[i] = player.nrautostrada[i];
        }
        for (int i = 0; i <= 1; i++)
        {
            statusachievements[i] = player.statusachievements[i];
        }
        for (int i = 0; i <= 250; i++)
            for (int j = 0; j <= 250; j++)
                tilemapinfo[i, j] = player.tilemapinfo[i, j];
        for (int i = 0; i <= 250; i++)
            for (int j = 0; j <= 250; j++)
                tilemapbuildings[i, j] = player.tilemapbuildings[i, j];
        for (int i = 0; i <= 5; i++)
            pretautostrada[i] = player.pretautostrada[i];
        foreach (string k in player.infopolicejudete.Keys)
        {

            infopolicejudete.Add(k, player.infopolicejudete[k]);
        }
        foreach (string k in player.infostrazijudete.Keys)
        {

            infostrazijudete.Add(k, player.infostrazijudete[k]);
        }
        foreach (string k in player.infopumpjudete.Keys)
        {

            infopumpjudete.Add(k, player.infopumpjudete[k]);
        }
        if(pretautostrada[0]<=1)
        {
            pretautostrada[0] = 1500;
            pretautostrada[1] = 150000;
            pretautostrada[2] = 80000;
            pretautostrada[3] = 5000;
            pretautostrada[4] = 600000;
            pretautostrada[5] = 500000;
        }
    }

}