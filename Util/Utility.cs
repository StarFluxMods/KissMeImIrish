using Kitchen;
using StPatricksDay.Systems;
using Unity.Entities;
using UnityEngine;

namespace StPatricksDay.Util
{
    public class Utility
    {
        public static CGroupReward CalculateLuckyIncome(Entity e, CGroupReward reward)
        {
            if (StaticSystem.instance.IsGroupAtLuckyTable(e))
            {
                int coinFlip = Random.Range(1, 5);
                Mod.Logger.LogInfo(coinFlip);
                if (coinFlip != 1) return reward;
                reward.Amount *= 2;
            }
            return reward;
        }
    }
}