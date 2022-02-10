using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;

    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        //adjust size based on wordlength
        Vector3 scaleChange = new Vector3(0.5f, 0.5f, 0);
        int wordLength = GetComponentInChildren<TextMesh>().text.Length;
        for (int i = 0; i < wordLength; i++)
        {
            gameObject.transform.localScale += scaleChange;

        }

        //adjust speed based on difficulty options
        if (TogglesManager.instance.fasterWords == true)
        {
            speed = 15f;
        }
        else
        {
            speed = 10f;
        }

        //adjust speed based on wordlength
        if (wordLength > 3)
        {
            speed -= (wordLength * 0.5f);
        }

        //adjust color based on wordlength
        if (wordLength <= 3)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (wordLength <= 6)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }

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
