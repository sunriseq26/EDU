using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _health;
        [SerializeField] private float _maximumHealth;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _forceBullet;
        private Camera _camera;
        private Ship _ship;
        private Rigidbody2D _rigidbodyPlayer;
        private PlayerHealth _playerHealth;
        private int _damage = 2;

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration, _rigidbodyPlayer);
            var rotation = new RotationShip(transform);
            _rigidbodyPlayer = GetComponent<Rigidbody2D>();
            _ship = new Ship(moveTransform, rotation, _rigidbodyPlayer);
            _playerHealth = new PlayerHealth(_health, _maximumHealth);
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToViewportPoint(transform.position);
            _ship.Rotation(direction);
            
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = new Shoot(_bullet, _barrel, _forceBullet);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _playerHealth.TakeDamage(_damage);
        }
    }
}
