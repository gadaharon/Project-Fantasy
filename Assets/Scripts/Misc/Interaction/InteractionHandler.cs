using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    IInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<IInteractable>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable.BeginInteract();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable.EndInteract();
        }
    }
}
