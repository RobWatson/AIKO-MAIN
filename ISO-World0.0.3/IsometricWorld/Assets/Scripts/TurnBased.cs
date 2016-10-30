using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class TurnBased : MonoBehaviour
{
    //counting the number of trigger colliders that the player has passed through in order to get the number of moves they have made/remain.
    public int NumberOfMoves;
    public int MovesLeft;
    public int EnemyMoves;
    public GameObject Player;

    public bool PlayerCanMove;

    //public string[] ButtonName;
    //public Texture tex;
    public enum GameStates
    {
        //Start,
        PlayerTurn,
        EndTurn,
        EnemyTurn

    }

    public GameStates currentState;
    
    // Use this for initialization
    void Start()
    {
        
        currentState = GameStates.PlayerTurn;
        MovesLeft = NumberOfMoves + 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            //case (GameStates.Start):
                //put start code here ie.set/reset number of moves left etc, choose who goes first etc
                //MovesLeft = NumberOfMoves + 1;
                //break;

            case (GameStates.PlayerTurn):

                PlayerCanMove = true;
                //allow the player to move and once run out of turns, stop them from moving then prompt them to press end turn
                if (PlayerCanMove == true)
                {
                    Player.GetComponent<PlayerController>().enabled = true;
                }
                //lock their transform. use bools for able to move. when they click end turn goes straight to enemy turn. count how many moves enemy has left
                // when eney runs out of moves goes back to player turn. unlock their transform and resets moves left.

                if (MovesLeft <= 0)
                {
                    Debug.Log("Out of Moves");
                    currentState = GameStates.EndTurn;
                    PlayerCanMove = false;
                    //when the player runs out of moves then the movement script for it is disabled. probably better way of doing this but will do for now
                    Player.GetComponent<PlayerController>().enabled = false;
                }

                break;

            case (GameStates.EndTurn):
                //when the player has run out of turn goes to end turn then staight to enemy turn 

                
                break;

            case (GameStates.EnemyTurn):
                //put enemy Ai code in here. or reference the enemy Ai Script
                //currentState = GameStates.PlayerTurn;
                if (EnemyMoves <= 0)
                {
                    currentState = GameStates.PlayerTurn;
                    MovesLeft = NumberOfMoves + 1;
                }
                break;
        }
    }

    void OnGUI()
    {
        if (GUILayout.Button("Next Turn"))
        {
            if (currentState == GameStates.PlayerTurn)
            {
                currentState = GameStates.EndTurn;
            }
            else if (currentState == GameStates.EndTurn)
            {
                currentState = GameStates.EnemyTurn;
            }
            else if (currentState == GameStates.EnemyTurn)
            {
                currentState = GameStates.PlayerTurn;
            }
        }
    }
    
    void MoveCountDown()
    {
        MovesLeft--;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tile")
        {
            MoveCountDown();
            Debug.Log("-1");
        }
    }

    void EndTurn()
    {
        if (MovesLeft == 0)
        {

        }
    }

    void ResetMovesLeft()
    {
        MovesLeft = NumberOfMoves + 1;
    }

    
}
