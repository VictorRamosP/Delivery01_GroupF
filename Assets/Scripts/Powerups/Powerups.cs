using System;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public string Power;

    public static Action<Powerups> OnPowerupCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPowerupCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
