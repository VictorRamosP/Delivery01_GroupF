using System;
using UnityEngine;


public class Coins : MonoBehaviour
{
    public int value;

    public static Action<Coins> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCoinCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
