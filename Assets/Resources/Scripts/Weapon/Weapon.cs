using UnityEngine;

namespace MolecularSurvivors
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _delay;

        protected PlayerMovement PlayerMovement;

        private float _currentDelay;

        protected virtual void Start()
        {
            _currentDelay = _delay;
            PlayerMovement = GetComponentInParent<PlayerMovement>();
        }

        protected virtual void Update()
        {
            _currentDelay -= Time.deltaTime;

            if (_currentDelay <= 0)
                Attack();
        }

        protected virtual void Attack()
        {
            _currentDelay = _delay;
        }
    }
}