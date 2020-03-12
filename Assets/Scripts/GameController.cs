using System.Collections;
using System.Collections.Generic;
using PingPong.Data;
using UnityEngine;

namespace PingPong
{
    public class GameController : MonoBehaviour
    {
        GameField gameField;
        CameraController cameraContorller;
        Simulator simulator;

        readonly float fieldWidth = 200;
        readonly float fieldHeight = 200;

        readonly float minBallStartSpeed = 100;
        readonly float maxBallStartSpeed = 250;

        readonly float ballRadiusMin = 3;
        readonly float ballRadiusMax = 10;

        int ballsSpawned = 0;
        bool gameStarted = false;

        void Awake()
        {
            InitializeGame();
        }

        void InitializeGame()
        {
            var gameFieldGameObject = new GameObject("GameField");

            gameField = gameFieldGameObject.AddComponent<GameField>();
            gameField.CreateField(fieldWidth, fieldHeight);

            if (cameraContorller == null)
            {
                cameraContorller = Camera.main.gameObject.AddComponent<CameraController>();          
            }
            cameraContorller.SetTargetGameObject(gameFieldGameObject);

            simulator = new Simulator(fieldHeight, fieldHeight);

            CreatePlatform(fieldHeight * 0.5f);
            CreatePlatform(-fieldHeight * 0.5f);
        }

        void CreatePlatform(float positionY)
        {
            var platformData = new PlatformData(30);
			simulator.AddPlatform(platformData);
   
            platformData.SetPositionX(0);
            platformData.SetPositionY(positionY);

            var platformObject = new GameObject("Platform");
            var platformController = platformObject.AddComponent<Platform>();
            platformController.SetData(platformData);
        }

        void SpawnBallInCenter()
        {
            var ballRadius = ballRadiusMin + Random.value * (ballRadiusMax - ballRadiusMin);
            var ballData = new BallData(ballRadius);
            simulator.SpawnBall(ballData);

            var ballObject = new GameObject("Ball");
            var ballController = ballObject.AddComponent<Ball>();
            ballController.SetData(ballData);
                
            simulator.StartMoving(minBallStartSpeed,maxBallStartSpeed);

            ballsSpawned++;
        }

        void RestartRound()
        {
            ballsSpawned = 0;
            simulator.DeadBalls.Clear();
            SpawnBallInCenter();
        }

        void FixedUpdate()
        {
            if (gameStarted && simulator != null)
            {
                simulator.Update(Time.fixedDeltaTime);
                if (ballsSpawned == simulator.DeadBalls.Count)
                {
                    RestartRound();
                }
            }
        }

        void Update()
        {
            if (!gameStarted)
            {
                if (Input.GetMouseButton(0))
                {
                    gameStarted = true;
                    RestartRound();
                }
            }
        }
    }
}