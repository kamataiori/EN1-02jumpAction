using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private Vector3 clicPosition;
    [SerializeField]
    private float jumpPower = 10.0f;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clicPosition = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            //�N���b�N�������W�Ɨ��������W�̍������擾
            Vector3 dist = clicPosition - Input.mousePosition;
            //�N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
            if(dist.sqrMagnitude == 0)
            {
                return;
            }
            //������W�������AjumpPower���������킹���l���ړ��ʂƂ���
            rb.velocity = dist.normalized * jumpPower;
        }
    }

    //�Փ˂����u�ԌĂ΂��
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    //�Փ˂��Ă���ԂɌĂ΂��
    private void OnCollisionStay(Collision collision)
    {
        
    }

    //���ꂽ�Ƃ��ɌĂ΂��
}
