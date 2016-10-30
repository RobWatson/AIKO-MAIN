using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStarPathfinder : MonoBehaviour 
{
	public GridMaker grid;
	public List<Tile> tiles;
	public Tile start;
	public Tile end;

	public List<Tile> openList = new List<Tile>();
	public List<Tile> closeList = new List<Tile>();

	public List<Tile> myPath;

	public void Search()
	{
		Tile node = start;

		if(end == null)
			return;

		while(node != end)
		{
			foreach(Tile test in node.adjacentNodes)
			{
				if(test == node)
					continue;

				Vector3 nodePos = new Vector3(node.transform.position.x, 0, node.transform.position.z);
				Vector3 testPos = new Vector3(test.transform.position.x, 0, test.transform.position.z);
				Vector3 endPos = new Vector3(end.transform.position.x, 0, end.transform.position.z);
				float g = node.g + Vector3.Distance(nodePos, testPos);
				float h = Vector3.Distance(testPos, endPos);
				float f = g + h;

				if(IsOpen(test) || IsClose(test))
				{
					if(test.f > f)
					{
						test.f = f;
						test.g = g;
						test.h = h;
						test.parentNode = node;	
					}
				}
				else
				{
					test.f = f;
					test.g = g;
					test.h = h;
					test.parentNode = node;
					openList.Add(test);
				}
			}
			closeList.Add(node);

			if(openList.Count == 0)
			{
				return;
			}

			for(int i = 0 ; i < openList.Count ; i++)
			{
				for(int j = i + 1 ; j < openList.Count ; j++)
				{
					Tile n1 = openList[i];
					Tile n2 = openList[j];
					if(n1.f > n2.f)
					{
						Tile temp = n2;
						openList[j] = n1;
						openList[i] = temp;
					}
				}
			}

			node = ShiftElement(openList);
		
		}

		BuildPath();
	}

	private Tile ShiftElement(List<Tile> l)
	{
		Tile firstTile = l[0];
		l.RemoveAt(0);
		return firstTile;

	}

	private void BuildPath()
	{
		myPath.Clear();

		List<Tile> pathTotarget = new List<Tile>();

		Tile node = end;

		pathTotarget.Insert(0, node);

		Vector3 endPos = new Vector3(end.transform.position.x, 0, end.transform.position.z);
		Vector3 startPos = new Vector3(start.transform.position.z, 0, start.transform.position.z);
		float distToNode = Vector3.Distance(endPos, startPos);

		while(node != start)
		{
			node = node.parentNode;
			pathTotarget.Insert(0, node);
		}

//		Debug.Log(pathTotarget.Count);
		myPath = pathTotarget;

		pathTotarget = new List<Tile>();
		openList = new List<Tile>();
		closeList = new List<Tile>();
	}

	private bool IsOpen(Tile t)
	{
		foreach(Tile tile in openList)
		{
			if(t == tile)
				return true;
		}
		return false;
	}

	private bool IsClose(Tile t)
	{
		foreach(Tile tile in closeList)
		{
			if(t == tile)
				return true;
		}
		return false;
	}
}
