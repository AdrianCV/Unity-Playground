using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class TakeDamageEditorEvent : Subject
{
#if UNITY_EDITOR

    public int Amount;

    public void TakeDamage()
    {
        NotifyObservers(Actions.TakeDamage, Amount);
    }

#endif
}
