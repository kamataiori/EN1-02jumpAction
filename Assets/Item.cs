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

    //接触した瞬間呼ばれる
    private void OnTriggerEnter(Collider other)
    {
        //接触したら消滅
        DestroySelf();
        //Debug.Log("Enter");
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    //接触している間に呼ばれる
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }

    //離れたときに呼ばれる
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }
}
