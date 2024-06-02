using UnityEngine;


public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] bool isInteractable = true;

    public void BeginInteract()
    {
        if (isInteractable)
        {
            // Transition to next scene
            Debug.Log("Transition to next scene");
            GameManager.Instance.LoadScene("BaseLevel");
        }
    }

    public void EndInteract()
    {
    }
}
