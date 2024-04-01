using UnityEngine;

namespace MolecularSurvivors
{
    public class ResourceHandler
    {
        private readonly LevelProgress _progressChanger;
        private readonly Health _health;
        private readonly GoldCollector _goldCollector;

        public ResourceHandler(LevelProgress progress, Health health, GoldCollector goldCollector)
        {
            _progressChanger = progress;
            _health = health;
            _goldCollector = goldCollector;
            Debug.Log("handler loaded");
        }

        public void GetLoot(Loot loot)
        {
            switch (loot)
            {
                case ExpirienceLoot expLoot:
                    _progressChanger.IncreaseExperience(expLoot.Exp);
                    break;
                case HpLoot hpLoot:
                    _health.Recover(hpLoot.HealthRecovery);
                    break;
                case GoldLoot goldLoot:
                    _goldCollector.Collect(goldLoot.Gold);
                    break;
                default:
                    Debug.Log("uknown loot type");
                    break;
            }
        }
    }
}