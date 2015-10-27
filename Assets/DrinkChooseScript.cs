using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using UnityEngine.UI;
using System.Text;

public class DrinkChooseScript : MonoBehaviour {
	//WI-FI
	bool socketReady1 = false;
	TcpClient Socket;
	public NetworkStream dataStream;//typ serial
	public NetworkStream inStream;
	StreamWriter ToArduino;
	public string Host = "192.168.10.229";
	public int outPort = 5001;//kan settes til hvilken som helst port SE OVER
	public int inPort = 5002;
	public Text StatusField;
	char[] displayText = new char[2];
	public Text netHost;
	public Text statusTextHost;
	public bool pBool = true;
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
		//StartCoroutine ("setupSocketIn");
		//StartCoroutine ("readSocket");
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

			//StartCoroutine("readSocket");
		//readSocket ();
			//StatusField.text = statusText;
		

	}
	public void hostTest()
	{
        
		if (netHost.text == "") {
			statusTextHost.text = "insert IP of mixer!";
		} else 
		{
			Host = netHost.text;
            try
            {
                Socket = new TcpClient(Host, outPort);
                dataStream = Socket.GetStream();
                ToArduino = new StreamWriter(dataStream);
                //FromArduino = new StreamReader(dataStream);
                socketReady1 = true;
                Debug.Log("out Socket created from StatusCheck");
                statusTextHost.text = "Connected to: " + netHost.text;
            }
            catch (SocketException e)
            {
                //socketReady1 = false;

                statusTextHost.text = "Error connecting to: " + netHost.text + " Check if device is connected to same network as mixer.";
                Debug.Log("out Socket exception: " + e);
            }
            
		}
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
			StatusField.text = "Ready for order";
			}catch(SocketException e)
		{
			Debug.Log ("out Socket exception: " + e);
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

    
	/*public void readSocket()
	{
		//setupSocketIn ();
		//Thread.Sleep (3000);

			//if (!socketReady2) {
			//	return "";
			//}
		//while(true)
		//if(inStream.DataAvailable)
			try 
		{

			 //statusText = FromArduino.ReadLine ();
			Debug.Log ("try receiving");
            //return FromArduino.ReadLine ();

            //StatusField.text = FromArduino.ReadLine();
			Debug.Log ("mottatt" + FromArduino.ReadLine());

			 //FromArduino.ReadLine ();
		}catch(SocketException e)
		{
			Debug.Log ( "cant read" + e);

		}

	}*/
	public void onClickWIFI(string order)
	{
		sendOrder (order);
		//readSocket ();
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
