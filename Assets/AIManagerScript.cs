using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIManagerScript : MonoBehaviour
{
    public logicScript logicScript;
    public birdScript birdScript;

    public SocketCommunicator socketCommunicator;

    public Text xStateText;
    public Text yStateText;

    private GameObject[] middlePipes;

    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<birdScript>();
        socketCommunicator = GameObject.FindGameObjectWithTag("Server").GetComponent<SocketCommunicator>();

    }

    // Update is called once per frame
    void Update()
    {
        getStateUsingHeight();
        getBirdXState();
    }

    private void getBirdXState(){
        middlePipes = GameObject.FindGameObjectsWithTag("middle");
        float birdDistance = birdScript.getBirdPostion().x;

        // for(int i = 0; i<middlePipes.Length; i++){
        //     Debug.Log("middlepipe ID: " + middlePipes[i].GetInstanceID());
        // }
    }
 

    private int getStateUsingHeight(){
        int state = 0;
        float birdHeight = birdScript.getBirdPostion().y;
        
        Debug.Log("birdHeight: " + birdHeight);
        if(birdHeight > 0) {
            state = 1;
        } else if (birdHeight > 0 && birdHeight < 17) {
            state = 2;
        }
        yStateText.text = state.ToString(); 
        return state;
    }

    public void SendData(){
        socketCommunicator.SendMessageToServer("Bird State: " + getStateUsingHeight());
    }
}
