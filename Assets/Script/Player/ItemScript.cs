using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    private int scoreItem = 0;
    [SerializeField] private Text item;
    [SerializeField] private AudioSource audioItem;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Item")) {
            Destroy(collision.gameObject);
            scoreItem++;
            item.text = "Score:" + scoreItem;
            audioItem.Play();
        }
    }
}
