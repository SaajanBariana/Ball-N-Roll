using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Text countText;
	public Text winText;
	public Rigidbody rb;
	public float speed;
	private int count;
	public Text theTimer;
	public float myTimer;
	public Vector3 movement;
	public Vector3 jumpSpeed;
	//public Text beginningText;
	 
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		theTimer.text = "";
		jumpSpeed = new Vector3(Input.GetAxis("Horizontal"), 6, Input.GetAxis("Vertical"));
		//beginningText.text = "";

	}

	void Update()
	{
		myTimer += Time.deltaTime;
	}
	  
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal3");
		float moveVertical = Input.GetAxis ("Vertical3");

		if(Input.GetButton("Jump"))
		   {
			rb.position += jumpSpeed * Time.deltaTime;
		}
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed * Time.deltaTime);
		if (rb.position.y < -6) {
			rb.position = new Vector3(0.93f, 2f, 0f);
			rb.velocity = new Vector3(0, 0, 0);
		}

	}
	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == "Pickup") 
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
		if (other.gameObject.tag == "SpeedUp") {
			rb.AddForce (movement * speed * Time.deltaTime * 100);
		} 
		if (other.gameObject.tag == "SpeedUp2") {
			rb.AddForce (movement * speed * Time.deltaTime * 1000);
		}
	}
	 
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		//if (count == 0)
		//{
		//	beginningText.text = "Collect all 12 boxes!";
		//}

		if(count >= 13)
		{
			winText.text = "YOU WIN!!!!! :)";
			myTimer = Time.timeSinceLevelLoad;
			theTimer.text = "Your time is: " + myTimer.ToString();
		}
	}
}