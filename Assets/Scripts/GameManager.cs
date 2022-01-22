using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    [Serializable]
    public class PlayerSettings
    {
        public PlayerControl Player;
        public TileBase Tile;
        public Bullet bullet;
        public Text ScoreText;
        public int Score;

        public void ShowScore()
        {
            ScoreText.text = Score.ToString();
        }
    }
    [SerializeField]
    private GameModeSO so = null;
    [SerializeField]
    private Tilemap map = null;
    [SerializeField]
    private PlayerSettings p1 = null;
    [SerializeField]
    private PlayerSettings p2 = null;

    [SerializeField] private CountdownSystem m_CountdownSystem;
    [SerializeField] private GameResult m_GameResult;
    [SerializeField] private SceneController m_SceneController;


    private void Start()
    {
        Init(p1);
        Init(p2);
        ShowScore();
        m_CountdownSystem.GameResultEvent += SetGameResultAndGoToResultScene;

        if(so.GameMode == GameMode.StoryMod)
        {
            var autoPlayer = gameObject.AddComponent<AutoPlayer>();
            autoPlayer.Bind(p2.Player);
            autoPlayer.Run();
        }
    }

    public void Init(PlayerSettings setting)
    {
        setting.Score = 9 * 8;
        setting.Player.OnShootEvent += shoot;
    }

    public void ShowScore()
    {
        p1.ShowScore();
        p2.ShowScore();
    }

    public void UpdateTile(Vector3Int coor, PlayerType player)
    {
        var tile = map.GetTile(coor);
        var playerSetting = player == PlayerType.P1 ? p1 : p2;

        if(tile == playerSetting.Tile) { return; }

        map.SetTile(coor, playerSetting.Tile);

        if(player == PlayerType.P1)
        {
            p1.Score += 1;
            p2.Score -= 1;
            ShowScore();
            return;
        }

        p1.Score -= 1;
        p2.Score += 1;
        ShowScore();
    }

    public void SetGameResultAndGoToResultScene()
    {
        m_GameResult.GetFinalBothScore(p1.Score, p2.Score);
        m_SceneController.SwitchScene("StoryGameOver");
    }

    private void shoot(PlayerControl player)
    {
        var setting = player.Player == PlayerType.P1 ? p1 : p2;
        var bullet = GameObject.Instantiate(setting.bullet, setting.Player.transform.position, Quaternion.identity);
        bullet.OnTileChangeEvent += UpdateTile;
        bullet.Init(map);
    }
}
