using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMiddleScript : MonoBehaviour
{
    public logicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 3){
            logicScript.addScore(1);
        }
    }
}
