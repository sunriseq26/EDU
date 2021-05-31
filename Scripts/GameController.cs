using Asteroids.Abstrac_Factory;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _forceBullet;
        
        private IDataPlayer _dataPlayer;
        //private GameObject _player;
        private Camera _camera;
        private Enemy _enemy;
        private Ship _ship;
        
        private void Start()
        {
            EnemyPool enemyPool = new EnemyPool(5);
            _enemy = enemyPool.GetEnemy("Asteroid");
            _enemy.transform.position = Vector3.one;
            _enemy.gameObject.SetActive(true);
            
            Enemy.Factory = new CometFactory();
            Enemy.Factory.Create(new Health(100.0f, 10.0f));
            
            //return;
            
            _dataPlayer = GetComponent<IDataPlayer>();
            Debug.Log(_dataPlayer.Speed);
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(_dataPlayer.TransformPlayer, _dataPlayer.Speed, _dataPlayer.Acceleration, _dataPlayer.RigidbodyPlayer);
            var rotation = new RotationShip(_dataPlayer.TransformPlayer);
            
            _ship = new Ship(moveTransform, rotation, _dataPlayer.RigidbodyPlayer);
            
            return;
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));
            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));
            
            Enemy.Factory = new AsteroidFactory();
            Enemy.Factory.Create(new Health(100.0f, 100.0f));

            var platform = new PlatformFactory().Create(Application.platform);

            System.Threading.ThreadPool.QueueUserWorkItem(state => Debug.Log("Test"));
        }
        
        private void Update()
        {
            
            
            //return;
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

            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = new Shoot(_bullet, _barrel, _forceBullet);
            }
        }
    }
}
