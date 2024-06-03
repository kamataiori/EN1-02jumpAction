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
    private bool isCanJump;
    private int jumpCount = 2; // �ő�W�����v��
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clicPosition = Input.mousePosition;
        }
        if(isCanJump && Input.GetMouseButtonUp(0))
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
        Debug.Log("�Փ˂���");
        isCanJump = true;
    }
    //�Փ˂��Ă���ԂɌĂ΂��
    private void OnCollisionStay(Collision collision)
    {
        //�Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;
        //0�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@�����擾
        Vector3 otherNormal = contacts[0].normal;
        //������������x�N�g���B������1
        Vector3 upVector = new Vector3(0, 1, 0);
        //������Ɩ@���̓��ρB��̃x�N�g���͂Ƃ��ɒ�����1�Ȃ̂ŁAcos�Ƃ̌��ʂ�dotUN�ϐ��̓���
        float dotUN = Vector3.Dot(upVector, otherNormal);
        //���ϒl�ɋt�O�p�֐�arccos�������Ċp�x���Z�o�B�����x���@�֕ϊ�����B����Ŋp�x���Z�o�ł���
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        //��̃x�N�g�����Ȃ��p�x��45�x��菬������΍ĂуW�����v�\�Ƃ���
        if(dotDeg <= 45)
        {
            isCanJump = true;
        }
       
    }

    //���ꂽ�Ƃ��ɌĂ΂��
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("���E����");
        isCanJump = false;
        isCanJump = true;
    }
}
