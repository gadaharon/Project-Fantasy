using UnityEngine;

[RequireComponent(typeof(InteractionHandler))]
public abstract class InteractableInput : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject interactGO;

    BoxCollider interactionTrigger;
    bool isInteractable = false;

    protected virtual void Awake()
    {
        interactionTrigger = GetComponent<BoxCollider>();
    }

    void Update()
    {
        HandleInputInteraction();
    }

    public void BeginInteract()
    {
        interactGO.SetActive(true);
        isInteractable = true;
    }

    public void EndInteract()
    {
        if (interactGO.activeInHierarchy)
        {
            interactGO.SetActive(false);
            isInteractable = false;
            DisableInteraction();
        }
    }

    void DisableInteraction()
    {
        interactGO.SetActive(false);
        isInteractable = false;
    }

    void HandleInputInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsInteractionAllowed())
        {
            HandleInteraction();
            interactionTrigger.enabled = false;
            DisableInteraction();
        }
    }

    protected abstract void HandleInteraction();


    bool IsInteractionAllowed()
    {
        if (interactionTrigger == null) { return false; }

        return isInteractable && interactionTrigger.enabled;
    }
}

