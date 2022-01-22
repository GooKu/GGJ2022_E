using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryGameOverSetting : MonoBehaviour
{
    [SerializeField] private StoryEnd m_StoryEnd;
    [SerializeField] private Text m_EndText;

    // Happy End
    [SerializeField] private GameObject m_HappyEndObject;

    // Bad End
    [SerializeField] private GameObject m_BadEndObject;

    // True End
    [SerializeField] private GameObject m_TrueEndObject;

    // End game popup
    [SerializeField] private Image m_EndTitle;
    [SerializeField] private Sprite m_HappyEndSprite;
    [SerializeField] private Sprite m_BadEndSprite;
    [SerializeField] private Sprite m_TrueEndSprite;

    void Start()
    {
        SetStoryEvent();
    }

    public void SetStoryEvent()
    {
        if (m_StoryEnd.StoryEndType == StoryEndType.HappyEnd)
        {
            //m_EndText.text = "快樂結局";
            m_HappyEndObject.SetActive(true);
            m_BadEndObject.SetActive(false);
            m_TrueEndObject.SetActive(false);
            m_EndTitle.sprite = m_HappyEndSprite;
        }
        else if (m_StoryEnd.StoryEndType == StoryEndType.BadEnd)
        {
            //m_EndText.text = "壞結局";
            m_HappyEndObject.SetActive(false);
            m_BadEndObject.SetActive(true);
            m_TrueEndObject.SetActive(false);
            m_EndTitle.sprite = m_BadEndSprite;
        }
        else if (m_StoryEnd.StoryEndType == StoryEndType.TrueEnd)
        {
            //m_EndText.text = "真結局";
            m_HappyEndObject.SetActive(false);
            m_BadEndObject.SetActive(false);
            m_TrueEndObject.SetActive(true);
            m_EndTitle.sprite = m_TrueEndSprite;
        }
    }
}