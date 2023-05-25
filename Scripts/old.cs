using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class old : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;
    public GameObject boxUI;
    public Animator animator;
    public GameObject oldtwo;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "yummy" && duck.boxtuch == false){
            Button.SetActive(true);
            GetComponent<Animator>().SetBool("talk",true);
            Debug.Log("ontrigger??!");
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag=="yummy"&& duck.boxtuch == false)
        {
            Button.SetActive(false);
            GetComponent<Animator>().SetBool("talk",false);
        }
                
    }

    private void OldAppear(){//box old 出現控制
        if (duck.boxtuch == true){
            oldtwo.SetActive(true);
            boxUI.SetActive(true);
            boxUI.transform.rotation=Quaternion.Euler(0.0f,0.0f,0.0f);
        }
        else if(duck.boxtuch == false){
            oldtwo.SetActive(false);
            boxUI.SetActive(false);
        }
    }
    private void Update() {
        OldAppear();
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.RightArrow))
        {
            talkUI.SetActive(true);
            GetComponent<Animator>().SetBool("talk",true);
            Button.SetActive(false);
        }
        
    }
    
    
}