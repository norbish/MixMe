﻿using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class DrinkChooseScript : MonoBehaviour {
	private SerialPort ArduinoDue = new SerialPort("COM3");
	private SerialPort ArduinoDueIN = new SerialPort("COM5");
	private string DrinkString;
	private string MixString;
	public string comPort = "COM3";
	public string comPortIn = "COM5";
	private byte[] barray = {0,0,0,0,0,0,0,0};
	// Use this for initialization
	void Start () 
	{
		
		ArduinoDue.BaudRate = 9600;//kan hende jeg bare må ha 1 script, hvis den kjører alle 4 ganger pga. knappene.
		ArduinoDue.PortName = comPort;//COM connected to BT
		ArduinoDue.Open();

		/*ArduinoDueIN.BaudRate = 9600;
		ArduinoDueIN.PortName = comPortIn;
		ArduinoDueIN.Open (); */

		//Thread thread = new Thread(new ThreadStart(readSerialThread));
		//thread.Start();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log (ArduinoDue.ReadLine ());
		/*
		if(ReceivedArduinoDueGoSignal == true)
		{
			StatusField.text = "Order processing";
			Drink1Button.enabled(false);
			Drink1Button.enabled(false);
			Drink1Button.enabled(false);
			Drink1Button.enabled(false);
		}
		if(ReceivedCarDriveSignal == true)
		{
			StatusField.text = "Moving cup";
		}
		if(ReceivedMixingDrinkSignal == true)
		{
			StatusField.text = "Mixing drink";
		}
		if(ReceivedReadySignal == true)
		{
			StatusField.text = "Ready for order";
		}
*/
	}
	public void readSerialThread()
	{


			while(true)
			Debug.Log (ArduinoDueIN.ReadExisting());
		Debug.Log ("tihihi");

	}
	public void onClick (string name)
	{
		if (name == "Drink1") 
		{
			DrinkString = "1,0,0,1";
			MixString = "0000";

			byte[] DrinkByte={1,0,0,1,0,0,0,0};
			//ArduinoDue.Write(DrinkByte, 0, DrinkByte.Length);
			
		}
		if (name == "Drink2") 
		{
			DrinkString = "0,1,0,1";
			MixString = "0000";

			byte[] DrinkByte={0,1,0,1,0,0,0,0};
			//ArduinoDue.Write(DrinkByte, 0, DrinkByte.Length);
			
		}if (name == "Drink3") 
		{
			DrinkString = "0,0,1,1";
			MixString = "0000";

			byte[] DrinkByte={0,0,1,1,0,0,0,0};
			//ArduinoDue.Write(DrinkByte, 0, DrinkByte.Length);
			
		}if (name == "Drink4") 
		{
			DrinkString = "1,0,1,1";
			MixString = "0000";

			byte[] DrinkByte={1,0,1,1,0,0,0,0};
			//ArduinoDue.Write(DrinkByte, 0, DrinkByte.Length);
			
		}
		
		
		
		Debug.Log (DrinkString);
		Debug.Log (MixString);
		ArduinoDue.WriteLine (DrinkString);
		//ArduinoDue.WriteLine (MixString);

		Debug.Log (ArduinoDueIN.ReadExisting());
		
		//Thread.Sleep (500);

		
	}
}