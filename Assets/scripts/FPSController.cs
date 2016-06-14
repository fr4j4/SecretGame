using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {
	private Camera camera;
	private Rigidbody rb;
	private KeyCode forwardKey,backwardKey,leftKey,rightKey;

	private float rotationY = 0.0f;
	private float rotationX = 0.0f;
	// Use this for initialization
	void Start () {
		//UnityEngine.Cursor.visible = false;
		camera = this.GetComponentInChildren<Camera> ();//obtengo la cámara asociada al jugador
		rb=this.GetComponent<Rigidbody>();//obtengo el rigidBody asociado al jugador
		forwardKey=KeyCode.W;
		backwardKey=KeyCode.S;
		leftKey=KeyCode.A;
		rightKey=KeyCode.D;
	}
	
	// Update is called once per frame
	void Update () {

	}
	//mas preciso que el update
	void FixedUpdate(){
		controlKeybInput ();
		controlMouseInput ();
	}

	private void controlKeybInput(){//reaccion del jugador frente a pulsaciones de teclas en el teclado
		float speed=10f;
		Vector3 cam_forw=camera.transform.forward;
		cam_forw.y = 0;
		if(Input.GetKey(forwardKey)){
			rb.AddRelativeForce (cam_forw*speed,ForceMode.Acceleration);
		}else if(Input.GetKey(backwardKey)){
			rb.AddRelativeForce (cam_forw*-speed,ForceMode.Acceleration);

		}

		if(Input.GetKey(rightKey)){
			rb.AddRelativeForce (camera.transform.right*speed,ForceMode.Acceleration);
		}else if(Input.GetKey(leftKey)){
			rb.AddRelativeForce (camera.transform.right*-speed,ForceMode.Acceleration);
		}
	}
	private void controlMouseInput(){//reaccion del jugador frente a movimientos y pulsaciones de mouse
		float xAxis = Input.GetAxis ("Mouse X");
		float yAxis= Input.GetAxis ("Mouse Y");
		float speed=1.25f;
		float minX = -45.0f;
		float maxX = 45.0f;

		float minY = -45.0f;
		float maxY = 45.0f;

		float sensX = 2.5f;
		float sensY = 2.5f;
	
		rotationX += Input.GetAxis ("Mouse X") * sensX;
		rotationY += Input.GetAxis ("Mouse Y") * sensY;
		rotationY = Mathf.Clamp (rotationY, minY, maxY);
		camera.transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
	}


}
