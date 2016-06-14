using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour {
	public GameObject mapGameObjects;
	public Text info_text;
	private XmlDocument xmlDoc;
	private string mapsPath;
	private string mapName="";
	private string mapAuthor="";
	private string mapDescription="";
	private string numBloques = "";
	private string mapFileName ="E1M2.xml";

	IDictionary<string,Material> materials=new Dictionary<string,Material>();

	void awake(){
		
	}

	// Use this for initialization
	void Start (){
		loadStandardTextures ();
		mapsPath =Application.dataPath + "/Maps/";
		loadXml (mapsPath + mapFileName);//E1M1.XML
		generateMap();
		info_text.text = "Map Name: "+mapName+"\nMap Author: "+mapAuthor+"\nDesc:"+mapDescription+"\nBloques:"+numBloques;

	}
	
	// Update is called once per frame
	void Update (){
	
	}
	private void loadXml(string filePath){
		xmlDoc = new XmlDocument ();
		if(System.IO.File.Exists(filePath)){
			xmlDoc.LoadXml(System.IO.File.ReadAllText(filePath));
			Debug.Log ("Mapa cargado");
		}else{
			Debug.Log ("No se pudo abrir el archivo XML");
		}
	}
	private void generateMap(){
		//suponiendo que se cargó el xml correctamente se generará el mapa
		XmlNode root_node=xmlDoc.SelectSingleNode("root");
		XmlNode info_node = root_node.SelectSingleNode ("info");
		XmlNode map_node = root_node.SelectSingleNode ("map");
		XmlNodeList block_nodes = map_node.SelectNodes ("block");
		//XmlNode players_node = root_node.SelectSingleNode ("players");
		//XmlNode customTextures_node = root_node.SelectSingleNode ("customTextures");
		//XmlNode map_node=root_node.SelectSingleNode ("map");
		//XmlNode objects_node=root_node.SelectSingleNode ("objects");

		mapAuthor = info_node.Attributes.GetNamedItem ("author").InnerText;
		mapName = info_node.Attributes.GetNamedItem ("name").InnerText;
		mapDescription= info_node.Attributes.GetNamedItem ("description").InnerText;

		//poniendo cubos en el mapa (después buscare alguna forma optima de hacer esto)
		numBloques = block_nodes.Count.ToString();
		foreach(XmlNode bloque in block_nodes){
			string type=bloque.Attributes.GetNamedItem ("type").InnerText.ToLower();
			string mat=bloque.Attributes.GetNamedItem ("material").InnerText.ToLower();
			float px = float.Parse(bloque.Attributes.GetNamedItem("x").InnerText);
			float py = float.Parse(bloque.Attributes.GetNamedItem("z").InnerText);
			float pz = float.Parse(bloque.Attributes.GetNamedItem("y").InnerText);
			GameObject go=null;
			if(type.ToLower()=="wall"){
				go=GameObject.CreatePrimitive(PrimitiveType.Cube);
				py=py+(go.transform.localScale.y/2);
			}
			else if(type.ToLower()=="floor"){
				go=GameObject.CreatePrimitive(PrimitiveType.Quad);
				go.transform.rotation=Quaternion.Euler(90,0,0);
			}
			if(go!=null){
				go.transform.SetParent (mapGameObjects.transform);
				go.isStatic = true;
				if(mat.ToLower()=="brick"){
					go.GetComponent<Renderer> ().material = materials["brick"];
				}else if(mat.ToLower()=="ground"){
					go.GetComponent<Renderer> ().material = materials["ground"];
				}else if(mat.ToLower()=="wood"){
					Material testMaterial = Resources.Load("materials/wood",typeof(Material)) as Material;
					go.GetComponent<Renderer> ().material = materials["wood"];// wood;
				}
				//materiales exclusivos;
				if (type == "floor") {
					if(mat=="wood"){
						go.GetComponent<Renderer> ().material = materials["floor_wood"];// wood;
					}
				}
				else if(type=="wall"){
					
				}
				go.transform.position = new Vector3 (px,py,pz);
			}
		}
	}

	void loadStandardTextures(){
		materials.Add (new KeyValuePair<string,Material>("wood",Resources.Load("materials/wood",typeof(Material)) as Material));

		materials.Add (new KeyValuePair<string,Material>("ground",Resources.Load("materials/ground",typeof(Material)) as Material));
		materials.Add (new KeyValuePair<string,Material>("brick",Resources.Load("materials/brick",typeof(Material)) as Material));


		materials.Add (new KeyValuePair<string,Material>("floor_wood",Resources.Load("materials/exclusive_floor/wood",typeof(Material)) as Material));
	}
}
