using UnityEngine;

namespace Code
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory, data.Player.Position);
            var playerHealthInitialization = new PlayerHealthController(data.Player);
            var enemyFactory = new EnemyFactory(data.Enemy);
            var enemyInitialization = new EnemyInitialization(enemyFactory);
            var interactiveObjectFactory = new InteractiveObjectFactory(data.InteractiveObject);
            var displayInfo = new DisplayInfo(playerHealthInitialization);
            var interactiveObjectInitialization = new InteractiveObjectInitialization(interactiveObjectFactory, displayInfo, playerHealthInitialization);
            // var displayInfo = new DisplayInfo();
            // var view = interactiveObjectInitialization.Initialization(displayInfo);
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(enemyInitialization);
            controllers.Add(interactiveObjectInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer().transform, data.Player));
            controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies(), playerInitialization.GetPlayer().transform));
            controllers.Add(new CameraController(playerInitialization.GetPlayer().transform, camera.transform));
            controllers.Add(new EndGameController(enemyInitialization.GetEnemies(), playerInitialization.GetPlayer().gameObject.GetInstanceID()));
        }
    }
}