using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] RectTransform Candy;
    [SerializeField] RectTransform Avatar;

    Rigidbody2D rb;

    int Force;
    int DelayReset;
    int Direction = 1;

    bool Reset = false;

    private void Awake()
    {
        Force = Random.Range(5, 7);
        rb= Candy.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CandyMove();
        FollowCandy();
    }
    
    void CandyMove()
    {
        if (Reset) return;
        rb.AddForce(new Vector2(Direction,0)*Force*4);
        if (Candy.anchoredPosition.y > -200) return;
        DelayReset = Random.Range(2, 7);
        Reset= true;
        rb.gravityScale = 0;
        StartCoroutine(ResetPos());   
    }
    IEnumerator ResetPos()
    {
        //Reset rotation Candy và velocity
        rb.velocity = Vector2.zero; //Velocity Speed
        Candy.rotation = Quaternion.Euler(0f, 0f, 0f);

        //Tạo lực mới
        Force = Random.Range(2, 7);

        //Tắt xoay Candy
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        //Delay Reset
        yield return new WaitForSeconds(DelayReset);

        //Đổi hướng
        Direction = (Direction == 1) ? -1 : 1;

        //Lật 
        Avatar.localScale = new Vector3(Direction,1,1);

        //Bật lại xoay cho Candy
        rb.constraints &= ~RigidbodyConstraints2D.FreezeRotation;

        //Reset vị trí và gravityScale
        Candy.anchoredPosition = new Vector2(-500 * Direction, 100);
        Avatar.anchoredPosition = new Vector2(-700 * Direction, -30);
        rb.gravityScale = 40;

        Reset = false;
    }
    void FollowCandy()
    {
        Vector2 currentPosition = Avatar.anchoredPosition;
        Vector2 newPos = Vector2.Lerp(Avatar.anchoredPosition, Candy.anchoredPosition,Time.deltaTime); 
        newPos.y = currentPosition.y;
        Avatar.anchoredPosition = newPos;
    }
    void OnEnable()
    {
        // Thực hiện khi được kích hoạt lại
        Candy.anchoredPosition = new Vector2(-500 * Direction, 100);
        Avatar.anchoredPosition = new Vector2(-700 * Direction, -30);        
        rb.gravityScale = 40;      
        Reset = false;
        if (rb.constraints != RigidbodyConstraints2D.FreezeRotation) return;
        rb.constraints &= ~RigidbodyConstraints2D.FreezeRotation;
    }
}
