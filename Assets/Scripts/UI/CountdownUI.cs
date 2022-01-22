using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private Text m_Text;
    [SerializeField] private CountdownSystem m_CountdownSystem;

    // Update is called once per frame
    void Update()
    {
        m_Text.text = "倒數:" + ((int)m_CountdownSystem.CurrentTime);
    }
}
