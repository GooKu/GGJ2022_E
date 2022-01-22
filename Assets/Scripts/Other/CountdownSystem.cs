using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownSystem : MonoBehaviour
{
    [SerializeField] private SceneController m_SceneController;
    [SerializeField] private float m_TotalTime;
    [SerializeField] private GameResult m_GameResult;
    private float m_CurrentTime;

    public float CurrentTime { get => m_CurrentTime; set => m_CurrentTime = value; }

    private void Start()
    {
        m_CurrentTime = m_TotalTime;
        StartCoroutine(StartCountdown());
    }

    private void FixedUpdate()
    {
        m_CurrentTime -= Time.fixedDeltaTime;
    }

    public IEnumerator StartCountdown()
    {
        yield return new WaitUntil(() => m_CurrentTime <= 0);
        m_SceneController.SwitchScene("StoryGameOver");
    }
}
