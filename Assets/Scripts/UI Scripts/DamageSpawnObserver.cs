using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpawnObserver : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _subject;
    private Action<int, Transform> _spawnFunction;

    private Dictionary<Actions, Action<int, Transform>> _actionHandlers;

    private void Awake()
    {
        _subject = GetComponent<Subject>();
        _spawnFunction += SpawnDamageNumbers;
        _actionHandlers = new Dictionary<Actions, Action<int, Transform>>()
        {
            { Actions.TakeDamage, _spawnFunction},
        };
    }

    public void OnNotify(Actions action, int amount, Transform transform)
    {
        if (_actionHandlers.ContainsKey(action) && transform == this.transform)
        {
            _actionHandlers[action](amount, transform);
        }
    }

    void SpawnDamageNumbers(int amount, Transform transform)
    {
        var number = (GameObject)Instantiate(Resources.Load("DamageNumber"), transform.position + Vector3.up, Quaternion.identity);
        number.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = amount + ""; // ew
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
