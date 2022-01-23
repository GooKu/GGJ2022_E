using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdapter : MonoBehaviour
{
     void Start()
    {
        float goalRate = 1920f / 1080;
        float scaleRate = Screen.width / (float)Screen.height;

        var rate = scaleRate / goalRate;
        Camera.main.orthographicSize = 5f / rate;

    }

}
