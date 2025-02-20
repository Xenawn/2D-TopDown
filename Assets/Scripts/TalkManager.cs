using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    public TextMeshProUGUI talk;
    public GameObject talkImg;

    
    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
       
    }

    void GenerateData()
    {
        //id = 1 : lizard
        talkData.Add(1000, new string[] { "안녕", "나의 게임 세상에 온 걸 환영해" });

;
    }
    public string GetTalk(int id, int talkIndex) //Object의 id , string배열의 index
    {
        return talkData[id][talkIndex]; //해당 아이디의 해당
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        talkImg.SetActive(true);
        talk.gameObject.SetActive(true);
        talk.text = " Go to the Game Zone\n Go up ";
     


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        talk.gameObject.SetActive(false);
        talkImg.SetActive(false);
    }


}
