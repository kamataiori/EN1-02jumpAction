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

    //�ڐG�����u�ԌĂ΂��
    private void OnTriggerEnter(Collider other)
    {
        //�ڐG���������
        DestroySelf();
        //Debug.Log("Enter");
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    //�ڐG���Ă���ԂɌĂ΂��
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }

    //���ꂽ�Ƃ��ɌĂ΂��
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }
}
