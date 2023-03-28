using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpawnObserver : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _subject;

    private void Awake()
    {
        _subject = GetComponent<Subject>();
        // _actionHandlers = new Dictionary<Actions, Action<int>>()
        // {
        //     { Actions.TakeDamage, SpawnDamageNumbers},
        // };
    }

    public void OnNotify(Actions action, int amount, Transform transform)
    {
        if (action == Actions.TakeDamage && transform == this.transform)
        {
            SpawnDamageNumbers(amount, transform);
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
