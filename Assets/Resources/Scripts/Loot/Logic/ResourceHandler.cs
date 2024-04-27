using UnityEngine;

namespace MolecularSurvivors
{
    public class ResourceHandler
    {
        private readonly GoldCollector _goldCollector;
        private LevelProgress _progressChanger;
        private Player _player;

        public ResourceHandler(GoldCollector goldCollector, LevelProgress progressChanger, Player player)
        {
            _goldCollector = goldCollector;
            _progressChanger = progressChanger;
            _player = player;
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