using GoogleMobileAds.Api;
using System;
using System.Security.Cryptography;
using JetBrains.Annotations;
using UnityEngine;


public class AdManager : MonoBehaviour
{   
    // app Id : ca-app-pub-4459057399404876~9582555673
    // banner id test : ca-app-pub-3940256099942544/6300978111
    // rewarded Interstitial id test : ca-app-pub-3940256099942544/5354046379
    
    
    private string AppId  = "ca-app-pub-4459057399404876~9582555673";
    private string BannerAdId  = "ca-app-pub-3940256099942544/6300978111";
    private string RewardedInterstitialAdId = "ca-app-pub-3940256099942544/5354046379";
    
    private BannerView bannerAd; 
    private RewardedInterstitialAd rewardedInterstitialAd;

    public static AdManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
       // else if (this != instance)
       // {
       //     Destroy(gameObject);
       // }
    }

    void Start()
    {
        MobileAds.Initialize(status => { });
        
        this.RequestRewardedInterstitial();
    }

    

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }
    public void RequestBanner()
    {
        
        this.bannerAd = new BannerView(BannerAdId, AdSize.SmartBanner, AdPosition.Bottom);
        
        this.bannerAd.LoadAd(CreateAdRequest());
    }



    public void RequestRewardedInterstitial()
    {
       RewardedInterstitialAd.LoadAd(RewardedInterstitialAdId, CreateAdRequest(), adLoadCallback);
    }
    public void ShowRewardedInterstitialAd()
    {
        if (rewardedInterstitialAd != null)
        { 
            rewardedInterstitialAd.Show(null);
            RequestRewardedInterstitial();
        }
        else
        {
            
           
            RequestRewardedInterstitial();
            Invoke("ShowRewardedInterstitial",1f);
        }
    }
    private void adLoadCallback(RewardedInterstitialAd ad, AdFailedToLoadEventArgs error)
    {
        if (error == null)
        {
            rewardedInterstitialAd = ad;
         
        }
    }
    
    
    

    
}
