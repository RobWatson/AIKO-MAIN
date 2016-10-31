#pragma strict

var player: Transform;
var showOnDistance: float = 2;
private var textMesh: MeshRenderer;


function Start ()
{
  textMesh = gameObject.GetComponent(MeshRenderer);
}


function Update ()
{

  if (Vector3.Distance(transform.position, player.position) < showOnDistance)
    textMesh.enabled = true;
    else
     textMesh.enabled = false;

}

