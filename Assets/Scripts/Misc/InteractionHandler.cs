using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    IInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<IInteractable>();
    }

    void Update()
    {
        InteractInputHandler();
    }

    void InteractInputHandler()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable.IsInteractionAllowed())
        {
            interactable.Interact();
            interactable.EndInteract();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable.BeginInteract();
        }
    }
}
