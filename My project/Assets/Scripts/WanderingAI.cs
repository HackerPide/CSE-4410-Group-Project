using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public float health = 1.0f;
    public const float baseHealth = 1.0f;
    private bool isAlive;

    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;

    private void OnEnable() {
        Messenger<float>.AddListener(GameEvent.ENEMY_HEALTH_CHANGED, OnHealthChanged);
    }

    private void OnDisable() {
        Messenger<float>.RemoveListener(GameEvent.ENEMY_HEALTH_CHANGED, OnHealthChanged);
    }

    private void OnHealthChanged(float value) {
        health = baseHealth * value;
    }

    void Start() {
        isAlive = true;
    }

    void Update() {
        if (isAlive) {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>()) {
                if (fireball == null) {
                    fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }
            } else if (hit.distance < obstacleRange) {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    public float gotHit(int damage){
        health -= damage;
        return health;
    }

    public void SetAlive(bool alive) {
        isAlive = alive;
    }
}