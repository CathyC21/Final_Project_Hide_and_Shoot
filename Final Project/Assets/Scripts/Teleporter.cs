﻿using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	public Teleporter teleOut1;
	public Teleporter teleOut2;
	//public Transform previous;
	public bool teleported = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other){
		if (other.GetComponent<Rigidbody>())
			Debug.Log("Test");
		
		if(!teleported)
		{
			
			if (Random.value<0.5)
			{
				teleOut1.teleported = true;
				other.transform.position = teleOut1.transform.position;
				
				
			}
			else
			{
				teleOut2.teleported = true;
				other.transform.position = teleOut2.transform.position;
				
				
			}
		}
		
		
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Rigidbody>())
		{
			teleported = false;
		}
	}
	
	
}