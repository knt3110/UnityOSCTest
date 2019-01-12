using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    public InputField ipField;
    public InputField portField;
    public Button startButton;
    public GameObject client;
    public GameObject canvas2;

    public string ip;
    public int port;

    public bool flag = false;

	void Start () {
        startButton.onClick.AddListener(ConnectToServer);
	}

    // IPアドレスとポート番号を入力してサーバと接続する関数
    public void ConnectToServer()
    {
        ip = ipField.text;
        port = int.Parse(portField.text);
        flag = true;
        GameObject.Find("Canvas").SetActive(false);
        canvas2.SetActive(true);
        client.SetActive(true);
    }
}
