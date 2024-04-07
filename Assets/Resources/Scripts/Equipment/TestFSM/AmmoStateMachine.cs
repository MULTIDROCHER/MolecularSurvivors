using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class AmmoStateMachine
    {
        private readonly List<AmmoState> _states = new();
        private readonly Ammo _ammo;

        private AmmoState _currentState;

        public AmmoStateMachine(Ammo ammo)
        {
            _ammo = ammo;

            foreach (var state in _ammo.Data.States)
            {
                state.GetAmmo(ammo);
                _states.Add(state);
            }
        }

        public void Enter(int index = 0)
        {
            Debug.Log("Enter state: " + index);
            _currentState = _states[index];
            _currentState.Enter();

            if (index == 0)
            {
                _ammo.transform.position = _currentState.ShootFromPlayer ? _ammo.Weapon.transform.position : _ammo.GetRandomPosition();
                _ammo.gameObject.SetActive(true);
            }
            _currentState.Completed += OnStateCompleted;
        }

        public void Update(float deltaTime) => _currentState?.Update(deltaTime);

        public void Exit()
        {
            _currentState.Completed -= OnStateCompleted;
            _currentState = null;
        }

        private void OnStateCompleted()
        {
            Debug.Log("State completed: " + _currentState);
            _currentState.Completed -= OnStateCompleted;
            var newIndex = _states.IndexOf(_currentState) + 1;

            if (newIndex <= _states.Count - 1)
                Enter(newIndex);
            else
                _ammo.Deactivate();
        }
    }
}