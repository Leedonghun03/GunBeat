using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip[] songs;

    private AudioSource audioSource;
    private AudioClip currentSong = null;

    private float audioLength = 0f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentSong = songs[3];
            PlaySampleSong();
        }
    }


    public void GetSampleAudio(string name)
    {
        int songNum = 0;
        
        switch (name)
        {
            case "Corporate Song":
                songNum = 0;
                break;

            case "Bad Bounce":
                songNum = 1;
                break;

            case "Chamber":
                songNum = 2;
                break;

            case "Night Lights":
                songNum = 3;
                break;

            case "Peyruis":
                songNum = 4;
                break;
        }

        currentSong = songs[songNum];

        PlaySampleSong();
    }


    private void PlaySampleSong()
    {
        // 실행중인 노래 정지
        audioSource.Stop();
        StopAllCoroutines();

        // 선택한 노래 재생
        audioLength = currentSong.length;
        audioSource.clip = currentSong;
        audioSource.volume = 1f;
        audioSource.Play();

        StartCoroutine(SoundLerpDown());
    }


    private IEnumerator SoundLerpDown()
    {
        float currentTime = 0f;
        float volume = 1f;

        while (currentTime < audioLength - 1f)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }

        while (volume > 0.02f)
        {
            volume = Mathf.Lerp(volume, 0, 2f * Time.deltaTime);
            audioSource.volume = volume;
            yield return null;
        }

        PlaySampleSong();
    }

}
