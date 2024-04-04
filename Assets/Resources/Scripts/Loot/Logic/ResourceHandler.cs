using UnityEngine;

namespace MolecularSurvivors
{
    public class ResourceHandler
    {
        private readonly LevelProgress _progressChanger;
        private readonly Player _player;
        private readonly GoldCollector _goldCollector;

        public ResourceHandler(LevelProgress progress, Player player, GoldCollector goldCollector)
        {
            _progressChanger = progress;
            _player = player;
            _goldCollector = goldCollector;
        }

        public void GetLoot(Loot loot)
        {
            switch (loot)
            {
                case ExpirienceLoot expLoot:
                    _progressChanger.IncreaseExperience(expLoot.Exp);
                    break;
                case HpLoot hpLoot:
                    _player.Recover(hpLoot.HealthRecovery);
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