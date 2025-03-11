using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Vector3 dPos;
    public float autotime = 5;
    private float Timepassed;
	private bool open;
    void Start() {
        open = false;
    }
	public void Operate() {
		if (open) {
			Vector3 pos = transform.position - dPos;
			transform.position = pos;
		} else {
			Vector3 pos = transform.position + dPos;
			transform.position = pos;
		}
		open = !open;
	}

	public void Activate() {
		if (!open) {
			Vector3 pos = transform.position + dPos;
			transform.position = pos;
			open = true;
		}
	}
	public void Deactivate() {
		if (open) {
			Vector3 pos = transform.position - dPos;
			transform.position = pos;
			open = false;
		}
	}
    //Open/Close every 
    void update(){
        
        Timepassed += Time.fixedDeltaTime;
        if(Timepassed > autotime){
            Operate();
            Timepassed=0;
        }
    }
}
