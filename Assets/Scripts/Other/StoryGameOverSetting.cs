using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryGameOverSetting : MonoBehaviour
{
    [SerializeField] private StoryEnd m_StoryEnd;
    [SerializeField] private Text m_EndText; 

    void Start()
    {
        SetStoryEvent();
    }

    public void SetStoryEvent()
    {
        if(m_StoryEnd.StoryEndType == StoryEndType.HappyEnd)
        {
            m_EndText.text = "�ֵּ���";
        }
        else if(m_StoryEnd.StoryEndType == StoryEndType.BadEnd)
        {
            m_EndText.text = "�a����";
        }
        else if(m_StoryEnd.StoryEndType == StoryEndType.TrueEnd)
        {
            m_EndText.text = "�u����";
        }
    }
}
