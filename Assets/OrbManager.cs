using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendTarget(GameObject enemy)
    {
        GameObject cannon = getNearestOrb(enemy);

        cannon.GetComponent<OrbCannon>().shootAt(enemy);
    }

    public GameObject getNearestOrb(GameObject enemy)
    {
        float distanceToClosestOrb = Mathf.Infinity;
        Transform[] transforms = GetComponentsInChildren<Transform>();
        Transform nearest = this.GetComponentInChildren<OrbCannon>().gameObject.GetComponent<Transform>();
        foreach(Transform orb in transforms)
        {
            float distanceToOrb = Vector2.Distance(orb.position, enemy.transform.position);
            if(distanceToOrb < distanceToClosestOrb)
            {
                distanceToClosestOrb = distanceToOrb;
                nearest = orb;
            }
        }
        return nearest.gameObject;
    }
}
