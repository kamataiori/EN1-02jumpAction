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
    private int jumpCount = 2; // 最大ジャンプ回数
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clicPosition = Input.mousePosition;
        }
        if(isCanJump && Input.GetMouseButtonUp(0))
        {
            //クリックした座標と離した座標の差分を取得
            Vector3 dist = clicPosition - Input.mousePosition;
            //クリックとリリースが同じ座標ならば無視
            if(dist.sqrMagnitude == 0)
            {
                return;
            }
            //差分を標準化し、jumpPowerをかけ合わせた値を移動量とする
            rb.velocity = dist.normalized * jumpPower;
        }
    }

    //衝突した瞬間呼ばれる
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("衝突した");
        isCanJump = true;
    }
    //衝突している間に呼ばれる
    private void OnCollisionStay(Collision collision)
    {
        //衝突している点の情報が複数格納されている
        ContactPoint[] contacts = collision.contacts;
        //0番目の衝突情報から、衝突している点の法線を取得
        Vector3 otherNormal = contacts[0].normal;
        //上方向を示すベクトル。長さは1
        Vector3 upVector = new Vector3(0, 1, 0);
        //上方向と法線の内積。二つのベクトルはともに長さが1なので、cosθの結果がdotUN変数の入る
        float dotUN = Vector3.Dot(upVector, otherNormal);
        //内積値に逆三角関数arccosをかけて角度を算出。それを度数法へ変換する。これで角度が算出できた
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        //二つのベクトルがなす角度が45度より小さければ再びジャンプ可能とする
        if(dotDeg <= 45)
        {
            isCanJump = true;
        }
       
    }

    //離れたときに呼ばれる
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("離脱した");
        isCanJump = false;
        isCanJump = true;
    }
}
