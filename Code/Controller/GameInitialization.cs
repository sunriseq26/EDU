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
            var enemyFactory = new EnemyFactory(data.Enemy);
            var enemyInitialization = new EnemyInitialization(enemyFactory);
            var playerHealthInitialization = new PlayerHealthController(data.Player, enemyInitialization.GetEnemies(), playerInitialization.GetPlayer().transform);
            var interactiveObjectFactory = new InteractiveObjectFactory(data.InteractiveObject);
            var displayInfo = new DisplayInfo(playerHealthInitialization);
            var interactiveObjectInitialization = new InteractiveObjectInitialization(interactiveObjectFactory, displayInfo, playerHealthInitialization, data.InteractiveObject);
            var miniMapInitialization = new MiniMapInitialization(playerInitialization.GetPlayer().transform);
            // var displayInfo = new DisplayInfo();
            // var view = interactiveObjectInitialization.Initialization(displayInfo);
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(enemyInitialization);
            controllers.Add(playerHealthInitialization);
            controllers.Add(interactiveObjectInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer().transform, data.Player, playerHealthInitialization));
            controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies(), playerInitialization.GetPlayer().transform));
            controllers.Add(new CameraController(playerInitialization.GetPlayer().transform, camera.transform));
            controllers.Add(new EndGameController(playerHealthInitialization));
            controllers.Add(new MiniMapController(playerInitialization.GetPlayer().transform, miniMapInitialization.GetMiniMap()));
            controllers.Add((new EnemyController(enemyInitialization.GetEnemies(), displayInfo,
                playerHealthInitialization)));
            //controllers.Add(new KeyController());
            controllers.Add(new SaveDataController(playerInitialization.GetPlayer().transform));
        }
    }
}