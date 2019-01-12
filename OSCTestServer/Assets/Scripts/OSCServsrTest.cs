using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;
using UnityEngine.UI;

public class OSCServsrTest : MonoBehaviour {

    public Image[] images;
    string s1 = "123456789";

    int currentDataLen = 0;

	void Start () {
        OSCHandler.Instance.Init();
	}
	
	void Update () {
        ListenToOSC();
	}

    void ListenToOSC(){
        OSCHandler.Instance.UpdateLogs();
        Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();
        servers = OSCHandler.Instance.Servers;
        foreach(KeyValuePair<string, ServerLog> item in servers){
            if (currentDataLen != item.Value.packets.Count){
                currentDataLen = item.Value.packets.Count;
                int lastPacketIndex = item.Value.log.Count - 1;
                string s2 = item.Value.packets[lastPacketIndex].Data[0].ToString();
                if (s1.Contains(s2))
                {
                    Debug.Log("s2: " + s2);
                    int i = int.Parse(s2);
                    //gameObject.transform.position = new Vector3(x, 0, 0);
                    images[i - 1].color = new Color(255.0f, 255.0f, 0f);
                    s1 = s1.Replace(s2, "");
                    if (s1 == "")
                    {
                        for (int j = 0; j < images.Length; j++)
                        {
                            images[j].color = new Color(255.0f, 255.0f, 255.0f);
                            s1 = "123456789";
                        }
                    }
                }
            }
        }
    }
}
