using FoodDir;
using Snake.Body;
using Snake.Head;
using Snake.MoveController;
using Touch;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public FloatingJoystickView JoystickView;
    public Transform SurfaceForMovement;
    public MovementControllerView MovementController;
    public SnakeHeadView SnakeHeadView;
    public Transform CameraView;
    public BodySnakeView BodySnakeView;
    public SpawnFoodView SpawnFoodView;
}