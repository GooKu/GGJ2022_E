using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicController.Instance.ChangeBGM(MusicController.AudioType.HappyEndBGM);
    }
}