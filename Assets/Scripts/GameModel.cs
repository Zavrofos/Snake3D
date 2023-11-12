using System.Collections;
using System.Collections.Generic;
using Snake;
using Touch;
using UnityEngine;

public class GameModel
{
    public readonly TouchModel TouchModel;
    public readonly SnakeModel SnakeModel;
    public GameModel(int initialCountPartOfBody, Vector2 joystickSize)
    {
        TouchModel = new TouchModel(joystickSize);
        SnakeModel = new SnakeModel(initialCountPartOfBody);
    }
}
