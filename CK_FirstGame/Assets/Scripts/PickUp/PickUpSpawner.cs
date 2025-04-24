using UnityEditor;
using UnityEngine;

namespace CK_FirstGame.PickUp
{
    public class PickUpSpawner : MonoBehaviour
    {
        [SerializeField]
        private PickUpItem _pickUpPrefab;

        [SerializeField]
        private float _range = 2f;

        [SerializeField]
        private int _maxCount = 2;

        private float _spawnIntervalSeconds;

        private float _currentSpawnTimeSeconds;
        private int _currentCount;

        private void Awake()
        {
            _spawnIntervalSeconds = Random.Range(7f, 15f);
        }
        void Update()
        {
            if(_currentCount < _maxCount)
            {
                _currentSpawnTimeSeconds += Time.deltaTime;
                if(_currentSpawnTimeSeconds > _spawnIntervalSeconds)
                {
                    _spawnIntervalSeconds = Random.Range(7f, 15f);
                    _currentSpawnTimeSeconds = 0;
                    _currentCount++;

                    var randomPointInsideRange = Random.insideUnitCircle * _range;
                    var randomPosition = new Vector3(randomPointInsideRange.x, 0.3f, randomPointInsideRange.y) + transform.position;
                    
                    var pickUp = Instantiate(_pickUpPrefab, randomPosition, Quaternion.identity, transform);
                    pickUp.OnPickedUp += OnItemPickedUp;
                }
            }
        }

        private void OnItemPickedUp(PickUpItem pickedUpItem)
        {
            _currentCount--;
            pickedUpItem.OnPickedUp -= OnItemPickedUp;
        }

        protected void OnDrawGizmos() 
        {
            var cashedColor = Handles.color;
            Handles.color = Color.green;
            Handles.DrawWireDisc(transform.position, Vector3.up, _range);
            Handles.color = cashedColor;
        }
    }
}