using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("TimeToStart");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TimeToStart()
    {
        yield return new WaitForSeconds(33);
        SceneManager.LoadScene("Start Screen");
    }
}
