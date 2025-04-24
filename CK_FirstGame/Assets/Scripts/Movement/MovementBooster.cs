using CK_FirstGame.PickUp;
using UnityEngine;

namespace CK_FirstGame.Movement
{
    public class MovementBooster : PickUpItem
    {
        [field: SerializeField]
        public float Booster { get; private set; }
        [field: SerializeField]
        public float BoostTimeSec { get; private set; }

        public override void PickUp(BaseCharacter character)
        {
            base.PickUp(character);
        }
    }
}
