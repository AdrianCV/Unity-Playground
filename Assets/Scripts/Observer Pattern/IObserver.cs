using UnityEngine;

public interface IObserver
{
    public void OnNotify(Actions action)
    {

    }

    public void OnNotify(Actions action, int amount, Sprite icon)
    {

    }
}
