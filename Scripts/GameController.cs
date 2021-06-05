using System;
using System.Collections.Generic;
using Asteroids.Object_Pool;
using ObjectPool;
using UnityEngine;
using Random = System.Random;

namespace Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _forceBullet;
        
        private IDataPlayer _dataPlayer;
        private GameObject _player;
        private Rigidbody2D _rigidbodyPlayer;
        
        private Camera _camera;
        private Enemy _enemy;
        private Ship _ship;

        private List<Asteroid> _asteroids;
        private float _randomDirection;

        private ViewServices _viewServices;
        private Bullet[] _weaponBullets;
        
        private void Start()
        {
            _randomDirection = Convert.ToSingle(GetRandomNumber(-1, 1));
            
            EnemyPool enemyPool = new EnemyPool(5);
            _enemy = enemyPool.GetEnemy("Asteroid");
            _enemy.transform.position = Vector3.one;
            _enemy.gameObject.SetActive(true);
            
            Enemy.Factory = new CometFactory();
            Enemy.Factory.Create(new Health(100.0f, 10.0f));
            
            //return;
            _player = FindObjectOfType<Player>().gameObject;
            _dataPlayer = _player.GetComponent<IDataPlayer>();
            _rigidbodyPlayer = _player.GetComponent<Rigidbody2D>();
            
            
            
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(_player.transform, _dataPlayer.Speed, _dataPlayer.Acceleration, _rigidbodyPlayer);
            var rotation = new RotationShip(_player.transform);
            
            _ship = new Ship(moveTransform, rotation, _rigidbodyPlayer);

            _viewServices = new ViewServices();
            
            return;
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));
            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));
            
            Enemy.Factory = new AsteroidFactory();
            Enemy.Factory.Create(new Health(100.0f, 100.0f));

            System.Threading.ThreadPool.QueueUserWorkItem(state => Debug.Log("Test"));
        }
        
        private void Update()
        {
            _enemy.Move(_randomDirection, _randomDirection, Time.deltaTime);
            
            MovementAndRotationPlayer();

            Shooting();
        }

        private void MovementAndRotationPlayer()
        {
            var direction = Input.mousePosition - _camera.WorldToViewportPoint(_dataPlayer.TransformPlayer.position);
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
        }

        private void Shooting()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _viewServices.Create(_bullet, _barrel);
                //var temAmmunition = new Shoot(_bullet, _barrel, _forceBullet);
                //_bulletsPool.Create(_bullet);
            }

            _weaponBullets = FindObjectsOfType<Bullet>();

            if (_weaponBullets.Length > 0)
            {
                foreach (var bullet in _weaponBullets)
                {
                    bullet.Move(_barrel, _forceBullet);
                }
            }
            
        }
        
        public double GetRandomNumber(double minimum, double maximum)
        { 
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
