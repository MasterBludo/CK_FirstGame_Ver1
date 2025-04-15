using UnityEngine;

namespace CK_FirstGame.Shooting
{
    public class Weapon : MonoBehaviour
    {
        [field: SerializeField]
        public Bullet BulletPrefab { get; private set; }

        [field: SerializeField]
        public float ShootRadius { get; private set; } = 5f;

        [field: SerializeField]
        public float ShootFrequencySec { get; private set; } = 1f;

        [SerializeField]
        private float _damage = 1f;

        [SerializeField]
        private float _bulletMaxFlyDistance = 10f;

        [SerializeField]
        private float _bulletFlySpeed = 10f;

        [SerializeField]
        private Transform _bulletSpawnPoint;


        public void Shoot(Vector3 targetPoint) 
        {
            var bullet = Instantiate(BulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);

            var target = targetPoint - _bulletSpawnPoint.position;
            target.y = 0;
            target.Normalize();

            bullet.Initialize(target, _bulletMaxFlyDistance, _bulletFlySpeed, _damage);
        }
    }
}