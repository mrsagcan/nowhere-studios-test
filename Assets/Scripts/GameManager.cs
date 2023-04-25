using System;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _spawnSound;
        
        public static GameManager Instance;

        private void Awake()
        {
            //TODO: What's a better way to implement this singleton?

            //It means a new instance is created we need to destroy it.
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            
            //Safe to assign our instance
            else
            {
                Instance = this;
            }
        }

        private void OnEnable()
        {
            SpawnManager.BallSpawnSound += PlaySpawnSound;
        }

        private void OnDisable()
        {
            SpawnManager.BallSpawnSound -= PlaySpawnSound;
        }

        public void PlaySpawnSound()
        {
            _spawnSound.Play();
        }
    }
}