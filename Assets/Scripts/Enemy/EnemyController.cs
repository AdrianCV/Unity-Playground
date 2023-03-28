using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Subject
{
    [SerializeField] private bool _canMove;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var rand = Random.Range(1, 101);
            NotifyObservers(Actions.TakeDamage, rand, transform);
        }

        if (_canMove && Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (Vector3.right / 50);
        }

        if (_canMove && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (Vector3.left / 50);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        var rand = Random.Range(1, 101);
        NotifyObservers(Actions.TakeDamage, rand, transform);
    }
}
