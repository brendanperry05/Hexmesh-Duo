using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Gamecenter : MonoBehaviour
{
    void Awake() {
        GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
        Social.localUser.Authenticate(CheckAuth);
    }

    void CheckAuth(bool success) {
        if(success) {
            print("Authorized");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnClick()
    {
        
    }
}
