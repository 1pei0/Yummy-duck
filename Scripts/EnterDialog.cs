using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDialog : MonoBehaviour
{
    public GameObject enterDialog;
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "yummy" && duck.canopendoor == true)
        {
            enterDialog.SetActive(true);
        }    
    }

    private void OnTriggerExit2D(Collider2D collission) 
    {
        enterDialog.SetActive(false);
    }

}
