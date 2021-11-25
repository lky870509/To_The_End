using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public ChatManager chatManager;
    public GameObject chatPanel;
    public Text chatText;
    public GameObject scanObject;
    public int chatIndex;
    public bool isAction;
   
    public void Action(GameObject scanObj)
    {

       
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Chat(objData.id, objData.isStart);

        chatPanel.SetActive(isAction);
    }
    void Chat(int id, bool isStart)
    {
        string chatData = chatManager.GetChat(id, chatIndex);

        if(chatData==null)
        {
            isAction = false;
        }

        if(isStart)
        {
            chatText.text = chatData;
        }
        else
        {
            chatText.text = chatData;
        }

        isAction = true;
        chatIndex++;
    }
}
