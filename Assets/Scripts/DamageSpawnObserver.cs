using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpawnObserver : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _subject;

    Dictionary<Actions, System.Action> _actionHandlers;


    private void Awake()
    {
        _actionHandlers = new Dictionary<Actions, System.Action>()
        {
            { Actions.TakeDamage, SpawnDamageNumbers },
        };
    }

    public void OnNotify(Actions action)
    {
        if (_actionHandlers.ContainsKey(action))
        {
            _actionHandlers[action]();
        }
    }

    void SpawnDamageNumbers()
    {

    }

    private void OnEnable()
    {
        _subject.AddObserver(this);
    }

    private void OnDisable()
    {
        _subject.RemoveObserver(this);
    }
}
