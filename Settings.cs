using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    int volume;
    public Sprite on;
    public Sprite off;
    public Button button;
    void Start() {
        volume = PlayerPrefs.GetInt("volume", 1);

        if(volume == 1) {
            button.image.sprite = on;
        } else {
            button.image.sprite = off;
        }
    }
    public void OnClick() {
        if(AudioListener.volume == 0) {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("volume", 1);
            button.image.sprite = on;
        } else {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("volume", 0);
            button.image.sprite = off;
        }
    }
}
