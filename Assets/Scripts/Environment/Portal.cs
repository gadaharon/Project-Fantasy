using UnityEngine;

public class Portal : InteractableInput
{
    protected override void HandleInteraction()
    {
        Debug.Log("Go to portal");
    }
}
