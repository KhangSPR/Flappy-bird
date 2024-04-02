using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCtrl : MonoBehaviour
{
    public static BirdCtrl intance; // Liên kết
    public float bounceForce;  //Lực nảy lên
    private Rigidbody2D mybody; //Lực 
    private Animator anim; // Animation khi die
    [SerializeField] //Hàm đổi private thành công khai
    private AudioSource audioSource;
    [SerializeField] //Hàm đổi private thành công khai
    private AudioClip flyclip, hitclip, diedclip;
    private bool islivingflap;
    private bool didflap;
    public int score = 0;
    public float flag = 0;
    public GameObject spawner;
    private void Awake()
    {
        islivingflap = true;
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        BirdCtrl.intance = this;
        this.spawner = GameObject.Find("Spawn Pipe"); // Tìm
    }
    void FixedUpdate()
    {
        BirdMovement();
    }
    void BirdMovement() // Hàm sự chuyển động
    {
        if (islivingflap)
        {
            if (didflap)
            {
                didflap = false;
                mybody.velocity = new Vector2(mybody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyclip);
            }
        }
        if (mybody.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, mybody.velocity.y / 7); //Trục z xoay
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else if (mybody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (mybody.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -mybody.velocity.y / 7); //Trục z xoay
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }

    }
    public void flapbutton()
    {
        didflap = true;
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PipeHolder")
        {
            score++;
            audioSource.PlayOneShot(hitclip);
            GamePlayCtrl.instance.setScore(score);
            
        }
 
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground" || target.gameObject.tag == "Pipe")
        {
            flag = 1;
            if (islivingflap)
            {
                islivingflap = false;
                Destroy(spawner);
                audioSource.PlayOneShot(diedclip);
                anim.SetTrigger("Die_FlappyBird");
                GamePlayCtrl.instance.birdDieShowPanel(score);
            }

        }
    }

}
