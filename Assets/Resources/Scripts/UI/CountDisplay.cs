using TMPro;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(TMP_Text))]
    public class CountDisplay : MonoBehaviour
    {
        [SerializeField] private CountableType _type;

        private TMP_Text _text;
        private int _count;
        private CountDisplayEventBus _eventBus;

        [Inject]
        private void Construct(CountDisplayEventBus eventBus)
        { 
            _text = GetComponent<TMP_Text>();
            _eventBus = eventBus;
            _eventBus.Subscribe<CountChangedSignal>(OnCountChanged, _type);
        }

        private void OnCountChanged(CountChangedSignal signal)
        {
            if (signal.Type == _type)
                UpdateCount(signal.Value);
        }

        private void OnDisable() => _eventBus.Unsubscribe<CountChangedSignal>(OnCountChanged, _type);

        public void UpdateCount(int amount)
        {
            _count += amount;
            _text.text = _count.ToString();
        }
    }
}