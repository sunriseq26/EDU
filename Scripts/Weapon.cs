using System;
using ObjectPool;
using UnityEngine;

namespace Asteroids
{
    public abstract class Weapon : MonoBehaviour
    {

        public abstract void Move(Transform barrel, float forceBullet);
        
        private void OnBecameInvisible()
        {
            ReturnToPool();
        }

        private void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);

            Destroy(gameObject);
        }
    }
}