using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.Android.Types;
using UnityEngine;

public class SaveSystem
{
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/savedata.milkpot";
        FileStream stream = new FileStream(path, FileMode.Create);

        GlobalSaveData data = new GlobalSaveData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GlobalSaveData LoadGame()
    {
        string path = Application.persistentDataPath + "/savedata.milkpot";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream (path, FileMode.Open);

            GlobalSaveData data = formatter.Deserialize(stream) as GlobalSaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
