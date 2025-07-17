using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Gwendialougue
{
    public InteractionDetector interactionDetector;
    public static bool dialougueIsOpen = false;
    public GameObject dialougueUI;

    void Start()
    {
        dialougueUI.SetActive(false);
    }
    void Update()
    {
        if (interactionDetector.interactionIcon.activeSelf)
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (dialougueIsOpen)
                {
                    ContinueSpeak();
                }
                else
                {
                    StartSpeak();
                }
            }
        }

    }

    void ContinueSpeak()
    {
        dialougueUI.SetActive(false);
    }

    void StartSpeak()
    {
        dialougueUI.SetActive(true);
    }

    public void Interact()
    {
        if (!dialougueIsOpen) return;
    }

    public bool CanInteract()
    {
        return interactionDetector.interactionIcon == true;
    }
}
