using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitScript : MonoBehaviour
{
    public GameObject player;
    public GameObject startPoint;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            player.transform.position = startPoint.transform.position;
        }
    }
}
