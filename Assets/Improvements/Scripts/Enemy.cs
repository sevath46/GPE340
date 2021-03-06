using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Humanoid
{
    Animator animate;
    NavMeshAgent myNavMeshAgent;
    public float respawnTime;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        maxHealth = health;
        ragDoll(true);
    }
    void Update() 
    {
        Vector3 input = myNavMeshAgent.desiredVelocity;
        input = transform.InverseTransformDirection(input);
        animate.SetFloat("Horizontal", input.x);
        animate.SetFloat("Vertical", input.z);
        myNavMeshAgent.SetDestination(target.transform.position);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (health <= 0)
        {
            ragDoll(false);
            StartCoroutine(Respawn());
            myNavMeshAgent.enabled = false;
        }
    }
    private void OnAnimatorMove()
    {
        Vector3 desiredVelocity = Vector3.MoveTowards(myNavMeshAgent.desiredVelocity, target.transform.position, myNavMeshAgent.acceleration * Time.deltaTime);
        Vector3 input = transform.InverseTransformDirection(desiredVelocity);
    }
    public void ragDoll(bool status) 
    {
        int i;
        Rigidbody[] childRBs = GetComponentsInChildren<Rigidbody>();
        if (status == true) 
        {
            for (i = 0; i < childRBs.Length; i++) 
            {
                childRBs[i].isKinematic = true;
            }
        }
        if (status == false)
        {
            for (i = 0; i < childRBs.Length; i++)
            {
                childRBs[i].isKinematic = false;
            }
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        EnemySpawn.currentActiveEnemies--;
        Destroy(this.gameObject);
    }
}
