using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PVPGameOverSetting : MonoBehaviour
{
    [SerializeField] private WinPlayerSO m_WinPlayerSO;
    [SerializeField] private Text m_EndText;

    void Start()
    {
        SetPVPEvent();
    }

    public void SetPVPEvent()
    {
        if (m_WinPlayerSO.WinPlayer == WinPlayer.P1Win)
        {
            m_EndText.text = "P1���a���";
        }
        else if (m_WinPlayerSO.WinPlayer == WinPlayer.P2Win)
        {
            m_EndText.text = "P2���a���";
        }
        else if (m_WinPlayerSO.WinPlayer == WinPlayer.Tie)
        {
            m_EndText.text = "����";
        }
    }
}
