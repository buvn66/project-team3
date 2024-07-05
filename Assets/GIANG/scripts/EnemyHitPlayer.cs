using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyHitPlayer : MonoBehaviour
{
    PlayerBiggani player;
    public int minDamage = 5;
    public int maxDamage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerBiggani>();
            InvokeRepeating("DamagePlayer", 0, 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
            CancelInvoke("DamagePlayer");
        }
    }
    void DamagePlayer()
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage + 1);
        if (player != null)
        {
            //player.Take;
        }
    }
}
