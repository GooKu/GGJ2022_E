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

    [SerializeField] private GameModeSO so = null;
    [SerializeField] private Tilemap map = null;
    [SerializeField] private PlayerSettings p1 = null;
    [SerializeField] private PlayerSettings p2 = null;

    [SerializeField] private CountdownSystem m_CountdownSystem;
    [SerializeField] private GameResult m_GameResult;
    [SerializeField] private SceneController m_SceneController;
    [SerializeField] private InputManager m_inputManager;


    private void Start()
    {
        Init(p1);
        Init(p2);
        ShowScore();
        m_CountdownSystem.GameResultEvent += SetGameResultAndGoToResultScene;

        m_inputManager.SettingP1(p1.Player);

        if (so.GameMode == GameMode.StoryMode)
        {
            var autoPlayer = gameObject.AddComponent<AutoPlayer>();
            autoPlayer.Bind(p2.Player);
            autoPlayer.Run();
        }
        else
        {
            m_inputManager.SettingP2(p2.Player);
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

        if (tile == playerSetting.Tile)
        {
            return;
        }

        map.SetTile(coor, playerSetting.Tile);

        if (player == PlayerType.P1)
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
        //m_GameResult.SetFinalResult(p1.Score, p2.Score);
        CheckFinalWhoWin();

        //if(so.GameMode == GameMode.StoryMode)
        //{
        //    m_SceneController.SwitchScene("StoryGameOver");
        //}
        //else if(so.GameMode == GameMode.MuletplayerMode)
        //{
        //    m_SceneController.SwitchScene("PVPGameOver");
        //}
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            m_GameResult.SetWinner(PlayerType.P1);
        }

        if (Input.GetKey(KeyCode.G))
        {
            m_GameResult.SetWinner(PlayerType.P2);
        }

        if (Input.GetKey(KeyCode.B))
        {
            m_GameResult.SetWinner(PlayerType.Non);
        }
    }

    private void CheckFinalWhoWin()
    {
        if (p1.Score > p2.Score)
        {
            m_GameResult.SetWinner(PlayerType.P1);
        }
        else if (p1.Score < p2.Score)
        {
            m_GameResult.SetWinner(PlayerType.P2);
        }
        else if (p1.Score == p2.Score)
        {
            m_GameResult.SetWinner(PlayerType.Non);
        }
    }

    private void shoot(PlayerControl player)
    {
        var setting = player.Player == PlayerType.P1 ? p1 : p2;
        var bullet = GameObject.Instantiate(setting.bullet, setting.Player.transform.position, Quaternion.identity);
        bullet.OnTileChangeEvent += UpdateTile;
        bullet.OnHitPlayerEvent += hitPlayer;
        bullet.Init(map);
    }

    private void hitPlayer(Bullet bullet, PlayerControl player)
    {
        var winner = player.Player == PlayerType.P1 ? PlayerType.P2 : PlayerType.P1;
        m_GameResult.SetWinner(winner);
    }
}