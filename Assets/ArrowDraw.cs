using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    private Vector3 clicPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clicPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            arrowImage.enabled = true;
            Vector3 dist = clicPosition - Input.mousePosition;
            //ベクトルの長さを算出
            float size = dist.magnitude;
            //ベクトルから角度を算出
            float angleRad = Mathf.Atan2(dist.y, dist.x);
            //矢印の画像をクリックした場所に画像を移動
            arrowImage.rectTransform.position = clicPosition;
            //矢印の画像をベクトルから算出した角度を度数法に変換してz軸回転
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            //矢印の画像の大きさをドラッグした距離に合わせる
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
        else
        {
            arrowImage.enabled = false;
        }
    }
}
