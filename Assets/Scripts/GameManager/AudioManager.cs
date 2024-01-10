using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("------------Audio Source-------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------Audio Clip-------------")]
    public AudioClip background;
    public AudioClip pause;
    public AudioClip playerShoot;
    public AudioClip explode;
    public AudioClip itemPick;
    public AudioClip weaponUpgrade;
    public AudioClip playerShootLaser;
    public AudioClip enemyHit;
    public AudioClip bossTheme1;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        
        SFXSource.PlayOneShot(audioClip);
    }

    public void PlayPlayerShoot() 
    {
        PlaySFX(playerShoot);
    }

    public void PlayExplode() 
    {
        if (SFXSource.isPlaying != explode)
            PlaySFX(explode);
    }

    public void PlayItemPick()
    {
        PlaySFX(itemPick);
    }
    
    public void PlayWeaponUpgrade() 
    {
        PlaySFX(weaponUpgrade);
    }
    
    public void PlayPlayerShootLaser() 
    {
        PlaySFX(playerShootLaser);
    }
    
    public void PlayEnemyHit() 
    {
        PlaySFX(enemyHit);
    }

    private IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public void PlayBossTheme()
    {
        float startVolume = musicSource.volume;
        StartCoroutine(StartFade(musicSource, 3, 0));
        StartCoroutine(WaitForFade(2, startVolume));
    }

    private IEnumerator WaitForFade(float duration, float volume)
    {
        yield return new WaitForSeconds(duration);
        musicSource.clip = bossTheme1;
        musicSource.Play();
        StartCoroutine(StartFade(musicSource, 3, volume));
    }
}
