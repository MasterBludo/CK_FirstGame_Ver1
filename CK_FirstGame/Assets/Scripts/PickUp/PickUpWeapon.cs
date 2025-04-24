using CK_FirstGame.Shooting;
using UnityEngine;

namespace CK_FirstGame.PickUp
{
    public class PickUpWeapon : PickUpItem
    {
        [SerializeField]
        private Weapon _weaponPrefab;

        public override void PickUp(BaseCharacter character)
        {
            base.PickUp(character);
            character.SetWeapon(_weaponPrefab);
        }
    }
}