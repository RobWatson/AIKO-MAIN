using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
	private List<Tile> path;
	private int curr = 0;

    //counting the number of trigger colliders that the player has passed through in order to get the number of moves they have made/remain.
   // public int NumberOfMoves;
    //public int MovesLeft;
    public void SetPath(List<Tile> p)
	{
		curr = 0;
		path = p;

        
    }

    public void Start()
    {
        //MovesLeft = NumberOfMoves+1;
    }
	public void Update()
	{
		if(path == null || path.Count == 0 || curr > path.Count -1)
			return;

		Vector3 toTarget = path[curr].gameObject.transform.position - this.transform.position;
		Quaternion rot = Quaternion.LookRotation(new Vector3(toTarget.x, 0, toTarget.z));
		transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 10.0f);

		transform.Translate(Vector3.forward * Time.deltaTime * 1.5f);

		Vector3 target = path[curr].gameObject.transform.position;
		if(Vector3.Distance(transform.position, new Vector3(target.x, transform.position.y, target.z)) < 0.1f)
		{
			curr++;
		}

	}

    //void MoveCountDown()
    //{
    //    MovesLeft--;
   // }

    //void OnTriggerEnter(Collider other)
   // {
       // if (other.tag == "Tile")
        //{
        //    MoveCountDown();
        //    Debug.Log("-1");
       // }
   // }

}
