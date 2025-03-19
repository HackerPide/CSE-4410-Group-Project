using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    public float speed = 6.0f;
    public float gravity = -9.8f;
	public bool alive = true;

    private CharacterController charController;

    void Start() {
        charController = GetComponent<CharacterController>();
    }

    private void OnEnable() {
		Messenger.AddListener(GameEvent.PLAYER_DEATH, OnDeath);
        Messenger.AddListener(GameEvent.PLAYER_RESET, OnReset);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.PLAYER_DEATH, OnDeath);
		Messenger.RemoveListener(GameEvent.PLAYER_RESET, OnReset);
    }

    private void OnDeath() {
		alive = false;
	}

	private void OnReset() {
		alive = true;
	}

    // Update is called once per frame
    void Update() {
		if (alive) {
			float deltaX = Input.GetAxis("Horizontal") * speed;
			float deltaZ = Input.GetAxis("Vertical") * speed;
			
			Vector3 movement = new Vector3(deltaX, 0, deltaZ);
			movement = Vector3.ClampMagnitude(movement, speed);
			movement.y = gravity;
			movement *= Time.deltaTime;
			movement = transform.TransformDirection(movement);
			charController.Move(movement);
		}
	}
}
