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
        
    }
    //衝突している間に呼ばれる
    private void OnCollisionStay(Collision collision)
    {
        
    }

    //離れたときに呼ばれる
}
