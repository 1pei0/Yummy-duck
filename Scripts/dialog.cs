using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
    [Header("UI組件")]
    public Text textLabel;
    
    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public static bool talkend;//yummy鴨對話bool
    List<string> textList = new List<string>();

    // Start is called before the first frame update
    private void Awake() {
        //11:47  
        GetTextFormFile(textFile);  
            
    }
    private void OnEnable() {
        textLabel.text = textList[index];
        index++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            talkend = true;//yummy鴨對話bool
            Debug.Log(talkend);
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            textLabel.text = textList[index];
            index++;
            talkend = false;//yummy鴨對話bool
        }
    }
    void GetTextFormFile(TextAsset file){
        
        textList.Clear();
        index = 0;
        talkend = false;

        var lineData = file.text.Split('\n');
        foreach (var line in lineData)
        {
            textList.Add(line);
        }
     }


}