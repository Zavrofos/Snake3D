using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class StarterGame : MonoBehaviour
{
    [HideInInspector] public GameModel GameModel;
    public GameView GameView;
    public int InitialCountoartOfBodySnake;

    private List<IPresenter> _presenters;
    private List<IUpdater> _updaters;

    private void Start()
    {
        GameModel = new GameModel(InitialCountoartOfBodySnake);
        
        _presenters = new List<IPresenter>()
        {

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