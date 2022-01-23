using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    #region Static function

    private static MusicController instance;

    public static MusicController Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = GameObject.FindWithTag("MusicController");
                if (obj != null)
                {
                    instance = obj.GetComponent<MusicController>();
                }
            }

            return instance;
        }
    }

    #endregion

    #region Variable

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSourceSE;

    [SerializeField] private AudioClip startGameBGM;
    [SerializeField] private AudioClip inGameBGM;

    [SerializeField] private AudioClip happyEndBGM;
    [SerializeField] private AudioClip trueEndBGM;
    [SerializeField] private AudioClip badEndBGM;

    [SerializeField] private AudioClip explosionSE;
    [SerializeField] private AudioClip laughSE;

    #endregion


    #region Enum

    public enum AudioType
    {
        StartBGM,
        InGameBGM,
        HappyEndBGM,
        TrueEndBGM,
        BadEndBGM,
    }

    public enum SEType
    {
        Explosion,
        Laugh,
    }

    #endregion

    #region Mono function

    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    #endregion

    #region Public function

    public void ChangeBGM(AudioType type)
    {
        audioSource.clip = GetAudioClip(type);
        audioSource.Play();
    }

    public void PlaySE(SEType type)
    {
        audioSourceSE.clip = GetSEAudioTypeClip(type);
        audioSourceSE.Play();
    }

    #endregion

    #region Private function

    AudioClip GetAudioClip(AudioType audioType)
    {
        switch (audioType)
        {
            case AudioType.StartBGM:
                return startGameBGM;
            case AudioType.InGameBGM:
                return inGameBGM;
            case AudioType.HappyEndBGM:
                return happyEndBGM;
            case AudioType.TrueEndBGM:
                return trueEndBGM;
            case AudioType.BadEndBGM:
                return badEndBGM;
            default:
                return null;
        }
    }

    AudioClip GetSEAudioTypeClip(SEType type)
    {
        switch (type)
        {
            case SEType.Explosion:
                return explosionSE;
            case SEType.Laugh:
                return laughSE;
            default:
                return null;
        }
    }

    #endregion
}