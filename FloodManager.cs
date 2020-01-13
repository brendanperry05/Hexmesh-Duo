using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodManager : MonoBehaviour
{
    public CubeSpawner leftSpawner;
    public CubeSpawner rightSpawner;
    public DoubleSpawner doubleSpawner;

    public GameObject leftPlayer;
    public GameObject rightPlayer;

    public ScoreManager sm;

    ShootingController[] scLeft;
    ShootingController[] scRight;

    public float rate2 = .9f;
    public float rate3 = .8f;
    public float rate4 = .7f;
    public float rate5 = .6f;

    public float middleRate2 = .9f;
    public float middleRate3 = .8f;
    public float middleRate4 = .7f;
    public float middleRate5 = .6f;

    public float sideRate1 = .9f;
    public float sideRate2 = .8f;

    // Start is called before the first frame update
    void Start()
    {
        scLeft = leftPlayer.GetComponentsInChildren<ShootingController>();
        scRight = rightPlayer.GetComponentsInChildren<ShootingController>();
        StartCoroutine(Timer());
    }

    public void Stop() {
        StopAllCoroutines();
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(5f);
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(10);

        if(sm.IsSuper()) {
            yield return new WaitForSeconds(2f);
            
            if(sm.IsSuper()) {
                yield return new WaitForSeconds(2f);

                if(sm.IsSuper()) {
                    yield return new WaitForSeconds(2f);

                    if(sm.IsSuper()) {
                        yield return new WaitForSeconds(2f);

                        if(sm.IsSuper()) {
                            yield return new WaitForSeconds(2f);
                        }
                    }
                }
            }
        }
        // level2
        if(doubleSpawner == null) {
            leftSpawner.CancelInvoke();
            leftSpawner.spawnRate = rate2;
            rightSpawner.CancelInvoke();
            rightSpawner.spawnRate = rate2;
            leftSpawner.Resume();
            rightSpawner.Resume();
        }
        else {
            doubleSpawner.CancelInvoke();
            doubleSpawner.spawnRate = rate2;
            doubleSpawner.Resume();
        }

        scLeft[0].CancelInvoke();
        scLeft[0].spawnRate = middleRate2;
        scLeft[0].Resume();

        scRight[0].CancelInvoke();
        scRight[0].spawnRate = middleRate2;
        scRight[0].Resume();


        yield return new WaitForSeconds(30);
        // level3

        if(sm.IsSuper()) {
            yield return new WaitForSeconds(1f);
            
            if(sm.IsSuper()) {
                yield return new WaitForSeconds(1f);

                if(sm.IsSuper()) {
                    yield return new WaitForSeconds(1f);

                    if(sm.IsSuper()) {
                        yield return new WaitForSeconds(1f);

                        if(sm.IsSuper()) {
                            yield return new WaitForSeconds(1f);
                        }
                    }
                }
            }
        }

        if(doubleSpawner == null) {
            leftSpawner.CancelInvoke();
            leftSpawner.spawnRate = rate3;
            rightSpawner.CancelInvoke();
            rightSpawner.spawnRate = rate3;
            leftSpawner.Resume();
            rightSpawner.Resume();
        }
        else {
            doubleSpawner.CancelInvoke();
            doubleSpawner.spawnRate = rate3;
            doubleSpawner.Resume();
        }

        scLeft[0].CancelInvoke();
        scLeft[0].spawnRate = middleRate3;
        scLeft[0].Resume();

        scRight[0].CancelInvoke();
        scRight[0].spawnRate = middleRate3;
        scRight[0].Resume();

        scLeft[1].enabled = true;
        scLeft[2].enabled = true;

        scRight[1].enabled = true;
        scRight[2].enabled = true;

        yield return new WaitForSeconds(30);
        // level4

        if(sm.IsSuper()) {
            yield return new WaitForSeconds(1f);
            
            if(sm.IsSuper()) {
                yield return new WaitForSeconds(1f);

                if(sm.IsSuper()) {
                    yield return new WaitForSeconds(1f);

                    if(sm.IsSuper()) {
                        yield return new WaitForSeconds(1f);

                        if(sm.IsSuper()) {
                            yield return new WaitForSeconds(1f);
                        }
                    }
                }
            }
        }

        if(doubleSpawner == null) {
            leftSpawner.CancelInvoke();
            leftSpawner.spawnRate = rate4;
            rightSpawner.CancelInvoke();
            rightSpawner.spawnRate = rate4;
            leftSpawner.Resume();
            rightSpawner.Resume();
        }
        else {
            doubleSpawner.CancelInvoke();
            doubleSpawner.spawnRate = rate4;
            doubleSpawner.Resume();
        }

        scLeft[0].CancelInvoke();
        scLeft[0].spawnRate = middleRate4;
        scLeft[0].Resume();

        scLeft[1].CancelInvoke();
        scLeft[1].spawnRate = sideRate1;
        scLeft[1].Resume();

        scLeft[2].CancelInvoke();
        scLeft[2].spawnRate = sideRate1;
        scLeft[2].Resume();

        scRight[0].CancelInvoke();
        scRight[0].spawnRate = middleRate4;
        scRight[0].Resume();

        scRight[1].CancelInvoke();
        scRight[1].spawnRate = sideRate1;
        scRight[1].Resume();

        scRight[2].CancelInvoke();
        scRight[2].spawnRate = sideRate1;
        scRight[2].Resume();

        yield return new WaitForSeconds(30);
        // level5

        if(sm.IsSuper()) {
            yield return new WaitForSeconds(1f);
            
            if(sm.IsSuper()) {
                yield return new WaitForSeconds(1f);

                if(sm.IsSuper()) {
                    yield return new WaitForSeconds(1f);

                    if(sm.IsSuper()) {
                        yield return new WaitForSeconds(1f);

                        if(sm.IsSuper()) {
                            yield return new WaitForSeconds(1f);
                        }
                    }
                }
            }
        }

        if(doubleSpawner == null) {
            leftSpawner.CancelInvoke();
            leftSpawner.spawnRate = rate5;
            rightSpawner.CancelInvoke();
            rightSpawner.spawnRate = rate5;
            leftSpawner.Resume();
            rightSpawner.Resume();
        }
        else {
            doubleSpawner.CancelInvoke();
            doubleSpawner.spawnRate = rate5;
            doubleSpawner.Resume();
        }

        scLeft[0].CancelInvoke();
        scLeft[0].spawnRate = middleRate5;
        scLeft[0].Resume();

        scLeft[1].CancelInvoke();
        scLeft[1].spawnRate = sideRate2;
        scLeft[1].Resume();

        scLeft[2].CancelInvoke();
        scLeft[2].spawnRate = sideRate2;
        scLeft[2].Resume();

        scRight[0].CancelInvoke();
        scRight[0].spawnRate = middleRate5;
        scRight[0].Resume();

        scRight[1].CancelInvoke();
        scRight[1].spawnRate = sideRate2;
        scRight[1].Resume();

        scRight[2].CancelInvoke();
        scRight[2].spawnRate = sideRate2;
        scRight[2].Resume();
    }
}
