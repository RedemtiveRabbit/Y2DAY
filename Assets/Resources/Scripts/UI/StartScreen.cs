using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour 
{
    private void Update()
    {
        if(Input.GetButtonDown("StartGame"))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
   
}
