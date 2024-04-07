using UnityEngine;

namespace MolecularSurvivors
{
    public class Ammo : MonoBehaviour
    {
        private AmmoStateMachine _stateMachine;
        private Sprite _defaultSprite;

        public SpriteRenderer Renderer { get; private set; }
        public Weapon Weapon { get; private set; }
        public AmmoData Data { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamagable damagable))
                damagable.ApplyDamage(Weapon.GetDamage());
        }

        private void Update() => _stateMachine.Update(Time.deltaTime);

        public void Initialize(Weapon weapon)
        {
            Renderer = GetComponent<SpriteRenderer>();
            _defaultSprite = Renderer.sprite;
            Weapon = weapon;
            Data = weapon.Data.AmmoData;
            _stateMachine = new(this);
        }

        public void Activate() => _stateMachine.Enter();

        public void Deactivate()
        {
            Debug.Log("Deactivate");
            _stateMachine.Exit();
            Renderer.sprite = _defaultSprite;
            gameObject.SetActive(false);
        }

        public Vector3 GetRandomPosition()
        {
            var controller = Weapon.Controller as WeaponController;

            if (controller != null)
                return controller.GetRandomShootPoint();
            else
                return Weapon.transform.position;
        }
    }
}