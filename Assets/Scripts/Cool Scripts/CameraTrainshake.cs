using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrainshake : MonoBehaviour
{
    [SerializeField] private AnimationCurve _xPosCurve;

    private Keyframe _lastXCurvePos;

    [SerializeField] private AnimationCurve _yPosCurve;

    private Keyframe _lastYCurvePos;

    private float _xShakeTimer;
    private float _yShakeTimer;

    [SerializeField] float _keyframeValueRange;

    [SerializeField] private Vector2 _followPos;

    // Start is called before the first frame update
    void Start()
    {
        _yShakeTimer = 0;
        Keyframe[] keyframes = new Keyframe[Random.Range(5, 10)];

        for (int i = 0; i < keyframes.Length; i++)
        {
            keyframes[i] = new Keyframe((i / (float)keyframes.Length) * 3f, Random.Range(-_keyframeValueRange, _keyframeValueRange));
        }
        _lastYCurvePos = keyframes[keyframes.Length - 1];
        _yPosCurve = new AnimationCurve(keyframes);

        _xShakeTimer = 0;
        keyframes = new Keyframe[Random.Range(5, 10)];

        for (int i = 0; i < keyframes.Length; i++)
        {
            keyframes[i] = new Keyframe((i / (float)keyframes.Length) * 3f, Random.Range(-_keyframeValueRange, _keyframeValueRange));
        }
        _lastXCurvePos = keyframes[keyframes.Length - 1];

        _xPosCurve = new AnimationCurve(keyframes);
    }

    // Update is called once per frame
    void Update()
    {
        _xShakeTimer += Time.deltaTime;
        _yShakeTimer += Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, new Vector3(_followPos.x + _xPosCurve.Evaluate(_xShakeTimer), _yPosCurve.Evaluate(_yShakeTimer), transform.position.z), Time.deltaTime);

        GenerateCurves();
    }

    void GenerateCurves()
    {
        if (_yShakeTimer > _yPosCurve.keys[_yPosCurve.keys.Length - 1].time)
        {
            _yShakeTimer = 0;
            Keyframe[] keyframes = new Keyframe[Random.Range(5, 10)];

            keyframes[0].value = _lastYCurvePos.value;

            for (int i = 1; i < keyframes.Length; i++)
            {
                keyframes[i] = new Keyframe((i / (float)keyframes.Length) * 3f, Random.Range(-_keyframeValueRange, _keyframeValueRange));

            }
            _lastYCurvePos = keyframes[keyframes.Length - 1];
            _yPosCurve = new AnimationCurve(keyframes);
        }

        if (_xShakeTimer > _xPosCurve.keys[_xPosCurve.keys.Length - 1].time)
        {
            _xShakeTimer = 0;
            Keyframe[] keyframes = new Keyframe[Random.Range(5, 10)];

            keyframes[0].value = _lastXCurvePos.value;

            for (int i = 1; i < keyframes.Length; i++)
            {
                keyframes[i] = new Keyframe((i / (float)keyframes.Length) * 3f, Random.Range(-_keyframeValueRange, _keyframeValueRange));
            }
            _lastXCurvePos = keyframes[keyframes.Length - 1];
            _xPosCurve = new AnimationCurve(keyframes);
        }
    }
}
