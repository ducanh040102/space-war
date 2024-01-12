using DG.Tweening;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("------------Audio Source-------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------Audio Clip-------------")]
    public AudioClip[] background;
    public AudioClip pause;
    public AudioClip playerShoot;
    public AudioClip explode;
    public AudioClip bigExplode;
    public AudioClip itemPick;
    public AudioClip weaponUpgrade;
    public AudioClip playerShootLaser;
    public AudioClip enemyHit;
    public AudioClip bossTheme1;
    public AudioClip bossTheme2;
    public AudioClip victory;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        foreach (var bg in background)
        {
            bg.LoadAudioData();
        }
        bossTheme1.LoadAudioData();
        bossTheme2.LoadAudioData();

        explode.LoadAudioData();

        Player.instance.OnPlayerHit += Player_OnPlayerHit;
    }

    private void Player_OnPlayerHit(object sender, System.EventArgs e)
    {
        PlayExplode();
    }

    public void PlayBG(int index)
    {
        if(index >= background.Length)
            index = background.Length - 1;
        musicSource.clip = background[index];
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
        if (SFXSource.isPlaying == bigExplode)
            return;
        PlaySFX(explode);
    }
    
    public void PlayBigExplode() 
    {
        PlaySFX(bigExplode);
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

    public void PlayBossTheme()
    {
        StartFadeInOut(musicSource, bossTheme2, 2);
    }

    public void PlayVictoryTheme()
    {
        musicSource.Stop();
        StartCoroutine(WaitForPlaySFX(5f));
    }

    IEnumerator WaitForPlaySFX(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlaySFX(victory);
    }

    private void StartFadeInOut(AudioSource audioSource ,AudioClip audioClip, float duration)
    {
        float start = audioSource.volume;

        DOVirtual.Float(start, 0, duration, v =>
        {
            audioSource.volume = v;
        }).SetEase(Ease.InBounce).OnComplete(() =>
        {
            audioSource.clip = audioClip;
            audioSource.volume = start;

            audioSource.Play();
        });

    }
}
