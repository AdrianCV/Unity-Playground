using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody rb3D;

    Rigidbody2D rb2D;

    [SerializeField] private bool _2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = this?.GetComponent<Rigidbody2D>();
        rb3D = this?.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_2D)
        {
            Jump2D();
        }
        else
        {
            Jump3D();
        }
    }

    void Jump2D()
    {
        if (rb2D.velocity.y < 0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void Jump3D()
    {
        if (rb3D.velocity.y < 0)
        {
            rb3D.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb3D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb3D.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
