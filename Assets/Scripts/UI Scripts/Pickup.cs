using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _subject;

    Dictionary<Actions, System.Action> _actionHandlers;

    private GameObject[] _uiElements;


    private void Awake()
    {
        // _actionHandlers = new Dictionary<Actions, System.Action>()
        // {
        //     { Actions.TakeDamage, SpawnDamageNumbers },
        // };
    }

    public void OnNotify(Actions action, int amount, Sprite icon)
    {
        if (action == Actions.Pickup)
        {

        }
    }


    void DoPickup(int amount, Sprite icon)
    {
        var holder = _uiElements;
        for (int i = 0; i < _uiElements.Length - 1; i++)
        {
            _uiElements[i + 1] = holder[i];
        }
    }
}
