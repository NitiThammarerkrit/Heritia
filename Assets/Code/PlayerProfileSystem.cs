using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameData
{
    public static int current_scene;
    public static int previous_scene;
    public static bool[] events_complete = new bool [100];
    public static bool[] gems_receive = new bool [100];
    public static GameObject[] items = new GameObject[8];
}

public class SaveLoad
{
    public static void Save()
    {
        BinaryFormatter bF = new BinaryFormatter();
        using (FileStream fs = new FileStream("savefile.bin", FileMode.Create, FileAccess.Write))
        {
            bF.Serialize(fs, GameData.current_scene);
            bF.Serialize(fs, GameData.previous_scene);
            for (int i = 0; i < GameData.events_complete.Length; i++) { bF.Serialize(fs, GameData.events_complete[i]); }
            for (int i = 0; i < GameData.gems_receive.Length; i++) { bF.Serialize(fs, GameData.gems_receive[i]); }
            for (int i = 0; i < GameData.items.Length; i++) { bF.Serialize(fs, GameData.items[i]); }
        }
    }

    public static void Load()
    {
        if (!File.Exists("savefile.bin"))
        {
            return;
        }

        BinaryFormatter bF = new BinaryFormatter();
        using (FileStream fs = new FileStream("savefile.bin", FileMode.Open, FileAccess.Read))
        {
            GameData.current_scene = (int)bF.Deserialize(fs);
            GameData.previous_scene = (int)bF.Deserialize(fs);
            for (int i = 0; i < GameData.events_complete.Length; i++) { GameData.events_complete[i] = (bool)bF.Deserialize(fs); }
            for (int i = 0; i < GameData.gems_receive.Length; i++) { GameData.gems_receive[i] = (bool)bF.Deserialize(fs); }
            for (int i = 0; i < GameData.items.Length; i++) { GameData.items[i] = (GameObject)bF.Deserialize(fs); }
        }
    }
}
