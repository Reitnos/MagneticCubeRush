using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerAdManager : MonoBehaviour
{
    private void Awake()
    {
        AdManager.instance.RequestBanner();
    }
}
