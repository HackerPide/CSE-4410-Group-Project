using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAnvil : MonoBehaviour
{   
    //Price of 1 random anvil upgrade
    public int price=1;
    public GameObject otherGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OperateB(){
        int upgrade;
        PlayerCharacter player = otherGameObject.GetComponent<PlayerCharacter>();
        //This section will be to check for gold in the future
        if(player.Buy(price)){
            upgrade = Random.Range(0,3);
            switch(upgrade){
                case 0:
                Debug.Log("Health upgrade");
                Messenger.Broadcast(GameEvent.PLAYER_HEALTH_CHANGED);
                break;
                case 1:
                Debug.Log("Speed upgrade");
                Messenger.Broadcast(GameEvent.PLAYER_SPEED_CHANGED);
                break;
                case 2:
                Debug.Log("Damage Upgrade");
                Messenger.Broadcast(GameEvent.PLAYER_DAMAGE_CHANGED);
                break;
            }
        }
    }
}
