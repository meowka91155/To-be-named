using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sitting : MonoBehaviour
{
    public float isSitting;
    public int Chairentry;
    public BoxCollider2D co;
    Collider2D m_Collider;
    
    // Start is called before the first frame update


    void Start()
    {
        //Fetch the GameObject's Collider (make sure it has a Collider component)
        m_Collider = GetComponent<Collider2D>();


        /// is the player sitting or not?
        isSitting = 0;
        ///the direction that the player got on the chair
        ///0 = off chair
        ///1 = got on the left side of the chair
        ///2 = got on the right side of the chair
        ///3 = got on the top of the chair
        ///4 = got on the bottom of the chair
        Chairentry = 0;

    }

    void Update()
    {

        
        if (isSitting == 1)
        {
            co.isTrigger = true;
            
            
        }
        if (co.isTrigger == true)
        {
            if (Input.GetKeyDown("f"))
            {
                isSitting = 0;
             co.isTrigger = false;
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);


        
        
        switch (collision.gameObject.tag)
        {
            ///goes through which direction the chair is facing
            ///and what direction the character hits the chair
            case "ChairRight":
                ///The chair is facing right
                ///

                //you hit the chair on the left
                Debug.Log(gameObject.transform.position);
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    Debug.Log("you hit the chair on the left");

                    
                    
                    isSitting = 1;
                    Chairentry = 1;
                    transform.Translate(Vector2.right * 1/2);

                   
                    
                    
                }
                else
                {
                    //you hit the chair on the right
                    if (Input.GetAxisRaw("Horizontal") < 0)
                    {
                        Debug.Log("you hit the chair on the right");

                        isSitting = 1;
                        Chairentry = 1;
                        transform.Translate(Vector2.left * 1 / 2);
                    }
                }
                ///vertical chair hitting
                ///

                //hitting the chair on the bottom
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    Debug.Log("you hit the chair on the bottom");

                    isSitting = 1;
                    Chairentry = 1;
                    transform.Translate(Vector2.up * 1);
                }
                else
                {
                    //Hitting the chair on the top
                    if (Input.GetAxisRaw("Vertical") < 0)
                    {
                        Debug.Log("you hit the chair on the top ");

                        isSitting = 1;
                        Chairentry = 1;
                        transform.Translate(Vector2.down * 1 / 2);
                    }
                }
                break;

            case "ChairLeft":
                ///The chair is facing right
                ///

                //you hit the chair on the left
                Debug.Log(gameObject.transform.position);
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    Debug.Log("you hit the chair on the left");

                    isSitting = 1;
                    Chairentry = 1;
                    transform.Translate(Vector2.right * 1 / 2);

                }
                else
                {
                    //you hit the chair on the right
                    if (Input.GetAxisRaw("Horizontal") < 0)
                    {
                        Debug.Log("you hit the chair on the right");

                        isSitting = 1;
                        Chairentry = 1;
                        transform.Translate(Vector2.left * 1 / 2);
                    }
                }
                ///vertical chair hitting
                ///

                //hitting the chair on the bottom
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    Debug.Log("you hit the chair on the bottom");

                    isSitting = 1;
                    Chairentry = 1;
                    transform.Translate(Vector2.up * 1);
                }
                else
                {
                    //Hitting the chair on the top
                    if (Input.GetAxisRaw("Vertical") < 0)
                    {
                        Debug.Log("you hit the chair on the top ");

                        isSitting = 1;
                        Chairentry = 1;
                        transform.Translate(Vector2.down * 1 / 2);
                    }
                }
                break;




            case "Another thing witht hte same thing":
                //var b = "C";




                break;



            default:

                //var allelsefails = "this";

                break;
        }
        if (collision.gameObject.tag == ("ChairRight"))
        {

        }
    }





    

    // Update is called once per frame
    
}
