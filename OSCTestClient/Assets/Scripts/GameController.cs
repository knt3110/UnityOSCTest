using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    public InputField ipField;
    public InputField portField;
    public Button startButton;
    public GameObject client;

    public string ip;
    public int port;

    public bool flag = false;

	void Start () {
        startButton.onClick.AddListener(ConnectToServer);
	}

    public void ConnectToServer()
    {
        ip = ipField.text;
        port = int.Parse(portField.text);
        flag = true;
        GameObject.Find("Canvas").SetActive(false);
        client.SetActive(true);
    }
}
