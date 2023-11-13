using System;
using Camera;
using FoodDir;
using Snake;
using Snake.MoveController;
using Touch;
using UnityEngine;

public class GameModel
{
    public readonly TouchModel TouchModel;
    public readonly SnakeModel SnakeModel;
    public readonly MovementController MovementController;
    public readonly CameraModel CameraModel;
    public readonly SpawnFoodModel SpawnFoodModel;

    public event Action Initialized;
    
    public GameModel(int initialCountPartOfBody, Vector2 joystickSize, float speedLerpDirection,
        float speedSnake, float distanceCamera, int gapBetweenPositionsOfBodyParts, int initialCountFood, 
        float speedFood, float radiusFindFood)
    {
        TouchModel = new TouchModel(joystickSize, speedLerpDirection);
        SnakeModel = new SnakeModel(initialCountPartOfBody, gapBetweenPositionsOfBodyParts, radiusFindFood);
        MovementController = new MovementController(speedSnake);
        CameraModel = new CameraModel(distanceCamera);
        SpawnFoodModel = new SpawnFoodModel(initialCountFood, speedFood);
    }

    public void Initialize()
    {
        Initialized?.Invoke();
    }
}
