using System.Collections;
using System.Collections.Generic;
using Snake;
using Touch;
using UnityEngine;

public class GameModel
{
    public readonly TouchModel TouchModel;
    public readonly SnakeModel SnakeModel;
    public GameModel(int initialCountPartOfBody, Vector2 joystickSize, float speedLerpDirection)
    {
        TouchModel = new TouchModel(joystickSize, speedLerpDirection);
        SnakeModel = new SnakeModel(initialCountPartOfBody);
    }
}
