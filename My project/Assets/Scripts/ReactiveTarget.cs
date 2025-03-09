using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {
    public void ReactToHit(int damage) {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null && behavior.gotHit(damage) < 0) {
            behavior.SetAlive(false);
            Messenger.Broadcast(GameEvent.ENEMY_DEATH);
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die() {
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

    void Start() {
    }

    void Update() {
    }
}