using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public Vector3 pos;
	Material mat;
	// Use this for initialization
	void Start () {
		pos=new Vector3(0,0,0);
	}

	// Update is called once per frame
	void Update () {

	}

	void setPos(int x,int y, int z){
		pos = new Vector3 (x,y,z);
	}	
}
