using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    void OnCollisionEnter() {
        GetComponent<Animator>().SetTrigger("Die");
    }
}
