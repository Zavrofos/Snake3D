using System.Collections;
using System.Collections.Generic;
using Snake;
using UnityEngine;

public class GameModel
{
    public readonly SnakeModel SnakeModel;
    public GameModel(int initialCountPartOfBody)
    {
        SnakeModel = new SnakeModel(initialCountPartOfBody);
    }
}
