using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAroundSomething : MonoBehaviour
{
    private float RotateSpeed = 2.5f;
    private float Radius = 10f;

    private Vector2 _centre;
    private float _angle;

    void Start()
    {
        _centre = transform.position;
    }

    void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }
}
