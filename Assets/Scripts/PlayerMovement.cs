using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float speed = 10f;

    private Rigidbody2D myBody;
	// Use this for initialization
	void Awake () {
        myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 vel = myBody.velocity;
        vel.x = Input.mousePosition.x * 0.05f;
        //vel.x = test * speed;
        myBody.velocity = vel;
	}

    
}
