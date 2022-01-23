using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameSetting : MonoBehaviour
{
    [SerializeField] private GameModeSO m_GameModeSO;
    [SerializeField] private StoryEnd m_EndType;
    [SerializeField] private SceneController m_SceneController;
    [SerializeField] private GameObject m_MusicPrefab;
    [SerializeField] private GameObject m_NormalBG;
    [SerializeField] private GameObject m_TrueBG;

    private void Start()
    {
        if (MusicController.Instance == null)
        {
            Instantiate(m_MusicPrefab);
        }

        MusicController.Instance.ChangeBGM(MusicController.AudioType.StartBGM);

        if (m_EndType.StoryEndType == StoryEndType.BadEnd)
        {
            m_GameModeSO.StartSceneMode = StartSceneMode.TrueMode;
        }

        if (m_GameModeSO.StartSceneMode == StartSceneMode.NormalMode)
        {
            m_NormalBG.SetActive(true);
            m_TrueBG.SetActive(false);
        }
        else
        {
            m_NormalBG.SetActive(false);
            m_TrueBG.SetActive(true);
        }
    }

    public void StoryMode()
    {
        m_GameModeSO.GameMode = GameMode.StoryMode;
        m_SceneController.SwitchScene("Story");

        m_GameModeSO.StartSceneMode = StartSceneMode.TrueMode;
    }

    public void MultplayerMode()
    {
        m_GameModeSO.GameMode = GameMode.MuletplayerMode;
        m_SceneController.SwitchScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}