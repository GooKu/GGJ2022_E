using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StoryEnd : ScriptableObject
{
    [SerializeField] private StoryEndType m_StoryEndType;

    public StoryEndType StoryEndType { get => m_StoryEndType; set => m_StoryEndType = value; }
}
