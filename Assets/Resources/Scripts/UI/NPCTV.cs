using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class NPCTV : MonoBehaviour, IInteractable4
{
    public InteractionDetector4 interactionDetector4;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;
    public GameObject contButton;
    SaveData saveData;
    public float wordSpeed;

    private void Start()
    {
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    void Update()
    {
        if (interactionDetector4.interactionIcon4.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(contButton);
            if (Input.GetButtonDown("Interact") && dialoguePanel.activeInHierarchy == false)
            {

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
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            SceneManager.LoadScene("Credits");
        }
    }

    public void Interact()
    {
        if (!dialoguePanel.activeInHierarchy) return;
    }

    public bool CanInteract()
    {
        return interactionDetector4.interactionIcon4 == true;
    }
}
