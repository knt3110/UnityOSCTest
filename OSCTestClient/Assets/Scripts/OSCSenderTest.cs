using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;

public class OSCSenderTest : MonoBehaviour
{

    bool startFlag = false;
    void Start()
    {
        startFlag = FindObjectOfType<GameController>().flag;
        OSCHandler.Instance.Init();
    }

    void Update()
    {
        if (startFlag)
        {
            CheckOSCSend();
        }
    }

    public void CheckOSCSend()
    {
        if(Input.anyKeyDown){
            string inputStr = Input.inputString;
            Debug.Log(inputStr);
            string allCharChank = "0123456789";
            if(allCharChank.Contains(inputStr)){
                Debug.Log(inputStr + " is pressed");
                int sentInt;
                int.TryParse(inputStr, out sentInt);
                OSCHandler.Instance.SendMessageToClient("OSCClientTest", "/Audio", sentInt);
            } else {
                Debug.Log(inputStr);
            }
        }
    }
}
