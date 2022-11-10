using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class path : MonoBehaviour
{

    int[,] drumuri = new int[251, 251];
    int[,] capacitate = new int[4, 2];
    float[,] orase = new float[251, 251];
    int[,] weight_final = new int[251, 251];
    float[,] lista_orase = new float[4, 251];
    int n;
    int[,] pathd = new int[251, 251];
    int[,] pathp = new int[251, 251];
    float[,] weight = new float[251, 251];
    public Tile[] verde, galben, rosu, portocaliu;
    main mainscript;

    // Start is called before the first frame update
    public void FunctiedeStart()
    {
        mainscript = GameObject.Find("Canvas").GetComponent<main>();
        for (int x = 1; x <= 250; x++)
            for (int y = 1; y <= 250; y++)
            {
                weight_final[x, y] = 0;
            }
        for (int x = 0; x <= 250; x++)
            for (int y = 0; y <= 250; y++)
                pathd[x, y] = 100000000;

        for (int x = 0; x <= 250; x++)
            for (int y = 0; y <= 250; y++)
            {
                drumuri[x, y] = mainscript.tilemapinfo[x, y];
                orase[x, y] = mainscript.orase[x, y];
                weight_final[x, y] = mainscript.weight_final[x, y];
            }
        for (int x = 1; x <= 3; x++)
            for (int y = 1; y <= 250; y++)
            {
                lista_orase[x, y] = mainscript.lista_orase[x, y];

            }
        n = mainscript.xlistaorase;
        trafic();

    }


    void updatetiles()
    {
        for (int i = 0; i <= 250; i++)
            for (int j = 0; j <= 250; j++)
                GameObject.Find("tilemaptrafic").GetComponent<Tilemap>().SetTile(new Vector3Int(i, j, 0), null);

        for (int i = 0; i <= 250; i++)
            for (int j = 0; j <= 250; j++)
            {
                if (weight_final[i, j] != 0)
                {
                    Debug.Log("Weight de " + weight_final[i, j] + " i: " + i + " j: " + j);
                    Vector3Int mouseCell = new Vector3Int(i, j, 0);
                    Tilemap tilemap = GameObject.Find("tilemaptrafic").GetComponent<Tilemap>();
                    int k = 3, type = mainscript.tilemapinfo[mouseCell.x, mouseCell.y];
                    //nu e in nicio parte
                    if (mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] == 0 && mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] == 0 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] == 0 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] == 0)
                        k = 3;
                    // stanga sau/si dreapta
                    else if ((mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 || mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1) && mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] == 0 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] == 0)
                        k = 1;
                    // sus sau/si jos
                    else if ((mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 || mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1) && mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] == 0 && mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] == 0)
                        k = 3;
                    //stanga si sus
                    else if (mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] == 0 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] == 0 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                        k = 5;
                    //stanga si jos
                    else if (mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] == 0 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] == 0)
                        k = 2;
                    //dreapta si jos
                    else if (mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] == 0 && mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] == 0)
                        k = 0;
                    //dreapta si sus
                    else if (mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] == 0 && mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] == 0 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                        k = 4;
                    //dreapta si sus si jos
                    else if (mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] == 0 && mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                        k = 6;
                    //stanga si dreapta si jos
                    else if (mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] == 0)
                        k = 7;
                    //stanga si sus si jos
                    else if (mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] == 0 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                        k = 9;
                    //stanga si dreapta si sus
                    else if (mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] == 0 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                        k = 10;
                    //toate
                    else if (mainscript.tilemapinfo[mouseCell.x - 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x + 1, mouseCell.y] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y - 1] >= 1 && mainscript.tilemapinfo[mouseCell.x, mouseCell.y + 1] >= 1)
                        k = 8;
                    else
                        k = 3;
                    if (type == 1)
                    {
                        if (weight_final[i, j] <= 500)
                            tilemap.SetTile(mouseCell, verde[k]);
                        else if (0.8 * weight_final[i, j] >= 1000)
                            tilemap.SetTile(mouseCell, portocaliu[k]);
                        else if (weight_final[i, j] <= 1000)
                            tilemap.SetTile(mouseCell, galben[k]);
                        else
                            tilemap.SetTile(mouseCell, rosu[k]);

                    }
                    else if (type == 2)
                    {
                        if (weight_final[i, j] <= 20000)
                            tilemap.SetTile(mouseCell, verde[k]);
                        else if (0.8 * weight_final[i, j] >= 60000)
                            tilemap.SetTile(mouseCell, portocaliu[k]);
                        else if (weight_final[i, j] <= 60000)
                            tilemap.SetTile(mouseCell, galben[k]);
                        else
                            tilemap.SetTile(mouseCell, rosu[k]);
                    }
                    else if (type == 3)
                    {
                        if (weight_final[i, j] <= 100000)
                            tilemap.SetTile(mouseCell, verde[k]);
                        else if (0.8 * weight_final[i, j] >= 120000)
                            tilemap.SetTile(mouseCell, portocaliu[k]);
                        else if (weight_final[i, j] <= 120000)
                            tilemap.SetTile(mouseCell, galben[k]);
                        else
                            tilemap.SetTile(mouseCell, rosu[k]);
                    }
                }


            }
    }

    void politie(int tile_i, int tile_j, int dist, int maxd)
    {
        if (drumuri[tile_i, tile_j] > 0 && dist<=maxd)
        {

            pathp[tile_i, tile_j] = dist;
            weight_final[tile_i, tile_j] = weight_final[tile_i, tile_j] + weight_final[tile_i, tile_j] / 10;

            if (drumuri[tile_i - 1, tile_j] > 0 && pathp[tile_i - 1, tile_j] == 100000000 && tile_i - 1 >= 0)
                politie(tile_i - 1, tile_j, dist + 1, maxd);

            if (drumuri[tile_i, tile_j + 1] > 0 && pathp[tile_i, tile_j + 1] == 100000000 && tile_j + 1 <= 250)
                politie(tile_i, tile_j + 1, dist + 1, maxd);

            if (drumuri[tile_i + 1, tile_j] > 0 && pathp[tile_i + 1, tile_j] == 100000000 && tile_i + 1 <= 250)
                politie(tile_i + 1, tile_j, dist + 1, maxd);

            if (drumuri[tile_i, tile_j - 1] > 0 && pathp[tile_i, tile_j - 1] == 100000000 && tile_j - 1 >= 0)
                politie(tile_i, tile_j - 1, dist + 1, maxd);

        }
    }

    void trafic1(int tile_i, int tile_j, int dist)
    {
        if (drumuri[tile_i, tile_j] > 0)
        {

            pathd[tile_i, tile_j] = dist;

            if (drumuri[tile_i - 1, tile_j] > 0 && pathd[tile_i - 1, tile_j] > dist + 1 && tile_i - 1 >= 0)
                trafic1(tile_i - 1, tile_j, dist + 1);

            if (drumuri[tile_i, tile_j + 1] > 0 && pathd[tile_i, tile_j + 1] > dist + 1 && tile_j + 1 <= 250)
                trafic1(tile_i, tile_j + 1, dist + 1);

            if (drumuri[tile_i + 1, tile_j] > 0 && pathd[tile_i + 1, tile_j] > dist + 1 && tile_i + 1 <= 250)
                trafic1(tile_i + 1, tile_j, dist + 1);

            if (drumuri[tile_i, tile_j - 1] > 0 && pathd[tile_i, tile_j - 1] > dist + 1 && tile_j - 1 >= 0)
                trafic1(tile_i, tile_j - 1, dist + 1);

        }
    }

    float trafic2(int tile_i, int tile_j, int dist)
    {
        if (drumuri[tile_i, tile_j] > 0)
        {
            float weighttemp = 0;

            if (drumuri[tile_i - 1, tile_j] > 0 && pathd[tile_i - 1, tile_j] == dist + 1 && tile_i - 1 >= 0)
                weighttemp = weighttemp + trafic2(tile_i - 1, tile_j, dist + 1);

            if (drumuri[tile_i, tile_j - 1] > 0 && pathd[tile_i, tile_j - 1] == dist + 1 && tile_j - 1 >= 0)
                weighttemp = weighttemp + trafic2(tile_i, tile_j - 1, dist + 1);

            if (drumuri[tile_i + 1, tile_j] > 0 && pathd[tile_i + 1, tile_j] == dist + 1 && tile_i + 1 <= 250)
                weighttemp = weighttemp + trafic2(tile_i + 1, tile_j, dist + 1);

            if (drumuri[tile_i, tile_j + 1] > 0 && pathd[tile_i, tile_j + 1] == dist + 1 && tile_j + 1 <= 250)
                weighttemp = weighttemp + trafic2(tile_i, tile_j + 1, dist + 1);

            if (orase[tile_i, tile_j] > 0 && dist > 0)
                weighttemp = weighttemp + orase[tile_i, tile_j] / dist;

            weight[tile_i, tile_j] = weighttemp;
            return weighttemp;
        }
        return 0;
    }

    void income()
    {
        
        for (int x = 1; x <= 250; x++)
            for (int y = 1; y <= 250; y++)
            {
                if (weight_final[x, y] > 0)
                {
                    int type = mainscript.tilemapinfo[x, y], status = -1;
                    if (type == 1)
                    {
                        if (weight_final[x, y] <= 500)
                            status = 0;
                        else if (0.8 * weight_final[x, y] >= 1000)
                            status = 1;
                        else
                            status = 2;

                    }
                    else if (type == 2)
                    {
                        if (weight_final[x, y] <= 20000)
                            status = 0;
                        else if (0.8 * weight_final[x, y] >= 60000)
                            status = 1;
                        else
                            status = 2;
                    }
                    else if (type == 3)
                    {
                        if (weight_final[x, y] <= 100000)
                            status = 0;
                        else if (0.8 * weight_final[x, y] >= 120000)
                            status = 1;
                        else
                            status = 2;
                    }
                    if (status == 0)
                        mainscript.incomepath[x, y] = weight_final[x, y] / 3;
                    else if (status == 1)
                        mainscript.incomepath[x, y] = weight_final[x, y] / 4;
                    else
                        mainscript.incomepath[x, y] = weight_final[x, y] / 15000;

                }
                else
                    mainscript.incomepath[x, y] = 0;

            }
    }

    public void trafic()
    {
        for (int x = 1; x <= 250; x++)
            for (int y = 1; y <= 250; y++)
            {
                weight_final[x, y] = 0;
            }
        capacitate[1, 1] = 1000;
        capacitate[2, 1] = 60000;
        capacitate[3, 1] = 120000;

        for (int i = 1; i <= n; i++)
        {

            trafic1((int)lista_orase[1, i], (int)lista_orase[2, i], 0);
            float weight_total = trafic2((int)lista_orase[1, i], (int)lista_orase[2, i], 0);

            if (weight_total > 0)
            {

                for (int x = 1; x <= 250; x++)
                    for (int y = 1; y <= 250; y++)
                        weight_final[x, y] = (int)(weight_final[x, y] + 1.0f * (weight[x, y]) / weight_total * lista_orase[3, i]);

            }

            for (int x = 1; x <= 250; x++)
                for (int y = 1; y <= 250; y++)
                {
                    pathd[x, y] = 100000000;
                   
                    if (weight_final[x, y] > capacitate[drumuri[x, y], 1])
                        pathd[x, y] = -1;
                    weight[x, y] = 0;
                }
        }

        for (int x = 0; x <= 250; x++)
            for (int y = 0; y <= 250; y++)
                if (mainscript.tilemapbuildings[x, y] == 6)
                    politie(x, y, 0, 10);

        for (int x = 0; x <= 250; x++)
            for (int y = 0; y <= 250; y++)
                pathp[x, y] = 100000000;

                for (int x = 0; x <= 250; x++)
            for (int y = 0; y <= 250; y++)
                mainscript.weight_final[x, y] = weight_final[x, y];
        if (GameObject.Find("Canvas").GetComponent<lerp>().glassesmode.activeSelf)
           updatetiles();
        income();
        for (int x = 1; x <= 250; x++)
            for (int y = 1; y <= 250; y++)
            {
                weight_final[x, y] = 0;
            }
    }
}
