using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.tag == "Enemy") 
        {
            col.gameObject.GetComponent<Enemy>().health--;
            Destroy(this.gameObject);
            EnemySpawn.currentActiveEnemies--;
        }
    }
}
