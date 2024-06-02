using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioClip footstepSFX;
    [SerializeField] AudioClip[] swordSwingsSFX;
    [SerializeField] AudioClip swordHit;
    [SerializeField] AudioClip fireballSpell;

    AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeBackgroundMusic(AudioClip clip, float volume, bool isLoop)
    {
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.loop = isLoop;
        audioSource.Play();
    }

    public void PlayFootstepSFX()
    {
        audioSource.PlayOneShot(footstepSFX);
    }

    public void PlaySwordSwingSFX()
    {
        AudioClip weaponSwing = swordSwingsSFX[Random.RandomRange(0, swordSwingsSFX.Length)];
        audioSource.PlayOneShot(weaponSwing, 0.3f);
    }

    public void PlaySwordHitSFX()
    {
        audioSource.PlayOneShot(swordHit);
    }

    public void PlayFireballSFX()
    {
        audioSource.PlayOneShot(fireballSpell, 0.6f);
    }
}
