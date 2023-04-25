using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab;

        private List<Ball> _balls = new List<Ball>();

        public static Action BallSpawnSound;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnBallAtMouseAndGiveName(Input.mousePosition, "Colored Ball");
            }
            else if (Input.GetMouseButtonDown(1))
            {
                //TODO: This should remove all red balls, right?
                List<Ball> redBalls = _balls.FindAll(x => x.Color == Color.red);
                foreach (var redBall in redBalls)
                {
                    RemoveBall(redBall);
                }
            }
        }

        public void RemoveBall(Ball ball)
        {
            //TODO: Implement a way to remove a ball from the scene and the list.
            _balls.Remove(ball);
            Destroy(ball.gameObject);
        }

        private void SpawnBallAtMouseAndGiveName(Vector3 mousePosition, string name)
        {
                        
            //TODO: Spawn a random color of ball at the position of the mouse click and play spawn sound.
            //OPTIONAL: Use events for playing sounds.
            
            
            Ball spawnedBall = InstantiateBall(ConvertMousePosTo2D(mousePosition), name);
            
            //What I understand from random color is between blue and red. If it isn't, here is the code for that as well.
            //Color randomColor = Random.ColorHSV();
            Color randomColor = Random.value < 0.5f ? Color.red : Color.blue;
            
            spawnedBall.SetColor(randomColor);
            BallSpawnSound.Invoke();
        }

        private Ball InstantiateBall(Vector3 position, string name)
        {
            //TODO: What's a better way to do this?
            Ball ball = Instantiate(_ballPrefab, position, Quaternion.identity).GetComponent<Ball>();
            ball.SetName(name);
            _balls.Add(ball);
            return ball;
        }

        private Vector3 ConvertMousePosTo2D(Vector3 mousePosition)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(mousePosition);
            
            return new Vector3(pos.x, pos.y, 0);
        }
    }
}