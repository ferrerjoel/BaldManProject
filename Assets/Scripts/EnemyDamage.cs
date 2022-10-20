using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerMovement player; 
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Enemy")){
            audioSource.Play();
            player.gravity = 50f;
            player.originalSpeed = 200f;
        }
    }
}
