using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    public int health;
    public int maxHealth = 5;
    public static int baseHealth;

    private void OnEnable() {
        Messenger<int>.AddListener(GameEvent.PLAYER_HEALTH_CHANGED, OnHealthChanged);
    }

    private void OnDisable() {
        Messenger<int>.RemoveListener(GameEvent.PLAYER_HEALTH_CHANGED, OnHealthChanged);
    }

    private void OnHealthChanged(int value) {
        maxHealth = baseHealth + health;
    }

    void Start() {
        health = maxHealth;
    }

    public void Hurt(int damage) {
        health -= damage;
        if (health <= 0) {
            Messenger.Broadcast(GameEvent.PLAYER_LIFE_STATUS);
        }
    }
}