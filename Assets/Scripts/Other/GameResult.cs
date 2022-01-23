using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    [SerializeField] StoryEnd m_EndType;
    [SerializeField] private WinPlayerSO m_WinPlayerSO;
    [SerializeField] private GameModeSO m_GameModeSO;
    [SerializeField] private SceneController m_SceneController;

    private PlayerType m_PlayerType;
    private int m_P1Score = 0;
    private int m_P2Score = 0;

    private void Start()
    {
        if (m_EndType == null)
        {
            m_EndType = (StoryEnd) Resources.Load("StoryEnd", typeof(StoryEnd));
        }
    }

    //public void SetFinalResult(int p1, int p2)
    //{
    //    m_P1Score = p1;
    //    m_P2Score = p2;
    //    CheckFinalEnd();
    //    CheckFinalWhoWin();
    //}

    //private void CheckFinalWhoWin()
    //{
    //    if (m_P1Score > m_P2Score)
    //    {
    //        m_WinPlayerSO.WinPlayer = WinPlayer.P1Win;
    //    }
    //    else if (m_P1Score < m_P2Score)
    //    {
    //        m_WinPlayerSO.WinPlayer = WinPlayer.P2Win;
    //    }
    //    else if (m_P1Score == m_P2Score)
    //    {
    //        m_WinPlayerSO.WinPlayer = WinPlayer.Tie;
    //    }
    //}

    private void CheckFinalEnd()
    {
        if (m_PlayerType == PlayerType.P1)
        {
            MusicController.Instance.ChangeBGM(MusicController.AudioType.HappyEndBGM);
            m_EndType.StoryEndType = StoryEndType.HappyEnd;
        }
        else if (m_PlayerType == PlayerType.P2)
        {
            MusicController.Instance.ChangeBGM(MusicController.AudioType.BadEndBGM);
            m_EndType.StoryEndType = StoryEndType.BadEnd;
        }
        else if (m_PlayerType == PlayerType.Non)
        {
            MusicController.Instance.ChangeBGM(MusicController.AudioType.TrueEndBGM);
            m_EndType.StoryEndType = StoryEndType.TrueEnd;
        }
    }

    private void SetSceneChange()
    {
        if (m_GameModeSO.GameMode == GameMode.StoryMode)
        {
            m_SceneController.SwitchScene("StoryGameOver");
        }
        else if (m_GameModeSO.GameMode == GameMode.MuletplayerMode)
        {
            m_SceneController.SwitchScene("PVPGameOver");
        }
    }

    public void SetWinner(PlayerType playerType)
    {
        m_PlayerType = playerType;
        CheckFinalEnd();
        SetSceneChange();
    }
}
