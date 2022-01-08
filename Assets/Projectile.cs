using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;

    [SerializeField]
    private float speed;

    private Vector2 targetPosition;

    private void Awake()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            GameObject.Destroy(this.gameObject);
        }
        float step = speed * Time.deltaTime;
        targetPosition = target.transform.position;
        LookAt2D(this.transform,targetPosition);
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("a projectile hit something");
        EnemySpawner.spawnedEnemies.Remove(collision.gameObject);
        GameObject.Destroy(collision.gameObject);
        GameObject.Destroy(this.gameObject);
        
    }

    public static void LookAt2D(Transform transform, Vector2 target)
    {
        var direction = target - (Vector2)transform.position; // Get the direction
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Convert to angle
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Finally rotate the GameObject
    }

}
