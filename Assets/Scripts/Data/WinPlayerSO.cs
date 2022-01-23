using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WinPlayerSO : ScriptableObject
{
    [SerializeField] private WinPlayer m_WinPlayer;

    public WinPlayer WinPlayer { get => m_WinPlayer; set => m_WinPlayer = value; }
}
