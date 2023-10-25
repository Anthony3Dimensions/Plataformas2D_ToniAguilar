using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance {get; private set;}

    AudioSource _sfxAudioSource;

    [SerializeField]private AudioClip deathSound;
    [SerializeField]private AudioClip playerJump;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            instance = this;
        }

        _sfxAudioSource = GetComponent<AudioSource>();

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void DeadZone()
    {
        _sfxAudioSource.PlayOneShot(deathSound);
    }

    public void PlayerJump()
    {
        _sfxAudioSource.PlayOneShot(playerJump);
    }

    // Update is called once per frame
 
}
