using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public string destination;
    public void GoToNewScene() 
    {
        SceneManager.LoadScene(destination);
    }


}
