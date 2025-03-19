using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    // Initialize healthbar image and amount
    public Image healthBar;
    public int healthAmount = 5;
	public GameObject otherGameObject;
	// PlayerCharacter player = otherGameObject.GetComponent<PlayerCharacter>();

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
    }

    public void takeDamage(int damage)
    {	
		PlayerCharacter player = otherGameObject.GetComponent<PlayerCharacter>();
        healthAmount -= damage;
		player.Hurt(damage);
        healthBar.fillAmount = healthAmount / 100;
    }

    public void Heal(int healingAmount)
    {
		PlayerCharacter player = otherGameObject.GetComponent<PlayerCharacter>();
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100;
    }
}
