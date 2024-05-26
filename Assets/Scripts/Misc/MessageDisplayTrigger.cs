using UnityEngine;

[RequireComponent(typeof(InteractionHandler))]
public class MessageDisplayTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] FadeTransition fadeTransitionText;
    [SerializeField] bool deactivateOnInteraction = true;


    public void BeginInteract()
    {
        fadeTransitionText.StartTextFadeTransitionInOut();
    }

    public void EndInteract()
    {
        if (deactivateOnInteraction)
        {
            this.gameObject.SetActive(false);
        }
    }
}
