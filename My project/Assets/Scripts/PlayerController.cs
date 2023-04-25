using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
	public GameObject winTextObject;
    public AudioSource pickUpAudio;
    
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement*speed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            count = count + 1;
            pickUpAudio.Play();
            other.gameObject.SetActive(false);

            SetCountText ();
        }
    }

    void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 7) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
		}
	}

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
