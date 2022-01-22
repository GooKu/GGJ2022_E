using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownSystem : MonoBehaviour
{
    [SerializeField] private float m_TotalTime;
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
        Debug.Log("Wait complete");
    }
}
