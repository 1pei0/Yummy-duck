 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    public GameObject effect;
    // public Bag bag;
    private void Start(){
      player=GameObject.FindGameObjectWithTag("yummy").transform;
    }
    public void SpawnDroppedItem(){
        Vector2 playerPos=new Vector2(player.position.x,player.position.y+3);
        Instantiate(item,playerPos,Quaternion.identity );
    }

    public void use(){
        Debug.Log("ggg");
        Instantiate(effect,player.position,Quaternion.identity);
        Destroy(item);
        
    }
    
}

