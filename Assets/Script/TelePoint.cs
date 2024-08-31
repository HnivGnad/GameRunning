using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject telePoint;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            player.transform.position = telePoint.transform.position;
        }
    }
    
}
