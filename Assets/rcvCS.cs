using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;
using UnityEngine;

public class rcvCS : MonoBehaviour {
    SerialPort sp = new SerialPort("/dev/tty.Bluetooth-Incoming-Port", 9600);

    public Text T_rcv;

    private string lastrcvd = "";
    private string lineString = "";
	public GameObject cube;
	public Rigidbody rigidbody;

    void Start () {
        sp.Open ();
        sp.ReadTimeout = 1;
		cube = GameObject.Find("cube");
		cube.SetActive(true);
		rigidbody = cube.GetComponent<Rigidbody>();
		// rigidbody.AddForce(5,5,5);
    }

    // Update is called once per frame
    void Update () {
        byte rcv;
        char tmp;
        try {
            rcv = (byte)sp.ReadByte();
            if (rcv != 255) {
                tmp = (char)rcv;
                lastrcvd = lastrcvd + tmp.ToString();
                T_rcv.text = lastrcvd;
				string word = tmp.ToString();
				if(!"{".Equals(word) && !"}".Equals(word)) {
					lineString = lineString + word;
				}
				if("}".Equals(word)) {
					Debug.Log(lineString);
					var vector = lineString.Split(',');
					lineString = "";
					rigidbody.AddForce(float.Parse(vector[0]), float.Parse(vector[1]), float.Parse(vector[2]));
				}
            }
        }
        catch(System.Exception) {
        }
    }
}