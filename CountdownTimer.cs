using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI minutes;
    public TextMeshProUGUI seconds;
    public TextMeshProUGUI colon;
    int time = 59;
    public Play play;
    public TextMeshProUGUI leftScore;
    public TextMeshProUGUI rightScore;
    public Manager manager;
    public TextMeshProUGUI winText;
    void Start()
    {
        minutes.SetText("2");
        seconds.SetText("00");

        StartCoroutine(WinText());
        StartCoroutine(CountDown());
    }

    IEnumerator WinText() {
        yield return new WaitForSeconds(2);
        winText.SetText("SET");
        yield return new WaitForSeconds(1);
        winText.SetText("DUEL");
        yield return new WaitForSeconds(1);
        winText.GetComponent<Animator>().Play("timerAnim");
    }

    public void GameOver() {
        StopAllCoroutines();
        minutes.gameObject.GetComponent<Animator>().Play("timerAnim");
        seconds.gameObject.GetComponent<Animator>().Play("timerAnim");
        colon.gameObject.GetComponent<Animator>().Play("timerAnim");
    }

    IEnumerator CountDown() {
        yield return new WaitForSeconds(3);
        seconds.SetText(time.ToString());
        minutes.SetText("1");

        while(time > 0) {
            yield return new WaitForSeconds(1);
            time--;
            if(time < 10) {
                seconds.SetText("0" + time.ToString());
            }
            else {
                seconds.SetText(time.ToString());
            }
        }

        yield return new WaitForSeconds(1);
        time = 59;
        seconds.SetText(time.ToString());
        minutes.SetText("0");

        while(time > 0) {
            yield return new WaitForSeconds(1);
            time--;
            if(time < 10) {
                seconds.SetText("0" + time.ToString());
            }
            else {
                seconds.SetText(time.ToString());
            }
        }

        manager.setGameStatus();
        play.GameOver();

        if(int.Parse(leftScore.text) > int.Parse(rightScore.text)) {
            winText.text = "LEFT WINS";
            winText.GetComponent<Animator>().Play("timerStart");
        }
        else if (int.Parse(leftScore.text) < int.Parse(rightScore.text)) {
            winText.text = "RIGHT WINS";
            winText.GetComponent<Animator>().Play("timerStart");
        }
        else {
            winText.text = "DRAW";
            winText.GetComponent<Animator>().Play("timerStart");
        }
    }
}
