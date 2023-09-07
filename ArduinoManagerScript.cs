using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class ArduinoManagerScript : MonoBehaviour
{
    private static ArduinoManagerScript instance;
    public static ArduinoManagerScript Instance
    {
        get { return instance; }
    }

    public string PortNumber;
    public string BaudRate;

    private SerialPort port;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        if( port == null)
        {
            port = new SerialPort(PortNumber, int.Parse(BaudRate));

            try
            {
                port.Open();
                Debug.Log("serial is opened");
            }
            catch (Exception ex)
            {
                Debug.LogError("error: " + ex.Message);
            }
        }
    }

    public string KirimPesan(string _pesan)
    {
        string status = "failed";


        if( port.IsOpen && port != null)
        {
            port.Write(_pesan);
            status = "sukses";
        }

        return status;
    }

    private void OnApplicationQuit()
    {
        port.Close();
        Debug.Log("port is closed");
    }
}
