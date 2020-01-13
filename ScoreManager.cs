using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int score;
    int highScore;
    int multiplier = 1;
    int previous = -1;

    bool isSuper = false;

    public int level = 1;
    public int players = 1;
    public int superTime = 5;

    float super = 0;
    public int superScore = 1000;

    public int scoreBlockIncrease = 25;

    public Color orangeIsh;
    public Color purply;
    public Color blueGreen;
    public Color darkGray;

    public GameObject text;
    GameObject[] texts;
    public Image superFill;
    public Button superButton;
    public TextMeshProUGUI superText;
    public Animator outline;

    public ShootingController leftPlayer;
    public ShootingController rightPlayer;

    private static ScoreManager _instance;
    private Manager manager;
    
    // ONLY FOR DUEL
    public int duel = 0;
    int score1;
    int multiplier1 = 1;
    int previous1 = -1;
    bool isSuper1 = false;
    float super1 = 0;
    public Image superFill1;
    public Button superButton1;
    public TextMeshProUGUI superText1;
    public Animator outline1;

    public static ScoreManager Instance {
        get {
            return _instance;
        }
    }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI highScoreText;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private void Start()
    {
        manager = GetComponent<Manager>();
        highScore = PlayerPrefs.GetInt("highScore" + "_" + level + "_" + players, 0);
        highScoreText.SetText("BEST: " + highScore.ToString());

        texts = new GameObject[20];

        for(int i = 0; i < 20; i++) {
            GameObject obj = Instantiate(text);
            obj.SetActive(false);
            texts[i] = obj;
        }
    }

    public void AddScore(int amount, int block, Vector3 pos) {
        if(manager.getGameStatus() == false) {
            if(duel == 0) {
                if(previous == block) {
                    multiplier++;

                    if(pos != new Vector3(0, 0, 0)) {
                        for(int i = 0; i < texts.Length; i++) {
                            if(!texts[i].activeInHierarchy) {
                                texts[i].transform.position = new Vector3(0, 0, 0);
                                texts[i].GetComponentsInChildren<Transform>()[1].position = pos;
                                texts[i].GetComponentsInChildren<TextMeshPro>()[0].text = "x" + multiplier;
                                texts[i].SetActive(true);
                                texts[i].GetComponent<Animator>().Play("MultiplierAnim", -1, 0f);
                                break;
                            }
                        }
                    }
                } else {
                    multiplier = 1;
                }

                score += amount * multiplier;

                if(isSuper == false) {
                    super += amount * multiplier;
                    superFill.fillAmount = super / superScore;
                }

                if(superFill.fillAmount == 1) {
                    superText.color = Color.white;
                    outline.Play("Outline");
                } 

                previous = block;

                UpdateScore();
            }
            else {
                if(pos.x < 0) {
                    if(previous1 == block) {
                        multiplier1++;

                    if(pos != new Vector3(0, 0, 0)) {
                        for(int i = 0; i < texts.Length; i++) {
                            if(!texts[i].activeInHierarchy) {
                                texts[i].transform.position = new Vector3(0, 0, 0);
                                texts[i].GetComponentsInChildren<Transform>()[1].position = pos;
                                texts[i].GetComponentsInChildren<TextMeshPro>()[0].text = "x" + multiplier1;
                                texts[i].SetActive(true);
                                texts[i].GetComponent<Animator>().Play("MultiplierAnim", -1, 0f);
                                break;
                            }
                        }
                    }
                } else {
                    multiplier1 = 1;
                }

                score1 += amount * multiplier1;

                if(isSuper1 == false) {
                    super1 += amount * multiplier1;
                    superFill1.fillAmount = super1 / superScore;
                }

                if(superFill1.fillAmount == 1) {
                    superText1.color = Color.white;
                    outline1.Play("Outline");
                } 

                previous1 = block;

                UpdateScore1();
                }
                else {
                    if(previous == block) {
                        multiplier++;

                    if(pos != new Vector3(0, 0, 0)) {
                        for(int i = 0; i < texts.Length; i++) {
                            if(!texts[i].activeInHierarchy) {
                                texts[i].transform.position = new Vector3(0, 0, 0);
                                texts[i].GetComponentsInChildren<Transform>()[1].position = pos;
                                texts[i].GetComponentsInChildren<TextMeshPro>()[0].text = "x" + multiplier;
                                texts[i].SetActive(true);
                                texts[i].GetComponent<Animator>().Play("MultiplierAnim", -1, 0f);
                                break;
                            }
                        }
                    }
                } else {
                    multiplier = 1;
                }

                score += amount * multiplier;

                if(isSuper == false) {
                    super += amount * multiplier;
                    superFill.fillAmount = super / superScore;
                }

                if(superFill.fillAmount == 1) {
                    superText.color = Color.white;
                    outline.Play("Outline");
                } 

                previous = block;

                UpdateScore();
                }
            }
        }
    }

    public void SUPER() {
        if(superFill.fillAmount == 1) {
            isSuper = true;
            super = 0;
            superText.color = new Color(0.1568628f, 0.1568628f, 0.1568628f);
            outline.Play("New State");
            superFill.fillAmount = 0;
            // do it
            leftPlayer.CancelInvoke();
            leftPlayer.InvokeRepeating("SUPER", 0, .10f);
            rightPlayer.CancelInvoke();
            rightPlayer.InvokeRepeating("SUPER", 0, .10f);
            StartCoroutine(Super());
        }
    }

    public void SUPER1() {
        if(superFill1.fillAmount == 1) {
            isSuper1 = true;
            super1 = 0;
            superText1.color = new Color(0.1568628f, 0.1568628f, 0.1568628f);
            outline1.Play("New State");
            superFill1.fillAmount = 0;
            // do it
            leftPlayer.CancelInvoke();
            leftPlayer.InvokeRepeating("SUPER", 0, .10f);
            StartCoroutine(Super1());
        }
    }

    public void SUPER2() {
        if(superFill.fillAmount == 1) {
            isSuper = true;
            super = 0;
            superText.color = new Color(0.1568628f, 0.1568628f, 0.1568628f);
            outline.Play("New State");
            superFill.fillAmount = 0;
            // do it
            rightPlayer.CancelInvoke();
            rightPlayer.InvokeRepeating("SUPER", 0, .10f);
            StartCoroutine(Super2());
        }
    }

    IEnumerator Super1() {
        yield return new WaitForSeconds(superTime);

        leftPlayer.CancelInvoke();
        leftPlayer.Resume();

        yield return new WaitForSeconds(2);
        isSuper1 = false;
    }

    IEnumerator Super2() {
        yield return new WaitForSeconds(superTime);

        rightPlayer.CancelInvoke();
        rightPlayer.Resume();
        
        yield return new WaitForSeconds(2);
        isSuper = false;
    }

    public bool IsSuper() {
        if(duel == 1) {
            if(isSuper == true || isSuper1 == true) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return isSuper;
        }
    }

    IEnumerator Super() {
        /*ShootingController[] scLeft;
        ShootingController[] scRight;

        scLeft = leftPlayer.GetComponentsInChildren<ShootingController>();
        scRight = rightPlayer.GetComponentsInChildren<ShootingController>();
        */
        yield return new WaitForSeconds(superTime);

        leftPlayer.CancelInvoke();
        leftPlayer.Resume();

        rightPlayer.CancelInvoke();
        rightPlayer.Resume();

        /*foreach (ShootingController sc in scLeft) {
            sc.CancelInvoke();
         //   print("HI");
            sc.SUPER();
        //}

        //foreach (ShootingController sc in scRight) {
            sc.CancelInvoke();
            sc.SUPER();
        } */

        yield return new WaitForSeconds(2);
        isSuper = false;
    }

    public void ScoreBlock(Vector3 pos) {
        if(Manager.Instance.getGameStatus() == false) {
            AddScore(scoreBlockIncrease, -1, pos);
            for(int i = 0; i < texts.Length; i++) {
                if(!texts[i].activeInHierarchy) {
                    texts[i].transform.position = new Vector3(0, 0, 0);
                    texts[i].GetComponentsInChildren<Transform>()[1].position = pos;
                    texts[i].GetComponentInChildren<TextMeshPro>().text = "+" + scoreBlockIncrease;
                    texts[i].SetActive(true);
                    texts[i].GetComponent<Animator>().Play("MultiplierAnim", -1, 0f);
                    break;
                }
            }
        }
    }

    public void ResetScore() {
        score = 0;
        highScoreText.SetText("BEST: " + highScore.ToString());
        UpdateScore();
    }

    private void UpdateScore() {
        scoreText.SetText(score.ToString());
    }

    private void UpdateScore1() {
        scoreText1.SetText(score1.ToString());
    }

    public void UpdateHighScore() {
        if(score > highScore && level != 6) {
            PlayerPrefs.SetInt("highScore" + "_" + level + "_" + players, score);
            highScore = score;
            scoreText.gameObject.GetComponent<Animator>().Play("scorePulse");
            //upload to gamecenter
        }
    }
}
