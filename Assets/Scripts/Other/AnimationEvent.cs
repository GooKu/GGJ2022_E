using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AnimationEvent : MonoBehaviour
{
    [SerializeField]private UnityEvent EventInAnimation;
    public void CallEvent()
    {
        EventInAnimation.Invoke();
    }

}
