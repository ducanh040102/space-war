using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------Audio Source-------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------Audio Clip-------------")]
    public AudioClip background;
    public AudioClip pause;
    public AudioClip playerShoot;
    public AudioClip playerDeath;
    public AudioClip itemPick;
    public AudioClip weaponUpgrade;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) 
    {
        SFXSource.PlayOneShot(clip);
    }
}
