using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingController : MonoBehaviour
{
    public GameObject ceiling;
    public List<GameObject> objects = new List<GameObject>();
    public Vector3 startPos;
    public float s = 5f;

    void Start()
    {
        startPos = transform.position;
        InvokeRepeating("choose", 0.01f, 0.4f);
    }


    void tileS(GameObject t)
    {
        GameObject game = Instantiate(t, startPos, Quaternion.Euler(180, 0, 0));
        Destroy(game, 4);
        startPos.z += 5.5f;
    }
    void choose()
    {
        GameObject g = objects[Random.Range(0, objects.Count)];
        tileS(g);
    }
    void FixedUpdate()
    {
        float ceilingSpeed = FindObjectOfType<PlayerController>().moveSpeed * 0.002f;
        transform.Translate(Vector3.back * ceilingSpeed * Time.fixedDeltaTime);
    }

}