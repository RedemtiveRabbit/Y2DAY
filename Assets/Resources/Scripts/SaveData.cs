using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int hasCouch = -1;
    public int hasArcadeMachine = -1;
    public int hasShelf = -1;
    public int hasPlant = -1;
    public int hasDiningTable = -1;
    public int hasChairs = -1;
    public int levelsCompleted = 0;
    public static SaveData current = new();

    public static void Save()
    {
        SaveSystem.Save(current);
    }

    public static void Load()
    {
        current = SaveSystem.LoadGame();
    }
}



