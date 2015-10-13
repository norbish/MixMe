using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using UnityEngine.UI;

public class DrinkChooseScript : MonoBehaviour {
	//WI-FI
	bool socketReady1 = false;
	bool socketReady2 = false;
	TcpClient Socket;
	TcpClient Socket2;
	public NetworkStream dataStream;//typ serial
	public NetworkStream inStream;
	StreamWriter ToArduino;
	StreamReader FromArduino;
	public string Host = "192.168.10.107";
	public int outPort = 5001;//kan settes til hvilken som helst port SE OVER
	public int inPort = 5002;
	public Text StatusField;
	string statusText = "Ready for order";
	char[] displayText = new char[2];

	//BLUETOOTH
	/*private SerialPort ArduinoDue = new SerialPort();
	private SerialPort ArduinoDueIN = new SerialPort();
	private string DrinkString;
	public string comPort = "COM3";
	public string comPortIn = "COM5";*/
	void Start () 
	{
		//WI-FI
		StartCoroutine ("setupSocketOut");
		StartCoroutine ("setupSocketIn");
		//setupSocket ();



		//BLUETOOTH
		/*ArduinoDue.BaudRate = 9600;
		ArduinoDue.PortName = comPort;//COM connected to BT
		ArduinoDue.Open ();

		ArduinoDueIN.BaudRate = 9600;
		ArduinoDueIN.PortName = comPortIn;
		ArduinoDueIN.Open (); */

		//Thread thread = new Thread(new ThreadStart(readSerialThread));
		//thread.Start();


	}
	
	// Update is ca	lled once per frame
	void Update () 
	{
		
			//tartCoroutine("readSocket");
		//readSocket ();
			//StatusField.text = statusText;
		

	}
	public void setupSocketOut()
	{
		try{
			Socket = new TcpClient(Host,outPort);
			dataStream = Socket.GetStream ();
			ToArduino = new StreamWriter(dataStream);
			//FromArduino = new StreamReader(dataStream);
			socketReady1 = true;
			Debug.Log ("out Socket created");
			}catch(SocketException e)
		{
			Debug.Log ("out Socket exception: " + e);
		}
	}
	public void setupSocketIn()
	{
		try{
			Socket2 = new TcpClient(Host,inPort);
			inStream = Socket2.GetStream ();
			//ToArduino = new StreamWriter(inStream);
			FromArduino = new StreamReader(inStream);
			socketReady2 = true;
			//inStream.ReadTimeout = 1;
			Debug.Log ("in Socket created");
		}catch(SocketException e)
		{
			Debug.Log ("in Socket exception: " + e);
		}
	}

	public void sendOrder(string order)
	{
		if (!socketReady1)
			return;
		ToArduino.Write (order);
		Thread.Sleep (50);
		ToArduino.Flush ();
		StatusField.text = "Mixer Status:\nOrder Placed";

	}
	public string readSocket()
	{
		//setupSocketIn ();
		//Thread.Sleep (3000);

			/*if (!socketReady2) {
				return "";
			}*/

			try 
		{

			 //statusText = FromArduino.ReadLine ();

			//return FromArduino.ReadLine ();
			statusText = FromArduino.ReadLine();
			Debug.Log ("mottatt" + statusText);
			return FromArduino.ReadLine ();
		}catch(SocketException e)
		{
			return "cant read" + e;
		}

	}
	public void onClickWIFI(string order)
	{
		sendOrder (order);
		//readSocket ();
	}
	public void onReceiveClick()
	{
		StatusField.text = readSocket ();
	}


	//BLUETOOTH
	/*public void readSerialThread()
	{


			while(true)
			Debug.Log (ArduinoDueIN.ReadExisting());

	}
	public void onClickBT (string name)
	{




		if (name == "Drink1") 
		{
			DrinkString = "2,0,0,3";
			
		}
		if (name == "Drink2") 
		{
			DrinkString = "0,1,0,1";
			
		}if (name == "Drink3") 
		{
			DrinkString = "0,0,1,1";
			
		}if (name == "Drink4") 
		{
			DrinkString = "1,0,1,1";
			
		}
		
		
		
		Debug.Log (DrinkString);
		ArduinoDue.WriteLine (DrinkString);
		//ArduinoDue.WriteLine (MixString);

		//Debug.Log (ArduinoDueIN.ReadExisting());
		
		//Thread.Sleep (500);

		
	}*/
}
