using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySetting : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private SceneController sceneController;

    // Start is called before the first frame update
    void Start()
    {
        MusicController.Instance.ChangeBGM(MusicController.AudioType.HappyEndBGM);
        TextController.Instance.StoryStartText(text);
        TextController.Instance.TextEndEvent += StoryEnd;
    }

    public void StoryEnd()
    {
        sceneController.SwitchScene("Game");
    }

    private void OnDestroy()
    {
        TextController.Instance.TextEndEvent -= StoryEnd;
    }
}