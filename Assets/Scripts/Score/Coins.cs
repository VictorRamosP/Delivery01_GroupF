using System;
using UnityEngine;


public class Coins : MonoBehaviour
{
    public int value;

    public static Action<Coins> OnCoinCollected;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.coin);
            OnCoinCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
