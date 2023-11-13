using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Camera;
using FoodDir;
using Snake;
using Snake.Body;
using Snake.Head;
using Snake.MoveController;
using Touch;
using UnityEngine;

public class StarterGame : MonoBehaviour
{
    [HideInInspector] public GameModel GameModel;
    public GameView GameView;
    
    public int InitialCountPartOfBodySnake;
    public Vector2 JoystickSize;
    public float SpeedLerpDirection;
    public float SpeedSnake;
    public float CameraDistance;
    public int GapBetweenPositionsOfBodyParts;
    public int InitialCountFood;
    public float SpeedFood;
    public float RadiusFindFood;

    private List<IPresenter> _presenters;
    private List<IUpdater> _updaters;
    private List<IUpdater> _fixedUpdaters;
    private List<IUpdater> _lateUpdaters;


    private void Awake()
    {
        GameModel = new GameModel(InitialCountPartOfBodySnake, JoystickSize, SpeedLerpDirection,
            SpeedSnake, CameraDistance, GapBetweenPositionsOfBodyParts, InitialCountFood, SpeedFood, RadiusFindFood);
        
        _presenters = new List<IPresenter>()
        {
            new TouchInputPresenter(GameModel, GameView),
            new InitializeBodySnakePresenter(GameModel, GameView),
            new CreatePartOfBodyPresenter(GameModel, GameView),
            new InitialSpawnFoodPresenter(GameModel, GameView),
            new SpawnFoodPresenter(GameModel, GameView),
            new RemoveFoodPresenter(GameModel, GameView)
        };
        
        _updaters = new List<IUpdater>()
        {
            new LerpDirectionUpdater(GameModel),
            new RotationSnakeHeadUpdater(GameModel, GameView),
            new MoveFoodToHeadSnakeUpdater(GameModel, GameView),
            new FindFoodUpdater(GameModel, GameView)
        };

        _fixedUpdaters = new List<IUpdater>()
        {
            new MovementUpdater(GameModel, GameView),
            new SnakeHeadMoveUpdater(GameModel, GameView),
            new BodyMoveUpdater(GameModel, GameView)
        };

        _lateUpdaters = new List<IUpdater>()
        {
            new CameraMoveUpdater(GameModel, GameView)
        };
        
        
    }

    private void Start()
    {
        GameModel.Initialize();
    }

    private void Update()
    {
        foreach (var updater in _updaters)
        {
            updater.Update();
        }
    }

    private void FixedUpdate()
    {
        foreach (var fixedUpdater in _fixedUpdaters)
        {
            fixedUpdater.Update();
        }
    }

    private void LateUpdate()
    {
        foreach (var lateUpdater in _lateUpdaters)
        {
            lateUpdater.Update();
        }
    }

    private void OnEnable()
    {
        foreach (var presenter in _presenters)
        {
            presenter.Subscribe();
        }
    }

    private void OnDisable()
    {
        foreach (var presenter in _presenters)
        {
            presenter.Unsubscribe();
        }
    }
}