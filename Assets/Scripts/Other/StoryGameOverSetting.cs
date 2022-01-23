using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryGameOverSetting : MonoBehaviour
{
    [SerializeField] private StoryEnd m_StoryEnd;
    [SerializeField] private Text m_EndText;
    [SerializeField] private GameObject m_SkipButton;

    // Happy End
    [SerializeField] private GameObject m_HappyEndObject;
    [SerializeField] private GameObject m_HappyEndBG;

    // Bad End
    [SerializeField] private GameObject m_BadEndObject;
    [SerializeField] private GameObject m_BadEndBG;

    // True End
    [SerializeField] private GameObject m_TrueEndObject;
    [SerializeField] private GameObject m_TrueEndBG;

    // End game popup
    [SerializeField] private GameObject m_Popup;
    [SerializeField] private Image m_EndTitle;
    [SerializeField] private Sprite m_HappyEndSprite;
    [SerializeField] private Sprite m_BadEndSprite;
    [SerializeField] private Sprite m_TrueEndSprite;

    void Start()
    {
        SetStoryEvent();
        TextController.Instance.TextEndEvent += StoryEnd;
    }

    public void SetStoryEvent()
    {
        m_Popup.SetActive(false);
        if (m_StoryEnd.StoryEndType == StoryEndType.HappyEnd)
        {
            m_HappyEndBG.SetActive(false);

            //m_EndText.text = "快樂結局";
            m_HappyEndObject.SetActive(true);
            m_BadEndObject.SetActive(false);
            m_TrueEndObject.SetActive(false);
            m_EndTitle.sprite = m_HappyEndSprite;

            TextController.Instance.ChangeSceneEvent += () => m_HappyEndBG.SetActive(true);
            TextController.Instance.HappyEndText(m_EndText);
        }
        else if (m_StoryEnd.StoryEndType == StoryEndType.BadEnd)
        {
            m_BadEndBG.SetActive(false);

            //m_EndText.text = "壞結局";
            m_HappyEndObject.SetActive(false);
            m_BadEndObject.SetActive(true);
            m_TrueEndObject.SetActive(false);
            m_EndTitle.sprite = m_BadEndSprite;

            TextController.Instance.ChangeSceneEvent += () => m_BadEndBG.SetActive(true);
            TextController.Instance.BadEndText(m_EndText);
        }
        else if (m_StoryEnd.StoryEndType == StoryEndType.TrueEnd)
        {
            m_TrueEndBG.SetActive(false);

            //m_EndText.text = "真結局";
            m_HappyEndObject.SetActive(false);
            m_BadEndObject.SetActive(false);
            m_TrueEndObject.SetActive(true);
            m_EndTitle.sprite = m_TrueEndSprite;

            TextController.Instance.ChangeSceneEvent += () => m_TrueEndBG.SetActive(true);
            TextController.Instance.TrueEndText(m_EndText);
        }
    }

    public void ClickSkipButton()
    {
        TextController.Instance.Skip();
    }

    void StoryEnd()
    {
        m_Popup.SetActive(true);
        m_SkipButton.SetActive(false);
    }
}