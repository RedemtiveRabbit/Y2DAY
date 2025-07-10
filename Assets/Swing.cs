using System.Collections;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public int time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(BoxRoutine());
        }
    }

    private IEnumerator BoxRoutine()
    {
        GetComponent<CapsuleCollider2D>().enabled = true;
        yield return new WaitForSeconds(time);
        GetComponent<CapsuleCollider2D>().enabled = false;

    }
}
