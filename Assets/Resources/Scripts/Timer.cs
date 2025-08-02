using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public string destination;
    public int time;
    
    void Start()
    {
        StartCoroutine("TimeToStart");
    }

    void Update()
    {
        if (Input.GetButtonDown("StartGame"))
        {
            SceneManager.LoadScene(destination);
            StopAllCoroutines();
        }
    }

    private IEnumerator TimeToStart()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(destination);
    }
}
