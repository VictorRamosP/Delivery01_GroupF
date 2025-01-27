using System;
using UnityEngine;


public class Coins : MonoBehaviour
{
    public int Value;

    public static Action<Coins> OnCoinCollected;

    AudioManager AudioManager;

    private void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.PlaySFX(AudioManager.Coin);
            OnCoinCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
