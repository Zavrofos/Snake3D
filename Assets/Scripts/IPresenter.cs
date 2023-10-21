using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IPresenter 
    {
        void Subscribe();
        void Unsubscribe();
    }
}