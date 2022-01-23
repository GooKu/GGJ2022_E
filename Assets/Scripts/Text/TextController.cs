using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    #region Static function

    private static TextController instance;

    public static TextController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<TextController>();
            }

            return instance;
        }
    }

    #endregion

    #region Event

    public Action TextEndEvent;
    public Action ChangeSceneEvent;

    #endregion

    #region Variable

    private WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);

    #endregion

    #region Public function

    public void StoryStartText(Text text)
    {
        StartCoroutine(ShowStoryStartText(text));
    }

    public void HappyEndText(Text text)
    {
        StartCoroutine(ShowHappyEndText(text));
    }

    public void TrueEndText(Text text)
    {
        StartCoroutine(ShowTrueEndText(text));
    }

    public void BadEndText(Text text)
    {
        StartCoroutine(ShowBadEndText(text));
    }

    public void RegisterTextEndEvent(Action action)
    {
        TextEndEvent += action;
    }

    public void UnRegisterTextEndEvent(Action action)
    {
        TextEndEvent -= action;
    }

    #endregion

    #region Private function

    IEnumerator ShowStoryStartText(Text text)
    {
        text.text = "這一天終於到來了";
        yield return waitForSeconds;

        text.text = "我可是期待很久了呢";
        yield return waitForSeconds;

        text.text = "再也沒有人可以打擾我們了~❤";
        yield return waitForSeconds;

        text.text = "來～讓我們開始吧";
        yield return waitForSeconds;

        TextEndEvent.Invoke();
        TextEndEvent = null;
    }

    IEnumerator ShowHappyEndText(Text text)
    {
        text.text = "阿~~又輸了";
        yield return waitForSeconds;

        text.text = "我總是贏不了你呢";
        yield return waitForSeconds;

        text.text = "快樂的時光總是過得特別快呢";
        yield return waitForSeconds;

        text.text = "我們要永遠在一起玩哦~";
        yield return waitForSeconds;

        text.text = "呵呵...呵呵呵...哈哈哈哈哈哈哈哈哈哈哈";
        yield return waitForSeconds;

        TextEndEvent.Invoke();
        TextEndEvent = null;
    }

    IEnumerator ShowTrueEndText(Text text)
    {
        text.text = "......疑？我怎麼在自己房間？我不是應該在學校內嗎？";
        yield return waitForSeconds;

        text.text = "(轉頭)你怎麼了！發生什麼事！為什麼衣服上都是血！";
        yield return waitForSeconds;

        ChangeSceneEvent.Invoke();
        ChangeSceneEvent = null;

        text.text = "我...不...什麼...怎麼會...";
        yield return waitForSeconds;
        text.text = "......";
        yield return new WaitForSeconds(1.0f);

        text.text = "是...是我做的嗎...是我殺了你嗎...";
        yield return waitForSeconds;

        text.text = "對不起對不起對不起對不起對不起對不起對不起對不起 都怪我 對不起對不起對不起 太愛你了 對不起對不起對不起對不起對不起";
        yield return waitForSeconds;

        TextEndEvent.Invoke();
        TextEndEvent = null;
    }

    IEnumerator ShowBadEndText(Text text)
    {
        text.text = "阿~~~你輸啦～❤";
        yield return waitForSeconds;

        text.text = "你還記得我們的約定吧";
        yield return waitForSeconds;

        text.text = "你說過我們會一直在一起的";
        yield return waitForSeconds;

        text.text = "我們可是打過勾勾了";
        yield return waitForSeconds;

        text.text = "說謊的人可要吞一千根針呦～❤";
        yield return waitForSeconds;
        text.text = "好啦～該來履行約定囉，诶嘿～❤";
        yield return waitForSeconds;


        ChangeSceneEvent.Invoke();
        ChangeSceneEvent = null;
        yield return new WaitForSeconds(1.0f);

        TextEndEvent.Invoke();
        TextEndEvent = null;
    }

    #endregion
}