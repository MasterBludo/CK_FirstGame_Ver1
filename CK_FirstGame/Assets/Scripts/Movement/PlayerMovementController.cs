using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace CK_FirstGame.Movement
{
    public class PlayerMovementController : CharacterMovementController
    {
        [SerializeField]
        private float _movementBoost = 2f;

        private float _boostValue = 1f;
        protected float _currentBoostTime = 0f;
        private float _boostTimer;
        public float CurrentSpeed { get; private set; }

        private CharacterMovementController _controller;

        private new void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _controller = GetComponent<CharacterMovementController>();
        }

        private new void Update()
        {
            CurrentSpeed = _speed * _boostValue;

            _currentBoostTime += Time.deltaTime;
            if (_currentBoostTime > _boostTimer)
            {
                _boostValue = 1f;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                CurrentSpeed *= _movementBoost;
            }

            Translate(CurrentSpeed);

            if (_maxRadiansDelta > 0f && LookDirection != Vector3.zero)
                Rotate();
        }

        public void BoostUp(float Booster, float BoostTimerSec)
        {
            _boostValue = Booster;
            _boostTimer = BoostTimerSec;
            _currentBoostTime = 0f;
        }
    }
}
