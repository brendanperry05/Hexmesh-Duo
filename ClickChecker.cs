using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ClickChecker : MonoBehaviour
{
    public int currentLevel = 0;
    public Animator volume;
    public Animator leaderboard;
    public Animator play;
    public Animator plane;
    public Animator score;
    public Animator highScore;

    public Color lightBlue;
    public Animator solo;
    public Animator duo;

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject flood;
    public GameObject duel;

    public GameObject[] levelArray;
    int selectedLevel = 0;
    public int players = 1;

    public Animator leftSide;

    public Play playScript;

    private int interactable = 0;

    public TextMeshProUGUI starHelp;
    public Image leftStar;
    public Image rightStar;
    public Image centerStar;

    public Animator health1;
    public Animator health2;
    public Animator score1;
    public Animator score2;
    public Animator leftScore;
    public Animator rightScore;
    public Animator winText;
    public void EnableStars() {
        leftStar.gameObject.SetActive(true);
        rightStar.gameObject.SetActive(true);
        centerStar.gameObject.SetActive(true);
        starHelp.gameObject.SetActive(true);
        StartCoroutine(InDelay());
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit)) {
                if(hit.collider.gameObject.name == "Play") {
                    hit.collider.gameObject.GetComponent<Animator>().Play("color-play", -1, 0);
                    play.Play("fade-out");
                    volume.Play("volume-out");
                    leaderboard.Play("leaderboard-out");
                    plane.Play("rotate-plane");
                    leftSide.Play("leftSideOut", -1, 0);
                    score.Play("ScoreOut");
                    highScore.Play("highScoreOut");
                    if(winText != null) {
                        winText.Play("timerAnim");
                    }
                    //playScript.OnClick();

                    // find which scene to load
                    if(players == 1) {
                        if(one.activeInHierarchy) {
                            StartCoroutine(LoadScene("Level1"));
                        }
                        else if(two.activeInHierarchy) {
                            StartCoroutine(LoadScene("Level2"));
                        }
                        else if(three.activeInHierarchy) {
                            StartCoroutine(LoadScene("Level3"));
                        }
                        else if(four.activeInHierarchy) {
                            StartCoroutine(LoadScene("Level4"));
                        }
                        else if(five.activeInHierarchy) {
                            StartCoroutine(LoadScene("Level5"));
                        }
                        else if(flood.activeInHierarchy) {
                            StartCoroutine(LoadScene("Endless"));
                        }
                    }
                    else {
                        if(one.activeInHierarchy) {
                            StartCoroutine(LoadScene("Level1Duo"));
                        }
                        else if(two.activeInHierarchy) {
                            StartCoroutine(LoadScene("Level2Duo"));
                        }
                        else if(three.activeInHierarchy) {
                            StartCoroutine(LoadScene("Level3Duo"));
                        }
                        else if(four.activeInHierarchy) {
                            StartCoroutine(LoadScene("Level4Duo"));
                        }
                        else if(five.activeInHierarchy) {
                            StartCoroutine(LoadScene("Level5Duo"));
                        }
                        else if(flood.activeInHierarchy) {
                            StartCoroutine(LoadScene("EndlessDuo"));
                        }
                        else if(duel.activeInHierarchy) {
                            StartCoroutine(LoadScene("Duel"));
                        }
                    }
                }
                else if(hit.collider.gameObject.name == "Volume") {
                    hit.collider.gameObject.GetComponent<Animator>().Play("volume-color", -1 , 0);
                }
                else if(hit.collider.gameObject.name == "Leaderboard") {
                    hit.collider.gameObject.GetComponent<Animator>().Play("leaderboard-color", -1, 0);
                }
                else if(hit.collider.gameObject.name == "triangle_left") {
                    if (interactable == 0) {
                        interactable = 1;
                        hit.collider.gameObject.GetComponent<Animator>().Play("color-play", -1, 0);
                        StartCoroutine(DelayLeft());
                    }
                }
                else if(hit.collider.gameObject.name == "triangle_right") {
                    if (interactable == 0) {
                        interactable = 1;
                        hit.collider.gameObject.GetComponent<Animator>().Play("color-play", -1, 0);
                        StartCoroutine(DelayRight());
                    }
                }
                else if(hit.collider.gameObject.name == "duo") {
                    if (players == 1) {
                        players = 2;
                        duo.Play("whiteIn", -1, 0);
                        solo.Play("blueIn", -1, 0);
                        StarController(currentLevel);
                    }
                }
                else if(hit.collider.gameObject.name == "solo") {
                    if (players == 2 && selectedLevel != 6) {
                        players = 1;
                        solo.Play("whiteIn", -1, 0);
                        duo.Play("blueIn", -1, 0);
                        StarController(currentLevel);
                    }
                }
            }
        }
    }

    void Start() {
        selectedLevel = currentLevel;
        
        if(centerStar.gameObject.activeInHierarchy) {
            StartCoroutine(InDelay());
        }
    }

    IEnumerator InDelay() {
        yield return new WaitForSeconds(1f);
        StarController(currentLevel);
    }

    IEnumerator LoadScene(string scene) {
        leftStar.gameObject.GetComponent<Animator>().Play("StarOut");
        rightStar.gameObject.GetComponent<Animator>().Play("StarOut");
        centerStar.gameObject.GetComponent<Animator>().Play("StarOut");
        starHelp.gameObject.GetComponent<Animator>().Play("StarTipOut");

        if(health1 != null) {
            health1.Play("HealthBarReverse", -1, 0);
            health2.Play("HealthBarReverse", -1, 0);
            score2.Play("ScoreOut", -1, 0);
            score1.Play("ScoreOut", -1, 0);
            leftScore.Play("ScoreOut", -1, 0);;
            rightScore.Play("ScoreOut", -1, 0);
        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scene);
    }

    IEnumerator DelayLeft() {
        levelArray[selectedLevel].GetComponent<Animator>().Play("Out", -1, 0);
        yield return new WaitForSeconds(.20f);
        levelArray[selectedLevel].SetActive(false);
        changeLevelArray(0);
        levelArray[selectedLevel].SetActive(true);
        levelArray[selectedLevel].GetComponent<Animator>().Play("In", -1, 0);
        interactable = 0;
        StarController(selectedLevel);
    }

    IEnumerator DelayRight() {
        levelArray[selectedLevel].GetComponent<Animator>().Play("Out", -1, 0);
        yield return new WaitForSeconds(.20f);
        levelArray[selectedLevel].SetActive(false);
        changeLevelArray(1);
        levelArray[selectedLevel].SetActive(true);
        levelArray[selectedLevel].GetComponent<Animator>().Play("In", -1, 0);
        interactable = 0;
        StarController(selectedLevel);
    }

    public void StarController(int level) {
        int score = PlayerPrefs.GetInt("highScore_" + level + "_" + players, 0);
        int stars = 0;

        int oneStar = 0;
        int twoStar = 0;
        int threeStar = 0;

        if (players == 1) {
            if (one.activeInHierarchy) {
                oneStar = 2000;
                twoStar = 2500;
                threeStar = 3000;
            }
            else if (two.activeInHierarchy) {
                oneStar = 2500;
                twoStar = 3000;
                threeStar = 4000;
            }
            else if (three.activeInHierarchy) {
                oneStar = 3500;
                twoStar = 4000;
                threeStar = 4500;
            }
            else if (four.activeInHierarchy) {
                oneStar = 8;
                twoStar = 20;
                threeStar = 30;
            }
            else if (five.activeInHierarchy) {
                oneStar = 1;
                twoStar = 20;
                threeStar = 30;
            }
            else if (flood.activeInHierarchy) {
                oneStar = 90;
                twoStar = 20;
                threeStar = 30;
            }
        } else {
            if (one.activeInHierarchy) {
                oneStar = 3;
                twoStar = 7;
                threeStar = 11;
            }
            else if (two.activeInHierarchy) {
                oneStar = 7;
                twoStar = 20;
                threeStar = 30;
            }
            else if (three.activeInHierarchy) {
                oneStar = 15;
                twoStar = 20;
                threeStar = 30;
            }
            else if (four.activeInHierarchy) {
                oneStar = 8;
                twoStar = 20;
                threeStar = 30;
            }
            else if (five.activeInHierarchy) {
                oneStar = 1;
                twoStar = 20;
                threeStar = 30;
            }
            else if (flood.activeInHierarchy) {
                oneStar = 10;
                twoStar = 20;
                threeStar = 30;
            }
            else if (duel.activeInHierarchy) {
                oneStar = 10;
                twoStar = 20;
                threeStar = 30;
            }
        }
       // else {
       // will go for co-op levels
       // }

        print(score);

        if (score > oneStar) {
            stars++;
            // give star 1
            if (leftStar.color != Color.yellow) {
                StartCoroutine(starAnimLeft(Color.yellow));
            }
        }
        else {
            if (leftStar.color != Color.white) {
                StartCoroutine(starAnimLeft(Color.white));
            }
        }
        if (score > twoStar) {
            stars++;
            // give star 2
            if (rightStar.color != Color.yellow) {
                StartCoroutine(starAnimRight(Color.yellow));
            }
        }
        else {
            if (rightStar.color != Color.white) {
                StartCoroutine(starAnimRight(Color.white));
            }
        }
        if (score > threeStar) {
            stars++;
            // give star 3
            if (centerStar.color != Color.yellow) {
                StartCoroutine(starAnimCenter(Color.yellow));
            }
        }
        else {
            if (centerStar.color != Color.white) {
                StartCoroutine(starAnimCenter(Color.white));
            }
        }

        if (stars == 0) {
            starHelp.SetText("Next Star\n" + oneStar + " points");

            if(starHelp.gameObject.GetComponent<RectTransform>().anchoredPosition.x == 150) {
                //starHelp.GetComponent<Animator>().Play("StarTip", -1, 0);
            }
        }
        else if (stars == 1) {
            starHelp.SetText("Next Star\n" + twoStar + " points");

            if(starHelp.gameObject.GetComponent<RectTransform>().anchoredPosition.x == 150) {
                //starHelp.GetComponent<Animator>().Play("StarTip", -1, 0);
            }
        }
        else if (stars == 2) {
            starHelp.SetText("Next Star\n" + threeStar + " points");

            if(starHelp.gameObject.GetComponent<RectTransform>().anchoredPosition.x == 150) {
                //starHelp.GetComponent<Animator>().Play("StarTip", -1, 0);
            }
        }
        else {
            //starHelp.GetComponent<Animator>().Play("StarTipOut", -1, 0);
            starHelp.SetText("All Stars Collected");
        }
    }

    IEnumerator starAnimLeft(Color color) {
        leftStar.GetComponent<Animator>().Play("starFlip", -1, 0);
        yield return new WaitForSeconds(.10f);
        leftStar.color = color;
    }

    IEnumerator starAnimRight(Color color) {
        rightStar.GetComponent<Animator>().Play("starFlip", -1, 0);
        yield return new WaitForSeconds(.10f);
        rightStar.color = color;
    }

    IEnumerator starAnimCenter(Color color) {
        centerStar.GetComponent<Animator>().Play("starFlip", -1, 0);
        yield return new WaitForSeconds(.10f);
        centerStar.color = color;
    }

    private void changeLevelArray(int dir) {

        if(dir == 0) {
            // go left
            if (selectedLevel == 0) {
                selectedLevel = levelArray.Length - 1;
            }
            else {
                selectedLevel--;
            }
        }
        else {
            // go right
            if(selectedLevel == levelArray.Length - 1) {
                selectedLevel = 0;
            } 
            else {
                selectedLevel++;
            }
        }

        if(selectedLevel == 6 && players == 1) {
            players = 2;
            duo.Play("whiteIn", -1, 0);
            solo.Play("blueIn", -1, 0);
        }
        /*
        else if(players == 2) {
            if(selectedLevel == 5 || selectedLevel == 0) {
                players = 1;
                duo.Play("blueIn", -1, 0);
                solo.Play("whiteIn", -1, 0);
            }
        }*/
    }
}
