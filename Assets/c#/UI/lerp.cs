using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class lerp : MonoBehaviour
{

    public Sprite stats, achievements,judete,teren;
    public int statsstatus = 0;
    public float speed = 0;
    public GameObject glassesmode;
    main mainscript;

    // Start is called before the first frame update
    void Start()
    {
        glassesmode = GameObject.Find("GlassesMode");
        glassesmode.SetActive(false);
        mainscript = GameObject.Find("Canvas").GetComponent<main>();
        GameObject.Find("TilemapBuildMode").GetComponent<TilemapRenderer>().enabled = false;
        GameObject.Find("Buy 2 benzi").transform.position = GameObject.Find("buybenziposinitial").transform.position;
        GameObject.Find("Buy 3 benzi").transform.position = GameObject.Find("buybenziposinitial").transform.position;
        GameObject.Find("Buy 4 benzi").transform.position = GameObject.Find("buybenziposinitial").transform.position;
        GameObject.Find("Buypolice").transform.position = GameObject.Find("buybenziposinitial").transform.position;
        GameObject.Find("Buypump").transform.position = GameObject.Find("buybenziposinitial").transform.position;
        GameObject.Find("Buydemolare").transform.position = GameObject.Find("buybenziposinitial").transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void tutorialmovetospot(int i)
    {
        if(firsttimeparcurs==0)
    }

    //multe if-uri jos pt cazuri speciale
    public void movetospot(int i)
    {
        if (mainscript.alreadyplayed == false)
            tutorialmovetospot(i);
        else
        {
            GameObject obiect, destination;
            if (i == 0)
            {
                obiect = GameObject.Find("PanelProfil");
                destination = GameObject.Find("middleposition");

                GameObject.Find("butonswitchprofil").transform.SetParent(obiect.transform);

                GameObject obiect2 = GameObject.Find("buildposinitial");
                GameObject obiect3 = GameObject.Find("BuildPanel");
                if (obiect3.transform.position.y != obiect2.transform.position.y)
                {
                    GameObject.Find("BuildButton").GetComponent<Button>().onClick = GameObject.Find("BuildCopieLenesa").GetComponent<Button>().onClick;
                    GameObject.Find("BuildButton").GetComponent<Image>().sprite = GameObject.Find("BuildCopieLenesa").GetComponent<Image>().sprite;
                    GameObject.Find("BuildButton").GetComponent<Image>().color = GameObject.Find("BuildCopieLenesa").GetComponent<Image>().color;
                    GameObject.Find("TextBuildButton").GetComponent<Text>().text = GameObject.Find("TextBuildCopieLenesa").GetComponent<Text>().text;
                    mainscript.buildmode = true;
                    GameObject.Find("TilemapBuildMode").GetComponent<TilemapRenderer>().enabled = false;
                    StartCoroutine(move(obiect3, obiect2));
                }
                if (GameObject.Find("Buy 2 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 2 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buy 3 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 3 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buy 4 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 4 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buydemolare").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buydemolare"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypolice").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypolice"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypump").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypump"), GameObject.Find("buybenziposinitial")));
                }
                GameObject obiect5 = GameObject.Find("Peste munte panel");
                GameObject obiect6 = GameObject.Find("Peste protejat panel");
                GameObject destination2 = GameObject.Find("buybenziposinitial");
                if (obiect5.transform.position.y != destination2.transform.position.y)
                {
                    StartCoroutine(move(obiect5, destination2));
                }
                if (obiect6.transform.position.y != destination2.transform.position.y)
                {
                    StartCoroutine(move(obiect6, destination2));
                }
                if (glassesmode.activeSelf)
                {
                    glassesmode.SetActive(false);
                    GameObject.Find("terraintype").GetComponent<TilemapRenderer>().enabled = false;
                    GameObject.Find("tilemapjudete").GetComponent<TilemapRenderer>().enabled = false;
                    GameObject.Find("tilemaptrafic").GetComponent<TilemapRenderer>().enabled = false;
                }
            }
            else if (i == 1)
            {
                obiect = GameObject.Find("PanelProfil");
                destination = GameObject.Find("profilposition");
                GameObject obiect2 = GameObject.Find("changeprofileposition");
                GameObject obiect3 = GameObject.Find("ChangeProfile");
                if (obiect3.transform.position.y != obiect2.transform.position.y)
                {
                    StartCoroutine(move(obiect3, obiect2));
                }
                GameObject obiect4 = GameObject.Find("SetariPanel");
                if (obiect4.transform.position.y != obiect2.transform.position.y)
                {
                    StartCoroutine(move(obiect4, obiect2));
                }

            }
            else if (i == 2)
            {
                obiect = GameObject.Find("ChangeProfile");
                destination = GameObject.Find("StatsAchievments");

                GameObject obiect2 = GameObject.Find("SetariPanel");
                GameObject destination2 = GameObject.Find("changeprofileposition");
                if (obiect2.transform.position.y != destination2.transform.position.y)
                {
                    StartCoroutine(move(obiect2, destination2));
                }

            }
            else if (i == 3)
            {
                obiect = GameObject.Find("ChangeProfile");
                destination = GameObject.Find("changeprofileposition");
            }
            else if (i == 4)
            {
                obiect = GameObject.Find("BuildPanel");
                GameObject.Find("Buildpanelholder").transform.SetParent(obiect.transform);

                //se schimba butonul de build cu done
                GameObject.Find("BuildButton").GetComponent<Button>().onClick = GameObject.Find("DoneCopieLenesa").GetComponent<Button>().onClick;
                GameObject.Find("BuildButton").GetComponent<Image>().sprite = GameObject.Find("DoneCopieLenesa").GetComponent<Image>().sprite;
                GameObject.Find("BuildButton").GetComponent<Image>().color = GameObject.Find("DoneCopieLenesa").GetComponent<Image>().color;
                GameObject.Find("TextBuildButton").GetComponent<Text>().text = GameObject.Find("TextDoneCopieLenesa").GetComponent<Text>().text;

                destination = GameObject.Find("buildpos");
                mainscript.buildmode = true;
                GameObject.Find("TilemapBuildMode").GetComponent<TilemapRenderer>().enabled = true;
            }
            else if (i == 5)
            {
                obiect = GameObject.Find("BuildPanel");
                destination = GameObject.Find("buildposinitial");

                //se schimba butonul de done cu build
                GameObject.Find("BuildButton").GetComponent<Button>().onClick = GameObject.Find("BuildCopieLenesa").GetComponent<Button>().onClick;
                GameObject.Find("BuildButton").GetComponent<Image>().sprite = GameObject.Find("BuildCopieLenesa").GetComponent<Image>().sprite;
                GameObject.Find("BuildButton").GetComponent<Image>().color = GameObject.Find("BuildCopieLenesa").GetComponent<Image>().color;
                GameObject.Find("TextBuildButton").GetComponent<Text>().text = GameObject.Find("TextBuildCopieLenesa").GetComponent<Text>().text;

                mainscript.buildmode = true;
                GameObject.Find("TilemapBuildMode").GetComponent<TilemapRenderer>().enabled = false;

            }
            else if (i == 7)
            {
                obiect = GameObject.Find("SetariPanel");
                destination = GameObject.Find("StatsAchievments");
                GameObject obiect2 = GameObject.Find("ChangeProfile");
                GameObject destination2 = GameObject.Find("changeprofileposition");
                if (obiect2.transform.position.y != destination2.transform.position.y)
                {
                    StartCoroutine(move(obiect2, destination2));
                }

            }
            else if (i == 8)
            {
                obiect = GameObject.Find("SetariPanel");
                destination = GameObject.Find("changeprofileposition");
            }
            else if (i == 9)
            {
                obiect = GameObject.Find("Buy 2 benzi");
                destination = GameObject.Find("buybenzipos");
                if (GameObject.Find("Buy 3 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 3 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buy 4 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 4 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buydemolare").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buydemolare"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypolice").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypolice"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypump").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypump"), GameObject.Find("buybenziposinitial")));
                }
            }
            else if (i == 10)
            {
                obiect = GameObject.Find("Buy 2 benzi");
                destination = GameObject.Find("buybenziposinitial");
            }
            else if (i == 11)
            {
                obiect = GameObject.Find("Buy 3 benzi");
                destination = GameObject.Find("buybenzipos");
                if (GameObject.Find("Buy 2 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 2 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buy 4 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 4 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buydemolare").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buydemolare"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypolice").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypolice"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypump").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypump"), GameObject.Find("buybenziposinitial")));
                }
            }
            else if (i == 12)
            {
                obiect = GameObject.Find("Buy 3 benzi");
                destination = GameObject.Find("buybenziposinitial");
            }
            else if (i == 13)
            {
                obiect = GameObject.Find("Buy 4 benzi");
                destination = GameObject.Find("buybenzipos");
                if (GameObject.Find("Buy 2 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 2 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buy 3 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 3 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buydemolare").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buydemolare"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypolice").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypolice"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypump").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypump"), GameObject.Find("buybenziposinitial")));
                }
            }
            else if (i == 14)
            {
                obiect = GameObject.Find("Buy 4 benzi");
                destination = GameObject.Find("buybenziposinitial");
            }
            else if (i == 15)
            {
                obiect = GameObject.Find("Peste munte panel");
                destination = GameObject.Find("buybenzipos");
            }
            else if (i == 16)
            {
                obiect = GameObject.Find("Peste munte panel");
                destination = GameObject.Find("buybenziposinitial");
            }
            else if (i == 17)
            {
                obiect = GameObject.Find("Peste protejat panel");
                destination = GameObject.Find("buybenzipos");
            }
            else if (i == 18)
            {
                obiect = GameObject.Find("Peste protejat panel");
                destination = GameObject.Find("buybenziposinitial");
            }
            else if (i == 19)
            {
                obiect = GameObject.Find("Buydemolare");
                destination = GameObject.Find("buybenzipos");
                if (GameObject.Find("Buy 2 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 2 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buy 3 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 3 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buy 4 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 4 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypolice").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypolice"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypump").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypump"), GameObject.Find("buybenziposinitial")));
                }
            }
            else if (i == 20)
            {
                obiect = GameObject.Find("Buydemolare");
                destination = GameObject.Find("buybenziposinitial");
            }
            else if (i == 21)
            {
                obiect = GameObject.Find("demolarepanel");
                destination = GameObject.Find("buybenzipos");
            }
            else if (i == 22)
            {
                obiect = GameObject.Find("demolarepanel");
                destination = GameObject.Find("buybenziposinitial");
            }
            else if (i == 23)
            {
                obiect = GameObject.Find("Buypolice");
                destination = GameObject.Find("buybenzipos");
                if (GameObject.Find("Buy 2 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 2 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buy 3 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 3 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buy 4 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 4 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buydemolare").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buydemolare"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypump").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypump"), GameObject.Find("buybenziposinitial")));
                }
            }
            else if (i == 24)
            {
                obiect = GameObject.Find("Buypolice");
                destination = GameObject.Find("buybenziposinitial");
            }
            else if (i == 25)
            {
                obiect = GameObject.Find("Buypump");
                destination = GameObject.Find("buybenzipos");
                if (GameObject.Find("Buy 2 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 2 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buy 3 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 3 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buy 4 benzi").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buy 4 benzi"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buydemolare").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buydemolare"), GameObject.Find("buybenziposinitial")));
                }
                if (GameObject.Find("Buypolice").transform.position.y != GameObject.Find("buybenziposinitial").transform.position.y)
                {
                    StartCoroutine(move(GameObject.Find("Buypolice"), GameObject.Find("buybenziposinitial")));
                }
            }
            else if (i == 26)
            {
                obiect = GameObject.Find("Buypump");
                destination = GameObject.Find("buybenziposinitial");
            }
            else if (i == 27)
            {
                obiect = GameObject.Find("Preamultapolitie");
                destination = GameObject.Find("buybenzipos");
            }
            else if (i == 28)
            {
                obiect = GameObject.Find("Preamultapolitie");
                destination = GameObject.Find("buybenziposinitial");
            }
            else
            {
                obiect = GameObject.Find("PanelProfil");
                destination = GameObject.Find("profilposition");
            }
            StartCoroutine(move(obiect, destination));
        }
    }

    IEnumerator move(GameObject obiect, GameObject destination)
    {
        Vector3 Gotoposition = destination.transform.position;
        float elapsedTime = 0;
        float waitTime = 0.4f - speed;
        Vector3 currentPos = obiect.transform.position;
        while (elapsedTime < waitTime)
        {
            obiect.transform.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obiect.transform.position = Gotoposition;
        //cazuri speciale ca sa fie smooth 
        if (obiect.name == "BuildPanel" && destination.name == "buildposinitial")
            GameObject.Find("Buildpanelholder").transform.SetParent(GameObject.Find("PanelSus").transform);
        else if (obiect.name == "PanelProfil" && destination.name == "profilposition")
            GameObject.Find("butonswitchprofil").transform.SetParent(GameObject.Find("PanelSus").transform);

        yield return null;
    }

    public void newachievement(int i)
    {
        StartCoroutine(achievementmove(i));
    }

    public IEnumerator achievementmove(int i)
    {
        GameObject obiect= GameObject.Find("newachievement");
        GameObject destination = GameObject.Find("newachievementdestination");
        GameObject.Find("achievementpopupimage").GetComponent<Image>().sprite = mainscript.achievements[i];

        Vector3 Gotoposition = destination.transform.position;
        float elapsedTime = 0;
        float waitTime = 1f - speed;
        Vector3 currentPos = obiect.transform.position;
        while (elapsedTime < waitTime)
        {
            obiect.transform.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obiect.transform.position = Gotoposition;
        
        elapsedTime = 0;
        waitTime = 5;
        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        destination = GameObject.Find("newachievementpos");
        Gotoposition = destination.transform.position;
        elapsedTime = 0;
        waitTime = 1f - speed;
        currentPos = obiect.transform.position;
        while (elapsedTime < waitTime)
        {
            obiect.transform.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obiect.transform.position = Gotoposition;

        yield return null;
    }

    public void changestats(int i)
    {
        if (i == 0 && statsstatus == 1)
        {
            GameObject.Find("StatsAchievments").GetComponent<Image>().sprite = stats;
            GameObject.Find("statstext").transform.position = GameObject.Find("statspos11").transform.position;
            GameObject.Find("achievementstext").transform.position = GameObject.Find("statspos12").transform.position;
            GameObject.Find("achievementbani").GetComponent<Image>().enabled = false;
            GameObject.Find("achievementauto").GetComponent<Image>().enabled = false;
            statsstatus = 0;
        }
        else if (i == 1 && statsstatus == 0)
        {
            GameObject.Find("StatsAchievments").GetComponent<Image>().sprite = achievements;
            GameObject.Find("statstext").transform.position = GameObject.Find("statspos21").transform.position;
            GameObject.Find("achievementstext").transform.position = GameObject.Find("statspos22").transform.position;
            if (mainscript.statusachievements[0] == 0)
                GameObject.Find("achievementbani").GetComponent<Image>().color = Color.black;
            else
            {
                int nr = mainscript.statusachievements[0];
                GameObject.Find("achievementbani").GetComponent<Image>().color = Color.white;
                GameObject.Find("achievementbani").GetComponent<Image>().sprite = mainscript.achievements[nr + 2];
            }
            if (mainscript.statusachievements[1] == 0)
                GameObject.Find("achievementauto").GetComponent<Image>().color = Color.black;
            else
            {
                int nr = mainscript.statusachievements[1];
                GameObject.Find("achievementauto").GetComponent<Image>().color = Color.white;
                GameObject.Find("achievementauto").GetComponent<Image>().sprite = mainscript.achievements[nr - 1];
            }
            GameObject.Find("achievementbani").GetComponent<Image>().enabled = true;
            GameObject.Find("achievementauto").GetComponent<Image>().enabled = true;
            statsstatus = 1;
        }
    }

    public void changespeed()
    {
        speed = GameObject.Find("speedslider").GetComponent<Slider>().value;
        mainscript.speed = speed;
    }

    public void ochelari()
    {
        if (glassesmode.activeSelf)
        {
            glassesmode.SetActive(false);
            GameObject.Find("terraintype").GetComponent<TilemapRenderer>().enabled = false;
            GameObject.Find("tilemapjudete").GetComponent<TilemapRenderer>().enabled = false;
            GameObject.Find("tilemaptrafic").GetComponent<TilemapRenderer>().enabled = false;
        }
        else
        {
            glassesmode.SetActive(true);
            GameObject.Find("terraintype").GetComponent<TilemapRenderer>().enabled = true;
            GameObject.Find("tilemaptrafic").GetComponent<TilemapRenderer>().enabled = true;

        }
    }

    public void changetoterrain()
    {
        if (GameObject.Find("terraintype").GetComponent<TilemapRenderer>().enabled == false)
        {
            GameObject.Find("schimbamodvizionarebuton").GetComponent<Image>().sprite = teren;
            GameObject.Find("terraintype").GetComponent<TilemapRenderer>().enabled = true;
            GameObject.Find("tilemapjudete").GetComponent<TilemapRenderer>().enabled = false;

        }
        else
        {
            GameObject.Find("schimbamodvizionarebuton").GetComponent<Image>().sprite = judete;
            GameObject.Find("terraintype").GetComponent<TilemapRenderer>().enabled = false;
            GameObject.Find("tilemapjudete").GetComponent<TilemapRenderer>().enabled = true;
        }
    }


    public void changevolume()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = GameObject.Find("soundslider").GetComponent<Slider>().value;

    }

}
