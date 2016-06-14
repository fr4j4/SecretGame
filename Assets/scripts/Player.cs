using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private string name="";
	private string id = "";
	private double health=0.0;
	private double weight=0.0;
	private int posX=0,posY=0,posZ=0;
	private GameObject player_GO;
	private Camera player_camera;
	private string cameraType = "fps";

	//setters
	void setId(string id){
		this.id = id;
	}
	void setName(string name){
		this.name = name;
	}
	void setHealth(double health){
		this.health = health;
	}
	void setWeight(double w){
		this.weight = w;
	}
	void setCameraType(string ct){
		this.cameraType = ct;
	}
	void setPos(int x,int y, int z){
		this.posX = x;
		this.posY = y;
		this.posZ = z;
	}

	//getters
	string getId(){
		return id;
	}
	string getName(){
		return name;
	}
	double getHealth(){
		return health;
	}
	double getWeight(){
		return weight;
	}
	string getCameraType(){
		return cameraType;
	}
	Vector3 getPos(){
		return new Vector3(posX,posY,posZ);
	}
	GameObject getGameObject(){
		return player_GO;
	}

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}
}
