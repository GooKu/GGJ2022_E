using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTool : MonoBehaviour
{
    [SerializeField] private GameModeSO m_GameModeSO;
    [SerializeField] private StoryEnd m_EndType;

    public void ClearData()
    {
        m_GameModeSO.GameMode = GameMode.StoryMode;
        m_GameModeSO.StartSceneMode = StartSceneMode.NormalMode;

        m_EndType.StoryEndType = StoryEndType.HappyEnd;
    }
}