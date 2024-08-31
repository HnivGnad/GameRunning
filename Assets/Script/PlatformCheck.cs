using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheck : MonoBehaviour {
    [SerializeField] private GameObject[] waypoint;
    [SerializeField] private float speed = 2f;
    private int index = 0;
    private bool playerMovement;

    void Update() {
        if (playerMovement) {
            if (Vector2.Distance(waypoint[index].transform.position, transform.position) < 0.1f) {
                index++;
                if (index >= waypoint.Length) {
                    index = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoint[index].transform.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            playerMovement = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            playerMovement = false;
        }
    }

}
