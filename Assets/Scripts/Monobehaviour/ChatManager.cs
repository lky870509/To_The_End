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
        chatData.Add(100, new string[] { "�ȳ��ϼ���, ����.", "������ ���ۿ� ���� �� ȯ���մϴ�." });
    }

    public string GetChat(int id, int chatIndex)
    {
        if (chatIndex == chatData[id].Length)
            return null;
        else
            return chatData[id][chatIndex];
    }


   
}
