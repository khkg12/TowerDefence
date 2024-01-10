using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }
            return instance;
        }

    }
    private static SoundManager instance;
    public Image OptionUi;
    public Slider OptionSlider;
    AudioSource bgmSource;
    public List<AudioClip> bgmList;


    List<AudioSource> audioList;

    public enum BgmScene { Intro = 0, Main, Battle, GameOver, Win}; // 첫번째는 명시로 써줘
    public BgmScene bgmScene;
    private void Awake()
    {
        var gameObj = FindObjectsOfType<SoundManager>();
        if (gameObj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
            bgmSource = GetComponent<AudioSource>();
            bgmScene = BgmScene.Intro;
            BgmPlay(bgmScene);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BgmPlay(BgmScene bgm)
    {
        bgmSource.clip = bgmList[(int)bgm];// !! TODOLIST 동현
        bgmSource.Play();
    }

    public void ChangeValue() // 슬라이더의 OnValueChanged에 등록된 함수
    {
        bgmSource.volume = OptionSlider.value;
    }

    public void EffectSoundPlay(AudioClip clip)
    {
        AudioSource ad = new AudioSource();
        ad.clip = clip;
        ad.Play();
        audioList.Add(ad);
        StartCoroutine(DestroyselfAdCo(clip.length , audioList[audioList.Count - 1]));
    }


    IEnumerator DestroyselfAdCo(float time, AudioSource ad )
    {
        yield return new WaitForSeconds(time);
        Destroy(ad.gameObject);
    }

    public void OptionUiExit()
    {
        OptionUi.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
