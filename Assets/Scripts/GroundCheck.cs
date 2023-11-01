using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        Debug.Log(player.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {

            if (collision.gameObject.CompareTag("Ground"))
            {
                //player.IsGrounded = true;
                
            }
        }

        {

            if (collision.gameObject.CompareTag("DeadZone"))
            {
                //if (player.PlayerType == 0)
                {
                    //player.Death();
                }
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            //player.IsGrounded = false;
            
        }
    }
}

   
    

       
 
    

