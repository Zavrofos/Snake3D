using System;
using System.Collections;
using System.Collections.Generic;
using Camera;
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

    public event Action Initialized;
    
    public GameModel(int initialCountPartOfBody, Vector2 joystickSize, float speedLerpDirection,
        float speedSnake, float distanceCamera, int gapBetweenPositionsOfBodyParts)
    {
        TouchModel = new TouchModel(joystickSize, speedLerpDirection);
        SnakeModel = new SnakeModel(initialCountPartOfBody, gapBetweenPositionsOfBodyParts);
        MovementController = new MovementController(speedSnake);
        CameraModel = new CameraModel(distanceCamera);
    }

    public void Initialize()
    {
        Initialized?.Invoke();
    }
}
