using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioClip footstepSFX;
    AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootstepSFX()
    {
        audioSource.PlayOneShot(footstepSFX);
    }
}
