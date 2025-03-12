using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    // Initialize healthbar image and amount
    public Image healthBar;
    public float healthAmount = 5.0f;
    public const float baseHealthAmount = 5.0f;

    private void OnEnable()
    {
        Messenger<int>.AddListener(GameEvent.PLAYER_HEALTH_CHANGED, OnHealthChanged);
        Messenger.AddListener(GameEvent.PLAYER_DEATH, OnPlayerDeath);
        Messenger<int>.AddListener(GameEvent.PLAYER_DAMAGED, OnPlayerHit);
    }

    private void OnDisable()
    {
        Messenger<int>.RemoveListener(GameEvent.PLAYER_HEALTH_CHANGED, OnHealthChanged);
        Messenger.RemoveListener(GameEvent.PLAYER_DEATH, OnPlayerDeath);
        Messenger<int>.RemoveListener(GameEvent.PLAYER_DEATH, OnPlayerHit);
    }

    private void OnHealthChanged(int value)
    {
        healthAmount = baseHealthAmount + healthAmount;
    }

    private void OnPlayerDeath()
    {
        healthAmount = baseHealthAmount;
    }

    private void OnPlayerHit(int value)
    {
        takeDamage(value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        /*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //FIXME Add logic for receiving damage
            takeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //FIXME Add logic for healing damage
            Heal(5);
        }
        */
    }

    public void takeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
