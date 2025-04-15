using UnityEngine;

namespace CK_FirstGame.Movement 
{
    public interface IMovementDirectionSource{
        Vector3 MovementDirection{ get; }
    }
}