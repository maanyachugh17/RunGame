using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject floor;
    public List<GameObject> objects = new List<GameObject>();
    public Vector3 startPos;
    public float s = 5f;

    void Start()
    {
        startPos = transform.position;
        InvokeRepeating("choose", 0.2f, 0.5f);
    //    Destroy(floor, 2);
    }

    // Update is called once per frame
    void Update()
    {
    }

    /*  void tileS(GameObject t)
      {
          GameObject game = Instantiate(t, startPos, Quaternion.Euler(0, 0, 0));
          Destroy(game, 4);
          startPos.z += 5.5f;
      } */
    void tileS(GameObject t)
    {
        Vector3 tilePosition = new Vector3(startPos.x, startPos.y - 0.5f, startPos.z); // adjust the Y position of the tile
        GameObject game = Instantiate(t, tilePosition, Quaternion.Euler(0, 0, 0));
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
        // Set the speed of the floor to 0.8 times the speed of the ball
        float floorSpeed = FindObjectOfType<PlayerController>().moveSpeed*0.002f;
        transform.Translate(Vector3.back * floorSpeed * Time.fixedDeltaTime);
    }

}