using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

public class ConnectToBT : MonoBehaviour {
	public SerialPort ArduinoDue = new SerialPort();
	public int counter = 0;
	// Use this for initialization
	void Start () 
	{

		ArduinoDue.BaudRate = 9600;
		ArduinoDue.PortName = "COM6"; // Set in Windows
		ArduinoDue.Open();

	}
	
	// Update is called once per frame
	void Update () 
	{
		/*while (ArduinoDue.IsOpen)
		{
			// WRITE THE INCOMING BUFFER TO CONSOLE
			while (ArduinoDue.BytesToRead > 0)
			{
				Console.Write(Convert.ToChar(ArduinoDue.ReadChar()));
			}
			// SEND
			ArduinoDue.WriteLine("PC counter: " + (counter++));
			Thread.Sleep(500);
		}*/
	}
}
