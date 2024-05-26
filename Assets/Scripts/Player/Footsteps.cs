using StarterAssets;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField] float walkFootstepInterval = 0.5f;
    [SerializeField] float sprintFootstepInterval = 0.3f;

    FirstPersonController controller;

    float footstepTimer = 0f;
    float sprintMultiplier = 2f;

    void Awake()
    {
        controller = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        HandleFootstep();
    }

    void HandleFootstep()
    {
        if (controller.Grounded && controller.Movement != Vector2.zero)
        {
            footstepTimer -= Time.deltaTime;

            if (footstepTimer <= 0)
            {
                PlayFootsteps();
                footstepTimer = GetCurrentFootstepInterval();
            }
        }
        else
        {
            footstepTimer = 0;
        }
    }

    void PlayFootsteps()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            AudioManager.Instance?.PlayFootstepSFX();
        }
    }

    float GetCurrentFootstepInterval()
    {
        return controller.IsSprinting ? sprintFootstepInterval : walkFootstepInterval;
    }

}
