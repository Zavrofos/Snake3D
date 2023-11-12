using System.Collections;
using Snake;
using Touch;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public FloatingJoystickView JoystickView;
    public Transform SurfaceForMovement;
    public MovementControllerView MovementController;
    public SnakeHeadView SnakeHeadView;
    public Transform CameraView;
}