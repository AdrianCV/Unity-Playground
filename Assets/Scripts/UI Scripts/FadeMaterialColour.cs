using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeMaterialColour : MonoBehaviour
{
    private TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Color newColor = _text.color;
        newColor.a -= 0.003f;
        _text.color = newColor;

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.001f, transform.position.z);

        if (_text.color.a <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
