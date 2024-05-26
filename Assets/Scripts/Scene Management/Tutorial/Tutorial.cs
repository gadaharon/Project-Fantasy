using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject invisibleWall;

    void OnEnable()
    {
        ElementalMagicRock.OnElementalMagicLearned += HandleOnElementalMagicLearn;
    }

    void OnDisable()
    {
        ElementalMagicRock.OnElementalMagicLearned -= HandleOnElementalMagicLearn;
    }

    void HandleOnElementalMagicLearn()
    {
        invisibleWall.SetActive(false);
    }
}
