using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sit_Chair_1 : MonoBehaviour
{

    public BoxCollider2D ChairCollider;
    public int nearchair = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        nearchair = 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        nearchair = 0;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.F)) {
            if (nearchair == 1)
            {
                Debug.Log("sit");
            }
        }
    }
}
