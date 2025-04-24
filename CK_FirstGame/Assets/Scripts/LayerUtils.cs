using UnityEngine;

namespace CK_FirstGame
{
    public static class LayerUtils
    {
        public const string BulletLayerName = "Bullet";
        public const string PlayerLayerName = "Player";
        public const string EnemyLayerName = "Enemy";
        public const string PickUpLayerName = "PickUpItems";
        public const string WeaponLayerName = "Weapon";

        public static readonly int BulletLayer = LayerMask.NameToLayer(BulletLayerName);
        public static readonly int PickUpLayer = LayerMask.NameToLayer(PickUpLayerName);
        public static readonly int WeaponLayer = LayerMask.NameToLayer(WeaponLayerName);
        public static readonly int TargetMask = LayerMask.GetMask(EnemyLayerName, PlayerLayerName);

        public static bool IsBullet(GameObject other) => other.layer == BulletLayer;
        //Альтернативная запись методов
        //public static bool IsEnemy(GameObject other)
        //{
        //    return other.Layer == EnemyLayer;
        //}
        public static bool IsPickUp(GameObject other) => other.layer == PickUpLayer;
        public static bool IsWeapon(GameObject other) => other.layer == WeaponLayer;

    }
}