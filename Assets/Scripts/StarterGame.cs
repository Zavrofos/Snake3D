using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Touch;
using UnityEngine;

public class StarterGame : MonoBehaviour
{
    [HideInInspector] public GameModel GameModel;
    public GameView GameView;
    
    public int InitialCountoartOfBodySnake;
    public Vector2 JoystickSize;

    private List<IPresenter> _presenters;
    private List<IUpdater> _updaters;

    private void Start()
    {
        GameModel = new GameModel(InitialCountoartOfBodySnake, JoystickSize);
        
        _presenters = new List<IPresenter>()
        {
            new TouchInputPresenter(GameModel, GameView)
        };
        
        _updaters = new List<IUpdater>()
        {

        };
    }

    private void Update()
    {
        foreach (var updater in _updaters)
        {
            updater.Update();
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