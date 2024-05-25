using TMPro;
using UnityEngine;

public class ElementalMagicRock : MonoBehaviour, IInteractable
{
    [SerializeField] ElementalType rockElementalType;
    [SerializeField] TextMeshPro displayTextMeshPro;
    [SerializeField] string displayText;
    [SerializeField] Color textColor = Color.white;
    [SerializeField] GameObject interactGO;

    void Awake()
    {
        displayTextMeshPro.text = displayText;
        displayTextMeshPro.color = textColor;
    }

    public void BeginInteract()
    {
        interactGO.SetActive(true);
    }

    public void Interact()
    {
        SpellCastHandler.Instance.LearnElementalMagicByType(rockElementalType);
    }

    public void EndInteract()
    {
        GetComponent<BoxCollider>().enabled = false;
        interactGO.SetActive(false);

    }

    public bool IsInteractionAllowed()
    {
        return GetComponent<BoxCollider>().enabled;
    }
}
