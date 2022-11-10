using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class main : MonoBehaviour
{
    public string nume;
    public int selectedpfp = 0, money=0;
    public Sprite[] pfp,achievements;
    public Tile[] terraintype;
    public int[] nrautostrada = new int[6], pretautostrada = new int[6], statusachievements= new int[2];
    // de la -100 la 200 maxim matricea
    public int[,] tilemapinfo = new int[251, 251], tilemapbuildings = new int[251, 251];
    public Dictionary<string, int> infopolicejudete = new Dictionary<string, int>(), infostrazijudete = new Dictionary<string, int>(), infopumpjudete = new Dictionary<string, int>();
    public float[,] orase = new float[251, 251];
    public int[,] pinpointorase = new int[251, 251];
    public int[,] weight_final = new int[251, 251];
    public int autostraziconstruite = 0, cladiriconstruite=0;
    public float[,] lista_orase = new float[4, 251];
    public float[,] incomepath = new float[251, 251];
    public int xlistaorase, firsttimeparcurs=0;
    public bool buildmode = false, toggledemolare = false, togglecosturi = false, firsttime = false;
    public float speed = 0,volum=0;
    float autosavetimer = 20,trafictimervar= 120;
    bool initializat = false, alreadyplayed = false;
    public float gigaoras=500,weightmare=200, weightmic=60, secunde=0,minutejoc=0,orejoc=0,zilejoc=0;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "main")
            initializare();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "main" && initializat==true)
        {
            time();
            autosave();
            trafictimer();
        }
    }


    void time()
    {
        secunde += Time.deltaTime;
        if (10 * (int)(secunde/2) > minutejoc)
        {F
            minutejoc = 10 * (int)(secunde/2);
            if ((int)(minutejoc / 60) >= orejoc)
            {
                orejoc = (int)(minutejoc / 60);
                minutejoc = minutejoc % 60;
            }
            if ((int)(orejoc / 24) >= zilejoc)
            {
                if (GameObject.Find("ziafis").GetComponent<Text>().text != ((int)(orejoc / 24)).ToString())
                {
                    GameObject.Find("Canvas").GetComponent<path>().trafic();
                    bani();

                }
                zilejoc = (int)(orejoc / 24);
                orejoc = orejoc % 24;
            }
            GameObject.Find("oraafis").GetComponent<Text>().text=orejoc.ToString("00")+":"+minutejoc.ToString("00");
            GameObject.Find("ziafis").GetComponent<Text>().text=zilejoc.ToString();

        }
    }


    void bani()
    {
        money += 10000;

        float income = 0;
        for (int x = 1; x <= 250; x++)
            for (int y = 1; y <= 250; y++)
                income += incomepath[x, y];
        money += (int)(income);
        if (money <= 1000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + money.ToString();
        else if (money < 1000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000).ToString() + "k";
        else if (money < 1000000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000000).ToString() + "M";
        else if (money < 1000000000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000000000).ToString() + "B";
        else if (money < 1000000000000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000000000000).ToString() + "T";

        if (money > 100000 && statusachievements[0] == 0)
        {
            statusachievements[0] = 1;
            GameObject.Find("Canvas").GetComponent<lerp>().newachievement(3);
        }
        else if (money > 100000000 && statusachievements[0] == 1)
        {
            statusachievements[0] = 2;
            GameObject.Find("Canvas").GetComponent<lerp>().newachievement(4);
        }
        else if (money > 100000000 && statusachievements[0] == 2)
        {
            statusachievements[0] = 3;
            GameObject.Find("Canvas").GetComponent<lerp>().newachievement(5);
        }


    }

    void autosave()
    {

        if (autosavetimer > 0)
        {
            autosavetimer -= Time.deltaTime;
        }
        else
        {
            Save();
            autosavetimer = 20;
            GameObject.Find("Canvas").GetComponent<path>().trafic();
        }
    }

    void trafictimer()
    {

        if (trafictimervar > 0)
        {
            trafictimervar -= Time.deltaTime;
        }
        else
        {
            trafictimervar = 120;
            gigaoras = gigaoras + 0.25f;
            weightmare = weightmare + 0.1f;
            weightmic = weightmic + 0.03f;
            GameObject.Find("Canvas").GetComponent<path>().FunctiedeStart();
            Save();
        }
    }

    void recover()
    {
        PlayerData data = SaveLoading.LoadPlayer();
        if (data != null)
        {
            selectedpfp = data.selectedpfp;
            money = data.money;
            nume = data.nume;
            speed = data.speed;
            alreadyplayed = data.alreadyplayed;
            secunde = data.secunde;
            toggledemolare = data.toggledemolare;
            toggledemolare = data.toggledemolare;
            weightmic = data.weightmic;
            weightmare = data.weightmare;
            gigaoras = data.gigaoras;
            foreach (string k in data.infopolicejudete.Keys)
            {

                infopolicejudete.Add(k, data.infopolicejudete[k]);
                cladiriconstruite += data.infopolicejudete[k];
            }
            foreach (string k in data.infostrazijudete.Keys)
            {

                infostrazijudete.Add(k, data.infostrazijudete[k]);
                autostraziconstruite += data.infostrazijudete[k];

            }
            foreach (string k in data.infopumpjudete.Keys)
            {

                infopumpjudete.Add(k, data.infopumpjudete[k]);
                cladiriconstruite += data.infopumpjudete[k];
            }
            for (int i = 0; i <= 5; i++)
                nrautostrada[i] = data.nrautostrada[i];
            for (int i = 0; i <= 5; i++)
                pretautostrada[i] = data.pretautostrada[i];
            for (int i = 0; i <= 1; i++)
                statusachievements[i] = data.statusachievements[i];
            for (int i = 0; i <= 250; i++)
                for (int j = 0; j <= 250; j++)
                    tilemapinfo[i, j] = data.tilemapinfo[i, j];
            for (int i = 0; i <= 250; i++)
                for (int j = 0; j <= 250; j++)
                    tilemapbuildings[i, j] = data.tilemapbuildings[i, j];
        }     
    }

    public void refreshstats(int i)
    {
        if (i == 0)
            GameObject.Find("afisarestats").GetComponent<Text>().text = "Km de autostrada: " + autostraziconstruite.ToString() +
                "\nCladiri construite: " + cladiriconstruite.ToString();
        else
            GameObject.Find("afisarestats").GetComponent<Text>().text = "";

    }

    public void Save()
    {
        SaveLoading.SavePlayer(this);
    }

    void initializare()
    {
        int x = 0;
        pretautostrada[0] = 1500;
        pretautostrada[1] = 150000;
        pretautostrada[2] = 80000;
        pretautostrada[3] = 5000;
        pretautostrada[4] = 600000;
        pretautostrada[5] = 500000;

        recover();
        for (int i = 0; i <= 250; i++)
            for (int j = 0; j <= 250; j++)
                if (GameObject.Find("tilemaporase").GetComponent<Tilemap>().GetSprite(new Vector3Int(i, j, 0)) != null)
                {
                    if (GameObject.Find("tilemaporase").GetComponent<Tilemap>().GetSprite(new Vector3Int(i, j, 0)).name == "giga")
                    {
                        pinpointorase[i, j] = 1;
                        orase[i, j] = gigaoras;
                        x++;
                        lista_orase[1, x] = i;
                        lista_orase[2, x] = j;
                        lista_orase[3, x] = gigaoras;
                    }
                    else if (GameObject.Find("tilemaporase").GetComponent<Tilemap>().GetSprite(new Vector3Int(i, j, 0)).name == "PinpointLocatii_0")
                    {
                        pinpointorase[i, j] = 1;
                        orase[i, j] = weightmare;
                        x++;
                        lista_orase[1, x] = i;
                        lista_orase[2, x] = j;
                        lista_orase[3, x] = weightmare;
                    }
                    else if (GameObject.Find("tilemaporase").GetComponent<Tilemap>().GetSprite(new Vector3Int(i, j, 0)).name == "PinpointLocatii_3")
                    {
                        pinpointorase[i, j] = 2;
                        orase[i, j] = weightmic;
                        x++;
                        lista_orase[1, x] = i;
                        lista_orase[2, x] = j;
                        lista_orase[3, x] = weightmic;
                    }
                }
        xlistaorase = x;
        GameObject.Find("Canvas").GetComponent<path>().FunctiedeStart();
        GameObject.Find("Poza profil change").GetComponent<Image>().sprite = pfp[selectedpfp];
        GameObject.Find("Poza profil buton").GetComponent<Image>().sprite = pfp[selectedpfp];
        if (money <= 1000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + money.ToString();
        else if (money < 1000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000).ToString() + "k";
        else if (money < 1000000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000000).ToString() + "M";
        else if (money < 1000000000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000000000).ToString() + "B";
        else if (money < 1000000000000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000000000000).ToString() + "T";
        GameObject.Find("NumeDisplay").GetComponent<Text>().text = nume;
        GameObject.Find("speedslider").GetComponent<Slider>().value = speed;
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = volum;
        GameObject.Find("Canvas").GetComponent<lerp>().speed = speed;
        for (int i = 0; i <= 5; i++)
            GameObject.Find("nrbenzi" + (i + 1).ToString()).GetComponent<Text>().text = "Nr detinute: " + nrautostrada[i].ToString();
        for (int i = 0; i <= 5; i++)
        {
            if (pretautostrada[i] < 1000)
                GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara ($" + pretautostrada[i].ToString() + ")";
            else if (pretautostrada[i] < 1000000)
                GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara ($" + ((int)(pretautostrada[i] / 1000)).ToString() + "k)";
            else if (pretautostrada[i] < 1000000000)
                GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara ($" + ((int)(pretautostrada[i] / 1000000)).ToString() + "M)";
            else if (pretautostrada[i] < 1000000000000)
                GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara ($" + ((int)(pretautostrada[i] / 1000000000)).ToString() + "B)";
            else if (pretautostrada[i] < 1000000000000000)
                GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara ($" + ((int)(pretautostrada[i] / 1000000000000)).ToString() + "T)";
        }
        for(int i=6;i<=9;i++)
        {
            if (pretautostrada[i - 6] < 1000)
                GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara 10 (10x$" + pretautostrada[i - 6].ToString() + ")";
            else if (pretautostrada[i - 6] < 1000000)
                GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara 10 (10x$" + ((int)(pretautostrada[i - 6] / 1000)).ToString() + "k)";
            else if (pretautostrada[i - 6] < 1000000000)
                GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara 10 (10x$" + ((int)(pretautostrada[i - 6] / 1000000)).ToString() + "M)";
            else if (pretautostrada[i - 6] < 1000000000000)
                GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara 10 (10x$" + ((int)(pretautostrada[i - 6] / 1000000000)).ToString() + "B)";
            else if (pretautostrada[i - 6] < 1000000000000000)
                GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara 10 (10x$" + ((int)(pretautostrada[i - 6] / 1000000000000)).ToString() + "T)";
        }
        for (int i = 0; i <= 250; i++)
            for (int j = 0; j <= 250; j++)
            {
                if (tilemapinfo[i, j] > 0)
                    GameObject.Find("butondragbenzi1").GetComponent<drag>().updatetile(new Vector3Int(i, j), tilemapinfo[i, j], GameObject.Find("TilemapHighway").GetComponent<Tilemap>());
                if (tilemapbuildings[i, j] == 5)
                    GameObject.Find("tilemaporase").GetComponent<Tilemap>().SetTile(new Vector3Int(i, j), GameObject.Find("butondragbenzi1").GetComponent<drag>().politiepump[0]);
                if (tilemapbuildings[i, j] == 6)
                    GameObject.Find("tilemaporase").GetComponent<Tilemap>().SetTile(new Vector3Int(i, j), GameObject.Find("butondragbenzi1").GetComponent<drag>().politiepump[1]);
            }
        initializat = true;
        if (alreadyplayed == false)
            tutorial();
    }

    public int scadeautostrada(int i)
    {
        if (nrautostrada[i] == 0)
            return 0;
        else
        {
            nrautostrada[i]--;
            GameObject.Find("nrbenzi"+(i+1).ToString()).GetComponent<Text>().text = "Nr detinute: " + nrautostrada[i].ToString();
            return 1;
        }

    }

    void tutorial()
    {

        firsttimeparcurs = 0;


    }

    public void skiptutorial()
    {

        alreadyplayed = true;
        Save();
        SceneManager.LoadScene("main");

    }

    public void cumparaautostrada(int i)
    {
        //de adaugat preturi
        if (i <= 5)
        {
            if (pretautostrada[i] <= money)
            {
                money -= (int)(pretautostrada[i]);
                pretautostrada[i] += (int)(pretautostrada[i] / 10);
                nrautostrada[i]++;
                GameObject.Find("nrbenzi" + (i + 1).ToString()).GetComponent<Text>().text = "Nr detinute: " + nrautostrada[i].ToString();
                if (pretautostrada[i] < 1000)
                    GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara ($" + pretautostrada[i].ToString() + ")";
                else if (pretautostrada[i] < 1000000)
                    GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara ($" + ((int)(pretautostrada[i] / 1000)).ToString() + "k)";
                else if (pretautostrada[i] < 1000000000)
                    GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara ($" + ((int)(pretautostrada[i] / 1000000)).ToString() + "M)";
                else if (pretautostrada[i] < 1000000000000)
                    GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara ($" + ((int)(pretautostrada[i] / 1000000000)).ToString() + "B)";
                else if (pretautostrada[i] < 1000000000000000)
                    GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara ($" + ((int)(pretautostrada[i] / 1000000000000)).ToString() + "T)";
            }
        }
        else
        {
            if (10 * pretautostrada[i - 6] <= money)
            {
                money -= 10 * (int)(pretautostrada[i - 6]);
                for (int x = 1; x <= 10; x++)
                    pretautostrada[i - 6] += (int)(pretautostrada[i - 6] / 10);
                nrautostrada[i - 6] += 10;
                GameObject.Find("nrbenzi" + (i + 1).ToString()).GetComponent<Text>().text = "Nr detinute: " + nrautostrada[i].ToString();
                if (pretautostrada[i - 6] < 1000)
                    GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara 10 (10x$" + pretautostrada[i - 6].ToString() + ")";
                else if (pretautostrada[i - 6] < 1000000)
                    GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara 10 (10x$" + ((int)(pretautostrada[i - 6] / 1000)).ToString() + "k)";
                else if (pretautostrada[i - 6] < 1000000000)
                    GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara 10 (10x$" + ((int)(pretautostrada[i - 6] / 1000000)).ToString() + "M)";
                else if (pretautostrada[i - 6] < 1000000000000)
                    GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara 10 (10x$" + ((int)(pretautostrada[i - 6] / 1000000000)).ToString() + "B)";
                else if (pretautostrada[i - 6] < 1000000000000000)
                    GameObject.Find("cumparabucata" + (i).ToString()).GetComponent<Text>().text = "Cumpara 10 (10x$" + ((int)(pretautostrada[i - 6] / 1000000000000)).ToString() + "T)";
            }
        }
        if (money <= 1000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + money.ToString();
        else if (money < 1000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000).ToString() + "k";
        else if (money < 1000000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000000).ToString() + "M";
        else if (money < 1000000000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000000000).ToString() + "B";
        else if (money < 1000000000000000)
            GameObject.Find("moneydisplay").GetComponent<Text>().text = "$" + ((int)money / 1000000000000).ToString() + "T";
    }

    public void toggledmeolare()
    {
        toggledemolare = true;
    }
    public void togglecsoturi()
    {
        togglecosturi = true;
    }
}
