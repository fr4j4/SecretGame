using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	private string id="";
	private string name = "";
	private double weight=0.0;
	private int slotWidth=1,slotHeight=1;
	private double durability = 100.0;

	//setters
	void setId(string id){
		this.id = id;
	}
	void setName(string name){
		this.name = name;
	}
	void setWeight(double w){
		this.weight = w;
	}
	void setSlotSize (int w,int h){
		slotWidth = w;
		slotHeight = h;
	}

	//getters
	string getId(){
		return id;
	}
	string getName(){
		return name;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
