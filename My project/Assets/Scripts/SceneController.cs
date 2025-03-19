using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    [SerializeField] GameObject enemyPrefab;
    private GameObject enemy;
    int numEnemy = 2;
    public int roundNum = 1;

    void Start() {
    }

    void Update() {
        if (enemy == null)
        {
            for (int i = 0; i < numEnemy; i++)
            {
                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector3(5, 1, 0);
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);
            }
            roundNum++;
            numEnemy *= 2;
        }
        
    }
}