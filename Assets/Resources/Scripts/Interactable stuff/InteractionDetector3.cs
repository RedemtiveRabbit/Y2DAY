using UnityEngine;

public class InteractionDetector3 : MonoBehaviour
{
    private IInteractable3 interactableInRange = null; //closest Interactable
    public GameObject interactionIcon3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionIcon3.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable3 interactable) && interactable.CanInteract())
        {
            interactableInRange = interactable;
            interactionIcon3.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable3 interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            interactionIcon3.SetActive(false);
        }
    }
}
