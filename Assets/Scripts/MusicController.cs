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

    [SerializeField] private AudioClip startGameBGM1;
    [SerializeField] private AudioClip startGameBGM2;

    [SerializeField] private AudioClip happyEndBGM;
    [SerializeField] private AudioClip trueEndBGM;
    [SerializeField] private AudioClip badEndBGM;

    #endregion


    #region Enum

    public enum AudioType
    {
        NormalStartBGM,
        TrueStartBGM,
        HappyEndBGM,
        TrueEndBGM,
        BadEndBGM,
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

    #endregion

    #region Private function

    AudioClip GetAudioClip(AudioType audioType)
    {
        switch (audioType)
        {
            case AudioType.NormalStartBGM:
                return startGameBGM1;
            case AudioType.TrueStartBGM:
                return startGameBGM2;
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

    #endregion
}