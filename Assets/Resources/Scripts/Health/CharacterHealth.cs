using UnityEngine;

namespace MolecularSurvivors
{
    public class CharacterHealth : Health/* , IDisposable */
    {
        private readonly HealthEventBus _eventBus;
        
        private CharacterData _data;

        public CharacterHealth(Transform damagable, HealthEventBus eventBus) : base(damagable)
        {
            //Construct(changesDisplay);
            _eventBus = eventBus;
            //_eventBus.Subscribe<HealthChangedSignal>(OnHealthChanged);
        }

        public void Set(CharacterData data)
        {
            _data = data;
            MaxAmount = _data.MaxHealth;
            base.Set();
        }

        public override void ApplyDamage(int damage)
        {
            base.ApplyDamage(damage);
            OnHealthChanged();
        }

        public override void Recover(int amount)
        {
            base.Recover(amount);
            OnHealthChanged();
        }

        private void OnHealthChanged()
        {
            _eventBus.Invoke(new HealthChangedSignal(this, LastChange));
        }
    }
}
