using System.Net.Mime;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    private List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    protected void NotifyObservers(Actions action)
    {
        _observers.ForEach((_observers) =>
        {
            _observers.OnNotify(action);
        });
    }

    protected void NotifyObservers(Actions action, int amount, Sprite icon)
    {
        _observers.ForEach((_observers) =>
        {
            _observers.OnNotify(action, amount, icon);
        });
    }
}
