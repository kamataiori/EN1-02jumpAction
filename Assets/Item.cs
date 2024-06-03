using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ÚG‚µ‚½uŠÔŒÄ‚Î‚ê‚é
    private void OnTriggerEnter(Collider other)
    {
        //ÚG‚µ‚½‚çÁ–Å
        DestroySelf();
        //Debug.Log("Enter");
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    //ÚG‚µ‚Ä‚¢‚éŠÔ‚ÉŒÄ‚Î‚ê‚é
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }

    //—£‚ê‚½‚Æ‚«‚ÉŒÄ‚Î‚ê‚é
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }
}
