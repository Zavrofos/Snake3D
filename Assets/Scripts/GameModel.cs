using System.Collections;
using System.Collections.Generic;
using Camera;
using Snake;
using Touch;
using UnityEngine;

public class GameModel
{
    public readonly TouchModel TouchModel;
    public readonly SnakeModel SnakeModel;
    public readonly MovementController MovementController;
    public readonly CameraModel CameraModel;
    
    public GameModel(int initialCountPartOfBody, Vector2 joystickSize, float speedLerpDirection,
        float speedSnake, float distanceCamera)
    {
        TouchModel = new TouchModel(joystickSize, speedLerpDirection);
        SnakeModel = new SnakeModel(initialCountPartOfBody);
        MovementController = new MovementController(speedSnake);
        CameraModel = new CameraModel(distanceCamera);
    }
}
