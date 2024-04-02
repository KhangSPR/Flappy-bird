using System.Collections;
using UnityEngine;

public class spawnTope : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;

    private void Start()
    {
        StartCoroutine(Spawn());
        

    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.2f);
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(-2.1f, 2.1f);
        Instantiate(pipeHolder, temp, Quaternion.identity); //Tạo auto spawn Pipe
        StartCoroutine(Spawn());

    }
}