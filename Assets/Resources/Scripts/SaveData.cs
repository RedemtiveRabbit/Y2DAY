using UnityEngine;

public class SaveData : MonoBehaviour
{
    public GlobalSaveData globalSaveData;

    public static int hasCouch;
    public static int levelsCompleted = 0;


    public static void Save(GlobalSaveData globalSaveData)
    {
        SaveSystem.Save();
    }
}
