using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAround : MonoBehaviour
{
    private float RotateSpeed = 1f;
    private float Radius = 6.5f;

    private Vector2 _centre;
    private float _angle;

    [SerializeField]
    private int spawnPosition;


    public GoAround()
    {
        spawnPosition = 1;
    }

    void Start()
    {
        _centre = transform.position;
    }

    void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + (spawnPosition * offset);
    }
}
