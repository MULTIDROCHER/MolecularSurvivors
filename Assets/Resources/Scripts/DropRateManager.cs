using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class DropRateManager : MonoBehaviour
    {
        [SerializeField] private List<DroppableItem> _drops;

        private void OnDestroy()
        {
            float dropRate = Random.Range(0, 100);

            foreach (var drop in _drops)
            {
                if (dropRate < drop.Rate)
                {
                    Instantiate(drop.Prefab, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
