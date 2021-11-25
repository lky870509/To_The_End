using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{

    Dictionary<int, string[]> chatData;

    void Awake()
    {
        chatData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        chatData.Add(100, new string[] { "안녕하세요, 용사님.", "모험의 시작에 오신 걸 환영합니다." });
    }

    public string GetChat(int id, int chatIndex)
    {
        if (chatIndex == chatData[id].Length)
            return null;
        else
            return chatData[id][chatIndex];
    }


   
}
