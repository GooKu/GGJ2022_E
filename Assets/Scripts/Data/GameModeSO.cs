using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameModeSO : ScriptableObject
{
    [SerializeField] private GameMode m_GameMode;
    [SerializeField] private StartSceneMode m_StartSceneMode;

    public GameMode GameMode { get => m_GameMode; set => m_GameMode = value; }
    public StartSceneMode StartSceneMode { get => m_StartSceneMode; set => m_StartSceneMode = value; }
}