using UnityEngine;

namespace GameAssets.Scripts
{
    public class ObjectFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float followSpeed;
        [SerializeField] private Vector3 offset;
        private Transform _self;

        private void Awake()
        {
            _self = transform;
        }

        private void Update()
        {
            if (target)
                _self.position = Vector3.Lerp(_self.position, target.position+offset, followSpeed * Time.deltaTime);
        }
    }
}