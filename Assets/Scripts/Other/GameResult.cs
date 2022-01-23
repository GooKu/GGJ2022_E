using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    [SerializeField] StoryEnd m_EndType;
    [SerializeField] private WinPlayerSO m_WinPlayerSO;

    private int m_P1Score = 0;
    private int m_P2Score = 0;

    private void Start()
    {
        if(m_EndType == null)
        {
            m_EndType = (StoryEnd)Resources.Load("StoryEnd" , typeof(StoryEnd));
        }
    }

    public void GetFinalBothScore(int p1, int p2)
    {
        m_P1Score = p1;
        m_P2Score = p2;
        CheckFinalEnd();
        CheckFinalWhoWin();
    }

    private void CheckFinalWhoWin()
    {
        if (m_P1Score > m_P2Score)
        {
            m_WinPlayerSO.WinPlayer = WinPlayer.P1Win;
        }
        else if (m_P1Score < m_P2Score)
        {
            m_WinPlayerSO.WinPlayer = WinPlayer.P2Win;
        }
        else if (m_P1Score == m_P2Score)
        {
            m_WinPlayerSO.WinPlayer = WinPlayer.Tie;
        }
    }

    private void CheckFinalEnd()
    {
        if(m_P1Score > m_P2Score)
        {
            m_EndType.StoryEndType = StoryEndType.HappyEnd;
        }
        else if(m_P1Score < m_P2Score)
        {
            m_EndType.StoryEndType = StoryEndType.BadEnd;
        }
        else if(m_P1Score == m_P2Score)
        {
            m_EndType.StoryEndType = StoryEndType.TrueEnd;
        }
    }
}
