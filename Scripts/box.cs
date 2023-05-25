using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class box : MonoBehaviour

{
    public GameObject Key;
    public float deltyTime;
    private bool canOpen;
    private bool isOpen;
    private int Open;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void GetkeyPosition(){
        Instantiate(Key,transform.position,Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag=="Death line")
        {
            canOpen = true;
            transform.rotation=Quaternion.Euler(0.0f,0.0f,0.0f);
            GetComponent<Animator>().SetBool("drop",true); 
            
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag=="Death line")
        {
                   
            Open += 1;
            // Debug.Log(Open);
            // Debug.Log(canOpen);
            if(canOpen == true && Open == 1){
                isOpen = true;
                Invoke("GetkeyPosition",deltyTime);    

            }
        }
    }
    
}
