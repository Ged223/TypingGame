using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsEarth : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
   
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 scaleChange = new Vector3(0.5f, 0.5f, 0);
        int wordLength = GetComponentInChildren<TextMesh>().text.Length;
        for (int i = 0; i < wordLength; i++)
        {
            gameObject.transform.localScale += scaleChange;               
        }
       
        target = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (MissionManager.instance.fasterWords == true)
        {
            speed = 15f;
        }
        else
        {
            speed = 10f;
        }
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
}
