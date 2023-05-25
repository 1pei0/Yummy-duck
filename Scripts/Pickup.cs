using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
   private Thing thing;
   public Bag bag;
   public GameObject itemButton;
   private void Start(){
       thing=GameObject.FindGameObjectWithTag("yummy").GetComponent<Thing>();
   }


    void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("yummy")){
        for(int i=0;i<thing.slots.Length;i++)
        {
            if(thing.isFull[i]==false){
                thing.isFull[i]=true;
                Instantiate(itemButton,thing.slots[i].transform,false);
                Destroy(gameObject);
                break;
            }
        }
    }
    }
}
