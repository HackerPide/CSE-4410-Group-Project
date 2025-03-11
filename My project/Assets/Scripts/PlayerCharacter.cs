using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int health;
    public int maxHealth = 5;
    public static int baseHealth;
    private bool isDead = false;

    private void OnEnable()
    {
        Messenger<int>.AddListener(GameEvent.PLAYER_HEALTH_CHANGED, OnHealthChanged);
    }

    private void OnDisable()
    {
        Messenger<int>.RemoveListener(GameEvent.PLAYER_HEALTH_CHANGED, OnHealthChanged);
    }

    private void OnHealthChanged(int value)
    {
        maxHealth = baseHealth + health;
    }

    void Start()
    {
        health = maxHealth;
        isDead = false;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");

        // Check if player has died
        if (health <= 0 && !isDead)
        {
            isDead = true;
            Die();
        }
    }

    private void Die()
    {
        // Broadcast the player death event for other systems to respond
        Messenger.Broadcast(GameEvent.PLAYER_DEATH);

        // You could add death animations or other effects here
        Debug.Log("Player has died!");
    }
}