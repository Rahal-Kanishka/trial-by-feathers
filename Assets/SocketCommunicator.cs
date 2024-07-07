using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

public class SocketCommunicator : MonoBehaviour
{
    private string serverIP = "localhost"; 
    private int port = 5001; 
    // private string messageToSend = "Hello from Unity!";
    // Start is called before the first frame update
    public birdScript birdScript;

    void Start(){
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<birdScript>();   
    }
    public void SendMessageToServer(String data)
    {
        try
        {
            // Create TCP socket
            TcpClient client = new TcpClient(serverIP, port);

            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();
            // Convert message to byte array
            byte[] messageBytes = Encoding.ASCII.GetBytes(data);

            // Send message
            stream.Write(messageBytes, 0, messageBytes.Length);

            // Receive response (assuming a simple string response)
            byte[] responseBytes = new byte[256];
            int bytesReceived = stream.Read(responseBytes, 0, responseBytes.Length);
            string response = Encoding.ASCII.GetString(responseBytes, 0, bytesReceived);

            Debug.Log("Server response: " + response);

            // Close connection
            stream.Close();
            client.Close();
        }
        catch (SocketException e)
        {
            Debug.LogError("Socket error: " + e.Message);
        }
    }
}
