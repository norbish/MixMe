using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using System.Timers.Timer;

public class ToggleSettings : MonoBehaviour {
	public Toggle ToggleButton;
	public GameObject settings;
	public Image ToggleImage;

	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	public void isClicked()
	{

		StartCoroutine (ChangePosition ());
	}

	IEnumerator ChangePosition()
	{
		if (ToggleButton.isOn == true) //then move up
		{
			//texture
			ToggleImage.sprite = Resources.Load<Sprite>("ArrowDown");
			//ToggleImage.GetComponent<SpriteRenderer>().sprite = ArrowDown;
			for(int i = 0; i < 50; i++)
			{
				settings.transform.position = new Vector2(settings.transform.position.x, settings.transform.position.y + 10);
				yield return new WaitForSeconds(.001f);
			}
		}
		if (ToggleButton.isOn == false) //then move down
		{
			//texture
			ToggleImage.sprite = Resources.Load <Sprite>("ArrowUp") ;
			for(int i = 0; i < 50; i++)
			{
				settings.transform.position = new Vector2(settings.transform.position.x, settings.transform.position.y - 10);
				yield return new WaitForSeconds(.001f);
			}
		}
	}
}
