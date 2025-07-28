using UnityEngine;

public class InteractionDetector2 : MonoBehaviour
{
    private IInteractable2 interactableInRange = null; //closest Interactable
    public GameObject interactionIcon2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionIcon2.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable2 interactable) && interactable.CanInteract())
        {
            interactableInRange = interactable;
            interactionIcon2.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable2 interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            interactionIcon2.SetActive(false);
        }
    }
}
