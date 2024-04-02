using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>(); // Lấy biên của ảnh
        Vector3 temScale = transform.localScale; // lấy chiều doãn hiện tại Scale x y 
        float height = sr.bounds.size.y; //Lấy biên của hình của mình gán chiều dài
        float width = sr.bounds.size.x; 
        float WoldHeight = Camera.main.orthographicSize * 2f;
        float WoldWidth = WoldHeight * Screen.width / Screen.height; // chiều rộng vs chiều dài

        temScale.y = WoldHeight / height;
        temScale.x = WoldWidth / width;
        transform.localScale = temScale;



    }






}     
