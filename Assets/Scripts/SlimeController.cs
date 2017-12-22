using UnityEngine;
using System.Collections;

public class SlimeController : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D myRigidbody;

	private bool moving;

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;

	private Vector3 moveDirection;

	public float waitToReload;
	private bool reloading;
	private GameObject Player;

	// Use this for initialization
	void Start() {
		myRigidbody = GetComponent<Rigidbody2D>();

		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;

		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
	}

	// Update is called once per frame
	void Update() {

		if (moving)
		{
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;

			if(timeToMoveCounter < 0f)
			{
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}


		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;

			if(timeBetweenMoveCounter < 0f)
			{
				moving = true;
				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

				moveDirection = new Vector3(Random.Range (-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
			}
		}

	    if(reloading)
		{
			waitToReload -= Time.deltaTime;
			if(waitToReload < 0)
			{   //this doesn't work as the object "player" has been destroyed and is unloaded from memory
                //Player.SetActive(true);
                Application.LoadLevel(Application.loadedLevel);
                //Use SceneManager.LoadScene("Starting Area");

            }
		}
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject); //this is where the problem begins. This will unload the PC and all associated scripts
            //the set active(false) allows it to be taken up by garbage collection, clearing it from memory
            //other.gameObject.SetActive(false);
            //reloading = true;
            //thePlayer.SetActive(true);
            //Application.LoadLevel(Application.loadedLevel);
        }
    }
}