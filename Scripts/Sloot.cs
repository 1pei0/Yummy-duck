using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sloot : MonoBehaviour
{
    private Thing thing;
    public Bag bag;
    public int i;
    private void Start(){
      thing=GameObject.FindGameObjectWithTag("yummy").GetComponent<Thing>();
    }
    private void Update(){
        if(transform.childCount <= 0){
            thing.isFull[i]=false;
        }
    }

     public void DropItem(){
      foreach(Transform child in transform){
          child.GetComponent<Spawn>().SpawnDroppedItem();
          GameObject.Destroy(child.gameObject);
      }
  }
}
