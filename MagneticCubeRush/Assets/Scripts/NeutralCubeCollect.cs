using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralCubeCollect : MonoBehaviour
{

   public void CollectedByNPC(int incrementValue)
   {
      ScoreTexts.Instance().IncreaseEnemyScore(incrementValue);
   }

   public void CollectedByPlayer(int incrementValue)
   {
      ScoreTexts.Instance().IncreasePlayerScore(incrementValue);
   }
}
