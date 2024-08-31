using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private BGMusicScript bgm;

    [SerializeField] private AudioSource audioDeath;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bgm = FindObjectOfType<BGMusicScript>();

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Death")) {
            Die();
        }
    }

    private void Die() {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        audioDeath.Play();
    }
    private void RestartLevelBgm() {
        bgm.RestartLevel();
    }

}
