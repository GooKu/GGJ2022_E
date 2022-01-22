using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownSystem : MonoBehaviour
{
    [SerializeField] private int m_TotalTime;
    private int m_CurrentTime;

    private void Start()
    {
        m_CurrentTime = m_TotalTime;
    }

    public IEnumerator StartCountdown()
    {
        yield return WaitUntil(m_CurrentTime == 0);
    }

}
