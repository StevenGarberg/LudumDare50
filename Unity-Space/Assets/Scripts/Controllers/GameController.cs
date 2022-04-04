using System;
using System.Collections;
using System.Collections.Generic;
using LudumDare50.Behaviours;
using LudumDare50.Unity.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LudumDare50.Controllers
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;
        
        [SerializeField] private int _spawnCount = 10;
        [SerializeField] private GameObject _gameOverWindow;
        
        private Spawner[] _spawners = Array.Empty<Spawner>();
        private List<int> _activeSpawnerIndexes = new List<int>();

        public bool IsGameOver { get; private set; } = false;
        public int TimeElapsed { get; private set; } = 0;
        
        private void Awake()
        {
            Instance = this;
            
            _spawners = FindObjectsOfType<Spawner>();
        }

        private void Start()
        {
            for (var i = 0; i < _spawnCount; i++)
            {
                while (true)
                {
                    var index = Random.Range(0, _spawners.Length);
                    if (_activeSpawnerIndexes.Contains(index))
                        continue;
                    
                    _activeSpawnerIndexes.Add(index);
                    break;
                }
            }

            foreach (var index in _activeSpawnerIndexes)
            {
                _spawners[index].Spawn();
            }

            StartCoroutine(TimerRoutine());
        }

        public void ConsumeAndSpawn(Spawner spawner)
        {
            for (var i = 0; i < _spawnCount; i++)
            {
                var index = _activeSpawnerIndexes[i];
                if (_spawners[index] == spawner)
                {
                    while (true)
                    {
                        var randomIndex = Random.Range(0, _spawners.Length);
                        if (_activeSpawnerIndexes.Contains(randomIndex))
                            continue;
                    
                        _activeSpawnerIndexes.Add(randomIndex);
                        
                        _spawners[randomIndex].Spawn();
                        
                        _activeSpawnerIndexes.Remove(index);
                        break;
                    }
                    break;
                }
            }
        }

        private IEnumerator TimerRoutine()
        {
            while (!IsGameOver)
            {
                yield return new WaitForSeconds(1);
                TimeElapsed++;
            }
        }

        public void GameOver()
        {
            IsGameOver = true;
            AudioManager.Instance.Play("taunt");
            _gameOverWindow.SetActive(true);
        }
    }
}