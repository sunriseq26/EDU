using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code
{
    internal sealed class EndGameController  : IInitialization, ICleanup
    {
        private PlayerHealthController _health;
        private readonly IEnumerable<IEnemy> _getEnemies;
        private readonly int _getInstanceID;
        private Canvas _canvas;
        private Button _restartButton;

        public EndGameController(PlayerHealthController health)
        {
            _health = health;
        }

        public void Initialization()
        {
            _health.OnDied += OnEndGame;
        }

        private void OnEndGame(bool obj)
        {
            Time.timeScale = 0;
            var gameObjectButton = Resources.Load<Button>("UI/RestartButton");
            _canvas = Object.FindObjectOfType<Canvas>();
            _restartButton = Object.Instantiate(gameObjectButton, _canvas.transform);
            _restartButton.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 1); 
            Time.timeScale = 1.0f;
            
            _restartButton.gameObject.SetActive(false);
        }

        public void Cleanup()
        {
            _health.OnDied -= OnEndGame;
        }
    }
}