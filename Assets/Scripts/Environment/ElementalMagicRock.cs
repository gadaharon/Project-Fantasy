using TMPro;
using UnityEngine;

public class ElementalMagicRock : MonoBehaviour
{
    [SerializeField] ElementalType rockElementalType;
    [SerializeField] TextMeshPro displayTextMeshPro;
    [SerializeField] string displayText;
    [SerializeField] Color textColor = Color.white;

    void Awake()
    {
        displayTextMeshPro.text = displayText;
        displayTextMeshPro.color = textColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpellCastHandler.Instance.LearnElementalMagicByType(rockElementalType);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
