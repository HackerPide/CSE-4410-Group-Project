using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int health;
    public int maxHealth = 5;
    public static int baseHealth;
    private bool isDead = false;
    public int gold = 1;

    private void OnEnable()
    {
        Messenger<int>.AddListener(GameEvent.PLAYER_HEALTH_CHANGED, OnHealthChanged);
        Messenger.AddListener(GameEvent.ENEMY_DEATH, OnEnemyDeath);
    }

    private void OnDisable()
    {
        Messenger<int>.RemoveListener(GameEvent.PLAYER_HEALTH_CHANGED, OnHealthChanged);
        Messenger.RemoveListener(GameEvent.ENEMY_DEATH, OnEnemyDeath);
    }

    private void OnHealthChanged(int value)
    {
        maxHealth = baseHealth + health;
    }

    private void OnEnemyDeath()
    {
        gold += 1;
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
        Messenger<int>.Broadcast(GameEvent.PLAYER_DAMAGED, damage);

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
    public bool Buy(int cost){
        bool afford = false;
        if(gold >= cost){
            gold-=cost;
            afford = true;
        }
        return afford;
    }
    public int getGold(){
        return gold;
    }
}