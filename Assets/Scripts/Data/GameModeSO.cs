using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class GameModeSO : ScriptableObject
{
    [SerializeField] private GameMode m_GameMode;

    public GameMode GameMode { get => m_GameMode; set => m_GameMode = value; }
}
