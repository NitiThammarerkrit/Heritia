using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class GameData
{
    public static bool pass_tutorial;
    public static int current_scene;
    public static int previous_scene;
    public static bool[] events_complete = new bool [100];
    public static int gems_receive;
    public static string[] items = new string[8];
}

public static class SaveLoad
{
    public static void Save()
    {
        BinaryFormatter bF = new BinaryFormatter();
        using (FileStream fs = new FileStream("savefile.bin", FileMode.Create, FileAccess.Write))
        {
            bF.Serialize(fs, GameData.pass_tutorial);
            bF.Serialize(fs, GameData.current_scene);
            bF.Serialize(fs, GameData.previous_scene);
            for (int i = 0; i < GameData.events_complete.Length; i++) { bF.Serialize(fs, GameData.events_complete[i]); }
            bF.Serialize(fs, GameData.gems_receive);
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
            GameData.pass_tutorial = (bool)bF.Deserialize(fs);
            GameData.current_scene = (int)bF.Deserialize(fs);
            GameData.previous_scene = (int)bF.Deserialize(fs);
            for (int i = 0; i < GameData.events_complete.Length; i++) { GameData.events_complete[i] = (bool)bF.Deserialize(fs); }
            GameData.gems_receive = (int)bF.Deserialize(fs); 
            for (int i = 0; i < GameData.items.Length; i++) { GameData.items[i] = (string)bF.Deserialize(fs); }
        }
    }
}
