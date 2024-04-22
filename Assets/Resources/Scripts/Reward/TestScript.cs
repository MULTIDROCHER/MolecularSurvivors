using UnityEngine;

namespace MolecularSurvivors
{
    public class TestScript : MonoBehaviour
    {
        [SerializeField] private RewardWindow _rewardWindow;

        public void OpenRewards() => _rewardWindow.gameObject.SetActive(true);
    }
}
