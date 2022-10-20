using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    // Sphere radious
    public float alertRange;
    // To know what the player is
    public LayerMask playerMask;
    // To know the player position
    public Transform player;
    bool alert;

    public float speed = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Invisible sphere
        alert = Physics.CheckSphere(transform.position, alertRange, playerMask);

        if (alert){
            //transform.LookAt(player);
            Vector3 playerPosition = new Vector3(player.position.x,transform.position.y,player.position.z);
            transform.LookAt(playerPosition);
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed*Time.deltaTime);
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRange);
    }

    
}
