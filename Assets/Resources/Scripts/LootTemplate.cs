using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class LootTemplate : MonoBehaviour
    {
        private SpriteRenderer _renderer;

        public Loot Loot { get; private set; }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            /* animation on drop?
            float dropForce = 15;
            Vector2 dropDirection = new(Random.Range(-1,1), Random.Range(-1,1));
            spawned.GetComponent<Rigidbody2D>().AddForce(dropDirection*dropForce, ForceMode2D.Impulse); */
        }

        public void SetLoot(Loot loot)
        {
            _renderer.sprite = loot.Sprite;
            Loot = loot;
            gameObject.SetActive(true);
        }

        public void Collect()
        {
            gameObject.SetActive(false);
        }
    }
}