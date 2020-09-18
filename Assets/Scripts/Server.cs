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
			
			if(item.Value.log.Count > 0){
                // b.text = "value get";
				int lastPacketIndex = item.Value.packets.Count - 1;
                var address = item.Value.packets[lastPacketIndex].Address.ToString();
                if(address.Contains("/4/multitoggle/")){
                    var position = item.Value.packets[lastPacketIndex].Address.ToString().Replace("/4/multitoggle/","");
                    string[] xy = position.Split('/');
                    int x = int.Parse(xy[0]);
                    int y = int.Parse(xy[1]);
                    GameObject line = GameObject.Find("line" + xy[1]);
                    var pannel = line.transform.GetChild(x - 1);
                    if(item.Value.packets[lastPacketIndex].Data[0].ToString() == "1"){
                        pannel.gameObject.SetActive(true);
                    }
                    else{
                        pannel.gameObject.SetActive(false);
                    }
                }
			}
		}
        // Debug.Log(Time.deltaTime);
    }
}