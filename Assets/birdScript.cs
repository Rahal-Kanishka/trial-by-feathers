using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapsStrength = 10;

    public logicScript logicScript;

    public Boolean isBirdAlive =  true;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBirdAlive && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))){
            myRigidBody.velocity = Vector2.up * flapsStrength;   
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        isBirdAlive = false;
        logicScript.gameOver();
    }

    public Vector3 getBirdPostion(){
        return transform.position;
    }
}
