using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public Animator volume;
    public Animator leaderboard;
    public Animator PlayButton;
    public GameObject HealthBar;
    public CubeSpawner LeftSpawner;
    public ScriptedSpawner left;
    public CubeSpawner RightSpawner;
    public ScriptedSpawner right;
    public ShootingController LeftPlayer;
    public ShootingController LeftPlayer1;
    public ShootingController LeftPlayer2;
    public ShootingController RightPlayer;
    public ShootingController RightPlayer1;
    public ShootingController RightPlayer2;
    public GameObject Color1;
    public GameObject Color2;
    public GameObject Color3;
    public GameObject Color11;
    public GameObject Color22;
    public GameObject Color33;
    public Animator plane;
    public Animator SuperButton;
    public Animator SuperButton1;
    public Animator score;
    public Animator score1;
    public Animator highScore;
    public Animator leftSide;

    public ClickChecker cc;
    public Animator pause;
    public Animator healthObject;
    public Animator healthObject1;
    public FloodManager flood;
    public DoubleSpawner ds;
    public CountdownTimer ct;
    public DoubleSpawner doubleSpawner;

    void Start() {
       /*GameCenter.GetComponent<Animator>().Play("GameCenterReverse");
        Settings.GetComponent<Animator>().Play("SettingsReverse");
        PlayButton.GetComponent<Animator>().Play("PlayReverse");*/
        ScoreManager.Instance.ResetScore();

        HealthBar.GetComponentInParent<Animator>().Play("HealthBarTransition", -1, 0f);
        if(healthObject != null) {
            healthObject.GetComponent<Animator>().Play("HealthBarTransition", -1, 0f);
            healthObject1.GetComponent<Animator>().Play("HealthBarTransition", -1, 0f);
        }
        Color1.GetComponent<Animator>().Play("Color1Transition", -1, 0f);
        Color2.GetComponent<Animator>().Play("Color2Transition", -1, 0f);
        Color3.GetComponent<Animator>().Play("Color3Transition", -1, 0f);

        if(Color11 != null) {
            Color11.GetComponent<Animator>().Play("Color1Transition", -1, 0f);
            Color22.GetComponent<Animator>().Play("Color2Transition", -1, 0f);
            Color33.GetComponent<Animator>().Play("Color3Transition", -1, 0f);
            if(SuperButton1 != null) {
                SuperButton1.Play("SuperIn", -1, 0);
            }
        }
        SuperButton.Play("SuperIn", -1, 0);
        score.Play("ScoreIn");
        if(score1 != null) {
            score1.Play("ScoreIn");
        }
        highScore.Play("highScoreIn");

        if(left != null) {
            left.StartGame();
            right.StartGame();
        }
        else {
            if(RightSpawner != null) {
                LeftSpawner.StartGame();
                RightSpawner.StartGame();
            }
            else {
                ds.StartGame();
            }
        }
    }

    int over = 0;

    public void GameOver() {
        if(over == 0) {
            /*GameCenter.GetComponent<Animator>().Play("GameCenter");
            Settings.GetComponent<Animator>().Play("Settings");
            PlayButton.GetComponent<Animator>().Play("Play");*/
            HealthBar.GetComponent<Animator>().Play("HealthBarReverse", -1, 0);
        
            Color1.GetComponent<Animator>().Play("Colo1Reverse");
            Color2.GetComponent<Animator>().Play("Color2Reverse");
            Color3.GetComponent<Animator>().Play("Color3Reverse");
            if(LeftSpawner != null) {
                LeftSpawner.CancelInvoke();
                RightSpawner.CancelInvoke();
            }
            else if(left != null) {
                left.CancelInvoke();
                right.CancelInvoke();
            }
            else {
                doubleSpawner.CancelInvoke();
            }

            LeftPlayer.CancelInvoke();
            RightPlayer.CancelInvoke();

            if(LeftPlayer1 != null) {
                LeftPlayer1.CancelInvoke();
                RightPlayer1.CancelInvoke();
                LeftPlayer2.CancelInvoke();
                RightPlayer2.CancelInvoke();
            }

            plane.Play("game-end", -1, 0);
            leaderboard.gameObject.SetActive(true);
            leaderboard.Play("leaderboard-in");
            volume.gameObject.SetActive(true);
            volume.Play("volume-in");
            PlayButton.gameObject.SetActive(true);
            PlayButton.Play("play-in");
            leftSide.gameObject.SetActive(true);
            leftSide.Play("leftSideIn");
            //score.Play("ScoreOut");
            //highScore.Play("highScoreOut");
            SuperButton.Play("SuperOut");
            pause.Play("PauseOut");
            cc.EnableStars();
            //plane.Play("PlanePositionReverse");
            over++; 

            if(flood != null) {
                flood.Stop();
            }

            if(ct != null) {
                ct.GameOver();
            }

            if(Color11 != null) {
                Color11.GetComponent<Animator>().Play("Colo1Reverse", -1, 0f);
                Color22.GetComponent<Animator>().Play("Color2Reverse", -1, 0f);
                Color33.GetComponent<Animator>().Play("Color3Reverse", -1, 0f);

                if(SuperButton1 != null) {
                    SuperButton1.Play("SuperOut", -1, 0);
                    int score = PlayerPrefs.GetInt("highScore_6_2", 0);
                    score++;
                    PlayerPrefs.SetInt("highScore_6_2", score);
                }
            }
        }
    }
}
