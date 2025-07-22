using UnityEngine;

[System.Serializable]
public class GlobalSaveData
{
    public static int hasCouch;
    public static int levelsCompleted = 0;
    public GlobalSaveData()
    {
        if (hasCouch == -1)
        {
            hasCouch = MallSaveData.hasCouch;
        }
    }

}
