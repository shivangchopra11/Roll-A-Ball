using UnityEngine;
using System;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerController : MonoBehaviour 
{
	public float speed = 800.0f;
	private int count;
	public Text countText;
	public Text winText;
	public Button reset;
	void Start()
	{
		reset.onClick.AddListener(TaskOnClick);
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		count = 0;
		SetCountText ();
		winText.text = "";
	}
		

	void FixedUpdate()
	{
		
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
//		float moveHorizontal = CrossPlatformInputManager.GetAxis ("Horizontal");
//		float moveVertical = CrossPlatformInputManager.GetAxis ("Vertical");
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = Input.acceleration.y;

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody> ().AddForce (movement * speed);
	}

	void TaskOnClick() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText ();
		}

	}
	void SetCountText() 
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12)
			winText.text = "You Win!";
	}

}