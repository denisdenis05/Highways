using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class drag : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    Vector3 initialpos;
    Vector3Int globalmouseCell;
    Tilemap globaltilemap;
    float widthinitial, heightinitial;
    public Tile[] douabenzi, treibenzi, patrubenzi, politiepump;
    int type;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "butondragbenzi1")
            type = 1;
        else if (gameObject.name == "butondragbenzi2")
            type = 2;
        else if (gameObject.name == "butondragbenzi3")
            type = 3;
        else if (gameObject.name == "Buldozebuton")
            type = 4;
        else if (gameObject.name == "butonpolitie")
            type = 5;
        else if (gameObject.name == "butonpump")
            type = 6;
        widthinitial = transform.GetComponent<RectTransform>().sizeDelta.x;
        heightinitial = transform.GetComponent<RectTransform>().sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject.Find("Main Camera").GetComponent<pinchswipe>().dragging = true;
        initialpos = transform.position;
        Vector2 pos = new Vector2(widthinitial * 0.2f, heightinitial * 0.2f);
        transform.GetComponent<RectTransform>().sizeDelta = pos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.TransformPoint(Vector3.zero);

        transform.position = eventData.position;
    }

    public void updatetile(Vector3Int mouseCell, int type, Tilemap tilemap)
    {
        int i = 3;
        //nu e in nicio parte
        if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y] == 0)
            tilemap.SetTile(mouseCell, null);
        else
        {
            if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] == 0)
                i = 3;
            // stanga sau/si dreapta
            else if ((GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 || GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1) && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] == 0)
                i = 1;
            // sus sau/si jos
            else if ((GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 || GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1) && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] == 0)
                i = 3;
            //stanga si sus
            else if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                i = 5;
            //stanga si jos
            else if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] == 0)
                i = 2;
            //dreapta si jos
            else if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] == 0)
                i = 0;
            //dreapta si sus
            else if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                i = 4;
            //dreapta si sus si jos
            else if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                i = 6;
            //stanga si dreapta si jos
            else if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] == 0)
                i = 7;
            //stanga si sus si jos
            else if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                i = 9;
            //stanga si dreapta si sus
            else if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] == 0 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                i = 10;
            //toate
            else if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                i = 8;
            else
                i = 3;
            if (type == 1)
                tilemap.SetTile(mouseCell, douabenzi[i]);
            else if (type == 2)
                tilemap.SetTile(mouseCell, treibenzi[i]);
            else if (type == 3)
                tilemap.SetTile(mouseCell, patrubenzi[i]);


        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject.Find("Main Camera").GetComponent<pinchswipe>().dragging = false;

        Vector3 touchpos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        Vector2 pos = new Vector2(widthinitial, heightinitial);
        transform.GetComponent<RectTransform>().sizeDelta = pos;
        transform.position = initialpos;

        Grid grid = GameObject.Find("Grid").GetComponent<Grid>();
        Vector3Int mouseCell = grid.WorldToCell(touchpos);
        Tilemap tilemap = GameObject.Find("TilemapHighway").GetComponent<Tilemap>();
        Tilemap terraintype = GameObject.Find("terraintype").GetComponent<Tilemap>();
        if (terraintype.GetSprite(mouseCell).name == GameObject.Find("Canvas").GetComponent<main>().terraintype[1].name)
            Debug.Log("inafara hartii");
        else if (terraintype.GetSprite(mouseCell).name == GameObject.Find("Canvas").GetComponent<main>().terraintype[4].name)
            GameObject.Find("Canvas").GetComponent<lerp>().movetospot(17);
        else if (type >= 5) // buildings
        {
            Tilemap tilemap0 = GameObject.Find("tilemaporase").GetComponent<Tilemap>();
            if (tilemap0.GetSprite(mouseCell) == null || !(tilemap0.GetSprite(mouseCell).name.Contains("PinpointLocatii")))
            {
                Tilemap tilemap2 = GameObject.Find("tilemapjudete").GetComponent<Tilemap>();

                if (type == 5)
                {
                    if (!(GameObject.Find("Canvas").GetComponent<main>().infopolicejudete.ContainsKey(tilemap2.GetTile(mouseCell).name)))
                        GameObject.Find("Canvas").GetComponent<main>().infopolicejudete.Add(tilemap2.GetTile(mouseCell).name, 0);
                    if (GameObject.Find("Canvas").GetComponent<main>().infopolicejudete[tilemap2.GetTile(mouseCell).name] < 2)
                    {
                        if (GameObject.Find("Canvas").GetComponent<main>().scadeautostrada(type - 1) == 1)
                        {
                            GameObject.Find("Canvas").GetComponent<main>().infopolicejudete[tilemap2.GetTile(mouseCell).name] = GameObject.Find("Canvas").GetComponent<main>().infopolicejudete[tilemap2.GetTile(mouseCell).name] + 1;
                            GameObject.Find("Canvas").GetComponent<main>().cladiriconstruite = GameObject.Find("Canvas").GetComponent<main>().cladiriconstruite + 1;
                            
                            GameObject.Find("Canvas").GetComponent<main>().tilemapbuildings[mouseCell.x, mouseCell.y] = type;
                            tilemap0.SetTile(mouseCell, politiepump[type - 5]);
                        }
                    }
                    else
                    {
                        GameObject.Find("textpreamultapolitie").GetComponent<Text>().text = "Deja ai 2 sectii de politie in judetul " + tilemap2.GetTile(mouseCell).name + ". Incearca sa demolezi unul din ele pentru a construi altul";

                        GameObject.Find("Canvas").GetComponent<lerp>().movetospot(27);

                    }
                }
                else if (type == 6)
                {
                    if (!(GameObject.Find("Canvas").GetComponent<main>().infopumpjudete.ContainsKey(tilemap2.GetTile(mouseCell).name)))
                        GameObject.Find("Canvas").GetComponent<main>().infopumpjudete.Add(tilemap2.GetTile(mouseCell).name, 0);

                    if (GameObject.Find("Canvas").GetComponent<main>().scadeautostrada(type - 1) == 1)
                    {
                        GameObject.Find("Canvas").GetComponent<main>().infopumpjudete[tilemap2.GetTile(mouseCell).name] = GameObject.Find("Canvas").GetComponent<main>().infopumpjudete[tilemap2.GetTile(mouseCell).name] + 1;
                        GameObject.Find("Canvas").GetComponent<main>().tilemapbuildings[mouseCell.x, mouseCell.y] = type;
                        tilemap0.SetTile(mouseCell, politiepump[type - 5]);
                    }
                }
            }
        }
        else if (type == 4) // demolare
        {
            if (GameObject.Find("Canvas").GetComponent<main>().nrautostrada[type - 1] > 0)
            {
                if (GameObject.Find("Canvas").GetComponent<main>().toggledemolare == false)
                {
                    GameObject.Find("Canvas").GetComponent<lerp>().movetospot(21);
                    globalmouseCell = mouseCell;
                    globaltilemap = tilemap;
                }
                else
                {
                    globalmouseCell = mouseCell;
                    globaltilemap = tilemap;
                    verifybuldoze();

                }
            }
        }
        
        //ERROR SLIDER
        else if (terraintype.GetSprite(mouseCell).name == GameObject.Find("Canvas").GetComponent<main>().terraintype[3].name)
        {
            if (GameObject.Find("Canvas").GetComponent<main>().nrautostrada[type - 1] > 0)
            {
                if (GameObject.Find("Canvas").GetComponent<main>().togglecosturi == false)
                {
                    Debug.Log("inafara hartii");

                    GameObject.Find("overmountainbutton").GetComponent<Button>().onClick = GameObject.Find("copielenesa_overmountainbutton").GetComponent<Button>().onClick;
                    GameObject.Find("overmountainbutton").GetComponent<Button>().onClick.AddListener(verifymountain);
                    GameObject.Find("Canvas").GetComponent<lerp>().movetospot(15);
                    globalmouseCell = mouseCell;
                    globaltilemap = tilemap;
                }
                else
                {
                    globalmouseCell = mouseCell;
                    globaltilemap = tilemap;
                    verifymountain();
                }
            }
        }
        else if (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y] != type && (GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y] == type - 1))
        {
            if (GameObject.Find("Canvas").GetComponent<main>().scadeautostrada(type - 1) == 1)
            {
                Tilemap tilemap2 = GameObject.Find("tilemapjudete").GetComponent<Tilemap>();
                GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y] = type;

                if (!(GameObject.Find("Canvas").GetComponent<main>().infostrazijudete.ContainsKey(tilemap2.GetTile(mouseCell).name)))
                    GameObject.Find("Canvas").GetComponent<main>().infostrazijudete.Add(tilemap2.GetTile(mouseCell).name, 0);
                GameObject.Find("Canvas").GetComponent<path>().FunctiedeStart();
                GameObject.Find("Canvas").GetComponent<main>().infostrazijudete[tilemap2.GetTile(mouseCell).name] = GameObject.Find("Canvas").GetComponent<main>().infostrazijudete[tilemap2.GetTile(mouseCell).name] + 1;
                GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite = GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite + 1;
                if(GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite>100 && GameObject.Find("Canvas").GetComponent<main>().statusachievements[1]==0)
                {
                    GameObject.Find("Canvas").GetComponent<main>().statusachievements[1] = 1;
                    GameObject.Find("Canvas").GetComponent<lerp>().newachievement(0);
                }
                else if (GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite > 5000 && GameObject.Find("Canvas").GetComponent<main>().statusachievements[1] == 1)
                {
                    GameObject.Find("Canvas").GetComponent<main>().statusachievements[1] = 2;
                    GameObject.Find("Canvas").GetComponent<lerp>().newachievement(1);
                }
                else if (GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite > 100000 && GameObject.Find("Canvas").GetComponent<main>().statusachievements[1] == 2)
                {
                    GameObject.Find("Canvas").GetComponent<main>().statusachievements[1] = 3;
                    GameObject.Find("Canvas").GetComponent<lerp>().newachievement(2);
                }

                updatetile(new Vector3Int(mouseCell.x, mouseCell.y), type, tilemap);
                updatetile(new Vector3Int(mouseCell.x - 1, mouseCell.y), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x - 1, mouseCell.y], tilemap);//stanga
                updatetile(new Vector3Int(mouseCell.x, mouseCell.y + 1), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y + 1], tilemap);//sus
                updatetile(new Vector3Int(mouseCell.x + 1, mouseCell.y), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x + 1, mouseCell.y], tilemap);//dreapta
                updatetile(new Vector3Int(mouseCell.x, mouseCell.y - 1), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[mouseCell.x, mouseCell.y - 1], tilemap);//jos
            }
        }
    }

    public void verifymountain()
    {
        //scadere bani
        GameObject.Find("Canvas").GetComponent<lerp>().movetospot(16);
        GameObject.Find("overmountainbutton").GetComponent<Button>().onClick.RemoveListener(verifymountain);


        if (GameObject.Find("Canvas").GetComponent<main>().scadeautostrada(type - 1) == 1)
        {

            Tilemap tilemap2 = GameObject.Find("tilemapjudete").GetComponent<Tilemap>();
            if (!(GameObject.Find("Canvas").GetComponent<main>().infostrazijudete.ContainsKey(tilemap2.GetTile(globalmouseCell).name)))
                GameObject.Find("Canvas").GetComponent<main>().infostrazijudete.Add(tilemap2.GetTile(globalmouseCell).name, 0);
            GameObject.Find("Canvas").GetComponent<main>().infostrazijudete[tilemap2.GetTile(globalmouseCell).name] = GameObject.Find("Canvas").GetComponent<main>().infostrazijudete[tilemap2.GetTile(globalmouseCell).name] + 1;
            GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite = GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite + 1;
            if (GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite > 100 && GameObject.Find("Canvas").GetComponent<main>().statusachievements[1] == 0)
            {
                GameObject.Find("Canvas").GetComponent<main>().statusachievements[1] = 1;
                GameObject.Find("Canvas").GetComponent<lerp>().newachievement(0);
            }
            else if (GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite > 5000 && GameObject.Find("Canvas").GetComponent<main>().statusachievements[1] == 1)
            {
                GameObject.Find("Canvas").GetComponent<main>().statusachievements[1] = 2;
                GameObject.Find("Canvas").GetComponent<lerp>().newachievement(1);
            }
            else if (GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite > 100000 && GameObject.Find("Canvas").GetComponent<main>().statusachievements[1] == 2)
            {
                GameObject.Find("Canvas").GetComponent<main>().statusachievements[1] = 3;
                GameObject.Find("Canvas").GetComponent<lerp>().newachievement(2);
            }
            GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[globalmouseCell.x, globalmouseCell.y] = type;
            GameObject.Find("Canvas").GetComponent<path>().FunctiedeStart();
            updatetile(new Vector3Int(globalmouseCell.x, globalmouseCell.y), type, globaltilemap);
            updatetile(new Vector3Int(globalmouseCell.x - 1, globalmouseCell.y), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[globalmouseCell.x - 1, globalmouseCell.y], globaltilemap);//stanga
            updatetile(new Vector3Int(globalmouseCell.x, globalmouseCell.y + 1), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[globalmouseCell.x, globalmouseCell.y + 1], globaltilemap);//sus
            updatetile(new Vector3Int(globalmouseCell.x + 1, globalmouseCell.y), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[globalmouseCell.x + 1, globalmouseCell.y], globaltilemap);//dreapta
            updatetile(new Vector3Int(globalmouseCell.x, globalmouseCell.y - 1), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[globalmouseCell.x, globalmouseCell.y - 1], globaltilemap);
        }
    }

    public void verifybuldoze()
    {
        //scadere bani
        GameObject.Find("Canvas").GetComponent<lerp>().movetospot(16);
        GameObject.Find("overmountainbutton").GetComponent<Button>().onClick.RemoveListener(verifymountain);



        if (GameObject.Find("Canvas").GetComponent<main>().scadeautostrada(type - 1) == 1)
        {

            Tilemap tilemap0 = GameObject.Find("tilemaporase").GetComponent<Tilemap>();
            if (tilemap0.GetSprite(globalmouseCell) != null && ((tilemap0.GetSprite(globalmouseCell).name == "PinpointLocatii_1") || (tilemap0.GetSprite(globalmouseCell).name == "PinpointLocatii_2")))
            {
                tilemap0.SetTile(globalmouseCell, null);

                GameObject.Find("Canvas").GetComponent<main>().tilemapbuildings[globalmouseCell.x, globalmouseCell.y] = 0;

                Tilemap tilemap2 = GameObject.Find("tilemapjudete").GetComponent<Tilemap>();
                if (tilemap0.GetSprite(globalmouseCell).name == "PinpointLocatii_1")
                    GameObject.Find("Canvas").GetComponent<main>().infopolicejudete[tilemap2.GetTile(globalmouseCell).name] = GameObject.Find("Canvas").GetComponent<main>().infopolicejudete[tilemap2.GetTile(globalmouseCell).name] - 1;
                else
                    GameObject.Find("Canvas").GetComponent<main>().infopumpjudete[tilemap2.GetTile(globalmouseCell).name] = GameObject.Find("Canvas").GetComponent<main>().infopumpjudete[tilemap2.GetTile(globalmouseCell).name] - 1;
                GameObject.Find("Canvas").GetComponent<main>().cladiriconstruite = GameObject.Find("Canvas").GetComponent<main>().cladiriconstruite - 1;
            }
            GameObject.Find("Canvas").GetComponent<lerp>().movetospot(22);

            Tilemap tilemap = GameObject.Find("tilemaptrafic").GetComponent<Tilemap>();
            tilemap.SetTile(globalmouseCell, null);
            GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[globalmouseCell.x, globalmouseCell.y] = 0;

            GameObject.Find("Canvas").GetComponent<path>().FunctiedeStart();
            GameObject.Find("Canvas").GetComponent<path>().trafic();

            if (tilemap.GetSprite(globalmouseCell) != null)
            {
                Tilemap tilemap2 = GameObject.Find("tilemapjudete").GetComponent<Tilemap>();
                GameObject.Find("Canvas").GetComponent<main>().infostrazijudete[tilemap2.GetTile(globalmouseCell).name] = GameObject.Find("Canvas").GetComponent<main>().infostrazijudete[tilemap2.GetTile(globalmouseCell).name] - 1;
                GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite = GameObject.Find("Canvas").GetComponent<main>().autostraziconstruite - 1;

            }
            updatetile(new Vector3Int(globalmouseCell.x, globalmouseCell.y), type, globaltilemap);
            updatetile(new Vector3Int(globalmouseCell.x - 1, globalmouseCell.y), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[globalmouseCell.x - 1, globalmouseCell.y], globaltilemap);//stanga
            updatetile(new Vector3Int(globalmouseCell.x, globalmouseCell.y + 1), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[globalmouseCell.x, globalmouseCell.y + 1], globaltilemap);//sus
            updatetile(new Vector3Int(globalmouseCell.x + 1, globalmouseCell.y), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[globalmouseCell.x + 1, globalmouseCell.y], globaltilemap);//dreapta
            updatetile(new Vector3Int(globalmouseCell.x, globalmouseCell.y - 1), GameObject.Find("Canvas").GetComponent<main>().tilemapinfo[globalmouseCell.x, globalmouseCell.y - 1], globaltilemap);
            //if (GameObject.Find("Canvas").GetComponent<lerp>().glassesmode.activeSelf)
            //    GameObject.Find("Canvas").GetComponent<path>().trafic();
        }
    }

}