using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using UnityEngine.UI;

public class DrinkChooseScript : MonoBehaviour {
	//WI-FI
	bool socketReady = false;
	TcpClient Socket;
	public NetworkStream dataStream;//typ serial
	StreamWriter ToArduino;
	StreamReader FromArduino;
	public string Host = "192.168.10.107";
	public int Port = 5001;//kan settes til hvilken som helst port SE OVER
	public Text StatusField;

	//BLUETOOTH
	private SerialPort ArduinoDue = new SerialPort();
	private SerialPort ArduinoDueIN = new SerialPort();
	private string DrinkString;
	public string comPort = "COM3";
	public string comPortIn = "COM5";
	void Start () 
	{
		//WI-FI
		StartCoroutine ("setupSocket");
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
		/*while (dataStream.DataAvailable) 
		{
			string status = readSocket();
			StatusField.text = status;
		}*/

	}
	public void setupSocket()
	{
		try{
			Socket = new TcpClient(Host,Port);
			dataStream = Socket.GetStream ();
			ToArduino = new StreamWriter(dataStream);
			FromArduino = new StreamReader(dataStream);
			socketReady = true;
			Debug.Log ("Socket created");
			}catch(SocketException e)
		{
			Debug.Log ("Socket exception: " + e);
		}
	}
	public void sendOrder(string order)
	{
		if (!socketReady)
			return;
		ToArduino.Write (order);
		Thread.Sleep (50);
		ToArduino.Flush ();

	}
	public string readSocket()
	{
		if (!socketReady)
			return "";
		if (dataStream.DataAvailable)
			return FromArduino.ReadLine ();
		return "NULL";
	}
	public void onClickWIFI(string order)
	{
		sendOrder (order);
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
