using UnityEngine;

public class InteractionDetector4 : MonoBehaviour
{
    private IInteractable4 interactableInRange = null; //closest Interactable
    public GameObject interactionIcon4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionIcon4.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable4 interactable) && interactable.CanInteract())
        {
            interactableInRange = interactable;
            interactionIcon4.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable4 interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            interactionIcon4.SetActive(false);
        }
    }
}
