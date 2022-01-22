using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameSetting : MonoBehaviour
{
    [SerializeField] private GameModeSO m_GameModeSO;
    [SerializeField] private SceneController m_SceneController;

    public void StoryMode()
    {
        m_GameModeSO.GameMode = GameMode.StoryMode;
        m_SceneController.SwitchScene("Story");
    }

    public void MultplayerMode()
    {
        m_GameModeSO.GameMode = GameMode.MuletplayerMode;
        m_SceneController.SwitchScene("Game");
    }
}
