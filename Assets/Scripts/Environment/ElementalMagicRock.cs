using UnityEngine;

public class ElementalMagicRock : MonoBehaviour
{
    [SerializeField] ElementalType rockElementalType;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpellCastHandler.Instance.LearnElementalMagicByType(rockElementalType);
            GetComponent<Collider>().enabled = false;
        }
    }
}
