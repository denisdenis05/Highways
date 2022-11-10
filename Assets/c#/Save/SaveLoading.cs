using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoading
{

    public static void SavePlayer (main player) //functia de save
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string locatie = Application.persistentDataPath + "/joc.fuc";
        FileStream filestreamm = new FileStream(locatie , FileMode.Create);
        PlayerData data = new PlayerData(player);
        formatter.Serialize(filestreamm, data);
        filestreamm.Close();
    }

    public static PlayerData LoadPlayer() //functia de load, se iau datele din clasa PlayerData.cs
    {
        string locatie = Application.persistentDataPath + "/joc.fuc";
        if(File.Exists(locatie))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream filestreamm = new FileStream(locatie, FileMode.Open);
            PlayerData data = formatter.Deserialize(filestreamm) as PlayerData;
            filestreamm.Close();
            return data;
        }
        else
        {
            return null;
        }
    }


}
