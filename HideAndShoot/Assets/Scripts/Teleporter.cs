using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
    public Transform teleOut1;
    public Transform teleOut2;
    //public Transform previous;
    public bool teleport = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider other){
        if (other.GetComponent<Rigidbody>())
        {
          
            int randomNum = (int)Random.Range(1, 2);
            if (randomNum == 1 && teleport == false)
            {
               
                other.transform.position = teleOut1.transform.position;
                
                
            }

            if (randomNum == 2 && teleport == false)
            {
               
                other.transform.position = teleOut1.transform.position;
               

            }
        }

        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            teleport = true;
        }
    }

   
}
