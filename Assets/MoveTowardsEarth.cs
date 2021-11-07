using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsEarth : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;
   
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
}
