using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    public float time = 1f;
    void OnEnable() {
        StartCoroutine(disable());
    }
    IEnumerator disable() {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
