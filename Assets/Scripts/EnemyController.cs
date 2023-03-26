using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Subject
{
    // Start is called before the first frame update
    void Start()
    {
        NotifyObservers(Actions.TakeDamage);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
