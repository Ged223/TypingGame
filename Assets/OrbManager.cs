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
        GameObject orb1Object = GameObject.FindGameObjectWithTag("Orb1");
        GameObject orb2Object = GameObject.FindGameObjectWithTag("Orb2");

        OrbCannon orb1 = orb1Object.GetComponent<OrbCannon>();
        OrbCannon orb2 = orb2Object.GetComponent<OrbCannon>();

        Vector2 orb1Position = orb1Object.transform.position;
        Vector2 orb2Position = orb2Object.transform.position;
        if (Vector2.Distance(orb1Position,enemy.transform.position) > Vector2.Distance(orb2Position, enemy.transform.position))
        {
            return orb2Object;
        } else
        {
            return orb1Object;
        }
    }
}
