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

    public GameObject getNearestOrb(GameObject enemy)
    {
        Transform[] transforms = GetComponentsInChildren<Transform>();
        Transform nearest = transforms[0];
        foreach(Transform orb in transforms)
        {
            if(Vector3.Distance(orb.position,enemy.transform.position) <= Vector3.Distance(nearest.position, enemy.transform.position))
            {
                nearest = orb;
            }
        }
        return nearest.gameObject;
    }
}
