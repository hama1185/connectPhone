using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityOSC;
using System.Text;
using System.Threading.Tasks;

public class Server : MonoBehaviour {
    // Start is called before the first frame update
    #region Network Settings //----------追記
	public string serverName;
	public int inComingPort; //----------追記
	#endregion //----------追記

	private Dictionary<string, ServerLog> servers;
    // public Text a;
    // public Text b;
    // public Text c;
    void Awake() {
        serverName = "IpadAir";
        inComingPort = 8000;
        // Debug.Log("server IP : " + serverName + "   port : " + inComingPort);

        OSCHandler.Instance.serverInit(serverName,inComingPort); //init OSC　//----------変更
        servers = new Dictionary<string, ServerLog>();
    }

    // Update is called once per frame

    void Update() {
        OSCHandler.Instance.UpdateLogs();
		servers = OSCHandler.Instance.Servers;
    }

    void LateUpdate(){
        foreach( KeyValuePair<string, ServerLog> item in servers ){
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
            
			if(item.Value.log.Count > 0){
                // b.text = "value get";
				int lastPacketIndex = item.Value.packets.Count - 1;
                
                var value = item.Value.packets[lastPacketIndex].Data[0].ToString();
                Debug.Log(value);
			}
		}
        // Debug.Log(Time.deltaTime);
    }
}