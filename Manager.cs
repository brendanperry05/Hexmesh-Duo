using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int duel = 0;
    float health = 1;
    public Image healthBarFill;
    float health1 = 1;
    public Image healthBarFill1;
    public float healthBlockIncrease = 0.25f;
    public GameObject parent;
    public Animator healthBarAnimator;
    public Animator healthBarAnimator1;
    //int green = 255;
    public Button color1;
    public GameObject color1Bar;
    public Button color2;
    public GameObject color2Bar;
    public Button color3;
    public GameObject color3Bar;
    public Button color11;
    public GameObject color11Bar;
    public Button color22;
    public GameObject color22Bar;
    public Button color33;
    public GameObject color33Bar;
    public TextMeshProUGUI countdown;
    public CubeSpawner leftSpawner;
    public CubeSpawner rightSpawner;
    public Play playButton;
    bool gameOver = false;
    public Animator leftScore;
    public Animator rightScore;

    private static Manager _instance;
    public TextMeshProUGUI winText;

    public static Manager Instance {
        get {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start() {
        //healthBarAnimator = parent.GetComponent<Animator>();
    }

    public void PauseGame() {
        Time.timeScale = 0;

    }

    IEnumerator ColorTimer2() {
       // countdown.text = "3";
        yield return new WaitForSeconds(.5f);
        //countdown.text = "2";
       // yield return new WaitForSeconds(1);
        //countdown.text = "1";                
       // yield return new WaitForSeconds(1);
       // countdown.text = "";   
        color11.interactable = true;
        color22.interactable = true;
        color33.interactable = true;
    }

    public void SelectColor2(int button) {
        color11.interactable = false;
        color22.interactable = false;
        color33.interactable = false;

        
        if(button == 0) {
            color11Bar.SetActive(true);
            color22Bar.SetActive(false);
            color33Bar.SetActive(false);
            //EventSystem.current.SetSelectedGameObject(color1.gameObject);
        } else if(button == 1) {
            color11Bar.SetActive(false);
            color22Bar.SetActive(true);
            color33Bar.SetActive(false);
            //EventSystem.current.SetSelectedGameObject(color2.gameObject);
        } else {
            color11Bar.SetActive(false);
            color22Bar.SetActive(false);
            color33Bar.SetActive(true);
            //EventSystem.current.SetSelectedGameObject(color3.gameObject);
        }
        
        StartCoroutine(ColorTimer2());
    }

    IEnumerator ColorTimer() {
       // countdown.text = "3";
        yield return new WaitForSeconds(.5f);
        //countdown.text = "2";
       // yield return new WaitForSeconds(1);
        //countdown.text = "1";                
       // yield return new WaitForSeconds(1);
       // countdown.text = "";   
        color1.interactable = true;
        color2.interactable = true;
        color3.interactable = true;
    }

    public void SelectColor(int button) {
        color1.interactable = false;
        color2.interactable = false;
        color3.interactable = false;

        
        if(button == 0) {
            color1Bar.SetActive(true);
            color2Bar.SetActive(false);
            color3Bar.SetActive(false);
            //EventSystem.current.SetSelectedGameObject(color1.gameObject);
        } else if(button == 1) {
            color1Bar.SetActive(false);
            color2Bar.SetActive(true);
            color3Bar.SetActive(false);
            //EventSystem.current.SetSelectedGameObject(color2.gameObject);
        } else {
            color1Bar.SetActive(false);
            color2Bar.SetActive(false);
            color3Bar.SetActive(true);
            //EventSystem.current.SetSelectedGameObject(color3.gameObject);
        }
        
        StartCoroutine(ColorTimer());
    }

    public void ResetHealth() {
        health = 1;
    }

    public void HealhBlock(Vector3 pos) {
        UpdateHealth(healthBlockIncrease, pos);
    }

    public float GetHealth() {
        return health;
    }

    public void UpdateHealth(float amount, Vector3 pos) {
        if(duel == 0) {
            if(gameOver == false) {
                health += amount;

                if(health > 1) {
                    health = 1;
                }
            
                healthBarFill.fillAmount = health;
                //green -= 10;
                healthBarFill.color = new Color(1, health, 0, 1);
            
                if(amount < 0) {
                    healthBarAnimator.Play("ShakeHealthBar", -1, 0f);
                }

                if(health <= 0) {
                    gameOver = true;
                    
                    playButton.GameOver();
                    //leftSpawner.CloseTextFile();
                    //rightSpawner.CloseTextFile();
                    ScoreManager.Instance.UpdateHighScore();
                    if(leftSpawner != null) {
                        leftSpawner.CloseTextFile();
                        rightSpawner.CloseTextFile();
                    }
                }
            }
        }
        else {
            if(pos.x < 0) {
                if(gameOver == false) {
                health += amount;

                if(health > 1) {
                    health = 1;
                }
            
                healthBarFill.fillAmount = health;
                //green -= 10;
                healthBarFill.color = new Color(1, health, 0, 1);
            
                if(amount < 0) {
                    healthBarAnimator.Play("ShakeHealthBar", -1, 0f);
                }

                if(health <= 0) {
                    gameOver = true;
                    if(health1 != 0) {
                        winText.text = "RIGHT WINS";
                        winText.GetComponent<Animator>().Play("timerStart");
                    }
                    else {
                        winText.text = "DRAW";
                        winText.GetComponent<Animator>().Play("timerStart");
                    }
                    playButton.GameOver();
                    //leftSpawner.CloseTextFile();
                    //rightSpawner.CloseTextFile();
                    ScoreManager.Instance.UpdateHighScore();
                    if(leftSpawner != null) {
                        leftSpawner.CloseTextFile();
                        rightSpawner.CloseTextFile();
                    }
                }
            }
        }
        else {
            if(gameOver == false) {
                health1 += amount;

                if(health1 > 1) {
                    health1 = 1;
                }
            
                healthBarFill1.fillAmount = health1;
                //green -= 10;
                healthBarFill1.color = new Color(1, health1, 0, 1);
            
                if(amount < 0) {
                    healthBarAnimator1.Play("ShakeHealthBar", -1, 0f);
                }

                    if(health1 <= 0) {
                        gameOver = true;
                        if(health != 0) {
                            winText.text = "LEFT WINS";
                            winText.GetComponent<Animator>().Play("timerStart");
                        }
                        else {
                            winText.text = "DRAW";
                            winText.GetComponent<Animator>().Play("timerStart");
                        }
                        playButton.GameOver();
                        //leftSpawner.CloseTextFile();
                        //rightSpawner.CloseTextFile();
                        ScoreManager.Instance.UpdateHighScore();
                        if(leftSpawner != null) {
                            leftSpawner.CloseTextFile();
                            rightSpawner.CloseTextFile();
                        }
                    }
                }
            }
        }
    }

    public bool getGameStatus() {
        return gameOver;
    }

    public void setGameStatus() {
        gameOver = true;
    }

    public void LoadHome() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
}
