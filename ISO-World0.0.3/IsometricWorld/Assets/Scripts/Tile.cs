using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour 
{
	public Vector2 gridPos = new Vector2();

	public float f = 0;
	public float g = 0;
	public float h = 0;
	public Tile parentNode;
	public GameObject go;
	public List<Tile> adjacentNodes = new List<Tile>();
	public List<Tile> connectedNodes = new List<Tile>();


}
