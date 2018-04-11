using UnityEngine;
using System.Collections;

public class LedController : MonoBehaviour
{
    public SerialHandler serialHandler;

    void Start() {

    }

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.A) ) {
            serialHandler.Write("0");
        }
        if ( Input.GetKeyDown(KeyCode.S) ) {
            serialHandler.Write("1");
        }
    }
}