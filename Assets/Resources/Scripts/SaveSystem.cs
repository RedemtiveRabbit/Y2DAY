using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.Android.Types;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public static class SaveSystem
{
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/savedata.milkpot";
        //Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);

        GlobalSaveData data = new GlobalSaveData(/*saveData*/);

        formatter.Serialize(stream, data);//writes to save file
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
