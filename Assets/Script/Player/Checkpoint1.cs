using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject checkpoint;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("TrapCheckpoint1")){
            player.transform.position = checkpoint.transform.position;
        }
    }
}
