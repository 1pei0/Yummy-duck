using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class duck : MonoBehaviour
{
  
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject Bag;
    bool isOpen;
    //public old dialogTalk;
    public static bool canopendoor = false;

    public Collider2D coll;
    public Text KeyNumber;
    public float moveSpeed;
    public float jumpSpeed;
    public int machine = 0;
    public int key = 0;
    public bool tuch;//yummy鴨對話bool設定
    private bool isHurt;//受傷判定 默認為false
    public static bool boxtuch;
    protected AudioSource DuckAudio;
    public AudioSource Jump,EatKey;
    public bool jump;

    void Start()
    {
        //windowParent = this.transform.parent.GetComponent<RectTransform>();
        //dragTrue = windowParent.GetComponent<DragDemo>();
        DuckAudio = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
    
        if(!isHurt)
        {
             Movement(); 
        }
        else if(isHurt)
        {
            animator.SetBool("hurt", true);
            animator.SetFloat("run", 0);
            if(Mathf.Abs(rb.velocity.x)<0.1f)
            {
                animator.SetBool("hurt", false);
                animator.SetBool("stand", true);
                isHurt = false;
            }
        }   
        OpenBag(); 
        // DialogWalk(); 
        TalkMove();//yummy鴨對話呼叫函式
        
     
    }
   

    void Movement()
    {
        float Horizontalmove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");

        //角色移動
        if(Horizontalmove != 0)
        {
        // rd.velocity = new Vector2(Horizontalmove * moveSpeed * Time.deltaTime, rd.velocity.y);
            animator.SetFloat("run",Mathf.Abs(facedirection));
        }
        
        if(facedirection != 0)
        {
            transform.localScale = new Vector3(-facedirection, 1, 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
                transform.Translate(moveSpeed*Time.deltaTime,0,0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
                transform.Translate(-moveSpeed*Time.deltaTime,0,0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
                transform.Translate(0,jumpSpeed*Time.deltaTime,0);
                // Debug.Log("fff");
                // jump=true;
                // Jump.Play();
                

        }
        else if (Input.GetKey(KeyCode.S))
        {
            DuckAudio.Play();

        }

    
        // if(Input.GetButtonDown("Jump"))
        // {
        //     rd.velocity = new Vector2(rd.velocity.x, jumpSpeed * Time.deltaTime);

        // }

    }
    // void jumpstudio(){
    //     if(jump == true){
    //         Jump.Play();
    //     }
    // }
    void OpenBag()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isOpen =!isOpen;
            Bag.SetActive(isOpen);
        }
    }

 private void TalkMove(){//yummy鴨對話移動控制
        if (dialog.talkend == true || tuch == false)
            {
                //Debug.Log("dddddooooo");
                moveSpeed = 10f;
            }
            else if(tuch == true && dialog.talkend == false){
                // Debug.Log("後面了");
                moveSpeed = 0f;
            }
    }
    
    
     private void OnTriggerExit2D(Collider2D other) {//yummy鴨對話離開控制
        if(other.tag == "old")
        {
            tuch = false;
        }
        else if(other.tag=="talkdistance")
        {
            boxtuch = false;   
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) { //關卡道具蒐集-探測儀
        if (other.tag == "machine")
        {
            Destroy(other.gameObject);
            machine+=1;
        }
        else if(other.tag == "key")
        {
            EatKey.Play();
            Destroy(other.gameObject);
            key+=1;
            KeyNumber.text = key.ToString();
            if(key == 5){
                Debug.Log("蒐集到五個鑰匙了！!");
                canopendoor = true;
            }
        }
        else if(other.tag == "old")//yummy鴨對話碰到控制
        {
            tuch = true;
            // Debug.Log("剛開始碰到");       
        }
        else if(other.tag=="End"/*&&"key"=5*/)
        {
            // tuch=true;
            Debug.Log("Game over");   
        }
        else if(other.tag=="talkdistance")
        {
            boxtuch = true;   
        }
    }

      //碰到敵人 private 
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "human")
        {
            if(transform.position.x<collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-15, rb.velocity.y);
                isHurt = true;
            }
            else if(transform.position.x>collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(15, rb.velocity.y);
                isHurt = true;
            }
        }
        
    }
  
   /* void OnTriggerStay2D(Collider2D other)
    {
       
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //以下产生具体的吸附效果，需要根据吸附情况的不同进行相应计算和重写
                    tempVector = windowParent.localPosition;
                    y = windowCollider.localPosition.y;
                    tempVector.y = 0f;
                    windowParent.localPosition = tempVector + new Vector3(0, y - 100, 0);
                }
            }
            
            if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 0) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 0))
            {
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //保y，改x
                    tempVector = windowParent.localPosition;
                    x = windowCollider.localPosition.x;
                    tempVector.x = 0f;
                    windowParent.localPosition = tempVector + new Vector3(x - dragFalse.itemLen, 0, 0);
                }
            }

        }
     
        if (other.gameObject.name == "Col_3")
        {
            if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 0) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 1))
            {
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //保y，改x
                    tempVector = windowParent.localPosition;
                    x = windowCollider.localPosition.x;
                    tempVector.x = 0f;
                    windowParent.localPosition = tempVector + new Vector3(x - dragFalse.itemLen, 0, 0);
                }
            }
        }
        
        if (other.gameObject.name == "Col_4")
        {
            if (windowParent.GetComponent<RectTransform>().pivot == new Vector2(0, 1) && windowCollider.GetComponent<RectTransform>().pivot == new Vector2(0, 0))
            {
                if (dragTrue.absorbFlag == true && dragTrue.allowMove == false && windowParent.gameObject == PositionControl.currentWindow)
                {
                    Debug.Log("OnTriggerStay2D：" + this.transform.name + "-" + other.gameObject.name);
                    //保x，改y
                    tempVector = windowParent.localPosition;
                    y = windowCollider.localPosition.y;
                    tempVector.y = 0f;
                    windowParent.localPosition = tempVector + new Vector3(0, y  - dragFalse.itemWidth, 0);
                }
            }
        }*/

}

    




