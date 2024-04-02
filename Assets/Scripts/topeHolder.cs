using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class topeHolder : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        topeMovement();
        stopSpawn();
    }
    void stopSpawn()
    {
        if (BirdCtrl.intance.flag == 1)
            Destroy(GetComponent<topeHolder>()); //Destroy scrip
    }
    void topeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Destroy")
            Destroy(gameObject);
    }
}