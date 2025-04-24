using CK_FirstGame.Movement;
using CK_FirstGame.Shooting;
using CK_FirstGame.PickUp;
using UnityEngine;

namespace CK_FirstGame
{
    [RequireComponent(typeof(CharacterMovementController), typeof(ShootingController))]
    public abstract class BaseCharacter : MonoBehaviour
    {
        [SerializeField]
        private Weapon _baseWeaponPrefab;

        [SerializeField]
        private Transform _hand;

        [SerializeField]
        private float _health = 5f;

        private IMovementDirectionSource _movementDirectionSource;

        private CharacterMovementController _characterMovementController;
        private PlayerMovementController _playerMovementController;
        private ShootingController _shootingController;

        protected void Awake() {
            _movementDirectionSource = GetComponent<IMovementDirectionSource>();

            _characterMovementController = GetComponent<CharacterMovementController>();
            _playerMovementController = GetComponent<PlayerMovementController>();
            _shootingController = GetComponent<ShootingController>();
        }
        protected void Start() 
        {
            SetWeapon(_baseWeaponPrefab);
        }

        protected void Update()
        {
            var direction = _movementDirectionSource.MovementDirection;
            var lookDirection = direction;
            if(_shootingController.HasTarget)
                lookDirection = (_shootingController.TargetPosition - transform.position).normalized;

            _characterMovementController.MovementDirection = direction;
            _characterMovementController.LookDirection = lookDirection;

            if(_health <= 0f)
                Destroy(gameObject);
        }

        protected void OnTriggerEnter(Collider other) 
        {
            if(LayerUtils.IsBullet(other.gameObject))
            {
                var bullet = other.gameObject.GetComponent<Bullet>();

                _health -= bullet.Damage;

                Destroy(other.gameObject);
            }
            else if(LayerUtils.IsWeapon(other.gameObject))
            {
                var pickUp = other.gameObject.GetComponent<PickUpWeapon>();
                pickUp.PickUp(this);
            
                Destroy(other.gameObject);
            }
            else if (LayerUtils.IsPickUp(other.gameObject))
            {
                var boost = other.gameObject.GetComponent<MovementBooster>();
                _playerMovementController.BoostUp(boost.Booster, boost.BoostTimeSec);
                boost.PickUp(this);

                Destroy(other.gameObject);

            }
        }

        public void SetWeapon(Weapon weapon)
        {
            _shootingController.SetWeapon(weapon, _hand);
        }
    }
}
