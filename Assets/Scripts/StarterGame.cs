using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Camera;
using Snake;
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

    private List<IPresenter> _presenters;
    private List<IUpdater> _updaters;
    private List<IUpdater> _fixedUpdaters;
    private List<IUpdater> _lateUpdaters;


    private void Awake()
    {
        GameModel = new GameModel(InitialCountPartOfBodySnake, JoystickSize, SpeedLerpDirection,
            SpeedSnake, CameraDistance);
        
        _presenters = new List<IPresenter>()
        {
            new TouchInputPresenter(GameModel, GameView)
        };
        
        _updaters = new List<IUpdater>()
        {
            new LerpDirectionUpdater(GameModel),
            new RotationSnakeHeadUpdater(GameModel, GameView)
        };

        _fixedUpdaters = new List<IUpdater>()
        {
            new MovementUpdater(GameModel, GameView),
            new SnakeHeadMoveUpdater(GameModel, GameView)
        };

        _lateUpdaters = new List<IUpdater>()
        {
            new CameraMoveUpdater(GameModel, GameView)
        };
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