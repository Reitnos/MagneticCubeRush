using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class RewardedVideoManager : MonoBehaviour
{
    private void Awake()
    {
        if (Random.Range(0, 2) == 0) // 1 in 3 chance spawn rewarded interstitial video.
        {
            AdManager.instance.ShowRewardedInterstitialAd();
        }
    }
}
