using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Diagnostics.CodeAnalysis;

public class InteractableObjects2 : MonoBehaviour, IInteractable2
{
    public InteractionDetector2 interactionDetector2;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;

    private void Start()
    {
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    void Update()
    {
        if (interactionDetector2.interactionIcon2.activeSelf)
        {
            if (Input.GetButtonDown("Interact"))
            {
                EventSystem.current.SetSelectedGameObject(contButton);
                if (dialoguePanel.activeInHierarchy)
                {
                    zeroText();
                }
                else
                {
                    dialoguePanel.SetActive(true);
                    StartCoroutine(Typing());

                }
            }
        }

        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        contButton.SetActive(false);

        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    public void Interact()
    {
        if (!dialoguePanel.activeInHierarchy) return;
    }

    public bool CanInteract()
    {
        return interactionDetector2.interactionIcon2 == true;
    }
}
