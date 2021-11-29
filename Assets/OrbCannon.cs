using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCannon : MonoBehaviour
{

    [SerializeField]
    private GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void shootAt(GameObject enemy)
    {
        Debug.Log("OrbCannon "+this.tag+" shooting at enemy");
        GameObject projectile = GameObject.Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.GetComponent<Projectile>().target = enemy;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
