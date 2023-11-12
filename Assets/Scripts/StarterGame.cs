using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
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

    private List<IPresenter> _presenters;
    private List<IUpdater> _updaters;
    private List<IFixedUpdater> _fixedUpdaters;


    private void Awake()
    {
        GameModel = new GameModel(InitialCountPartOfBodySnake, JoystickSize, SpeedLerpDirection,
            SpeedSnake);
        
        _presenters = new List<IPresenter>()
        {
            new TouchInputPresenter(GameModel, GameView)
        };
        
        _updaters = new List<IUpdater>()
        {
            new LerpDirectionUpdater(GameModel)
        };

        _fixedUpdaters = new List<IFixedUpdater>()
        {
            new MovementUpdater(GameModel, GameView)
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
            fixedUpdater.FixedUpdate();
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