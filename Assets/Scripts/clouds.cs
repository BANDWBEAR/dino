using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clouds : MonoBehaviour
{
    public float speed;
    public float Xend;
    public float Xstart;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < Xend)
        {
            float randomScale = Random.Range(1.0f, 2.0f);
            float randomPosition = Random.Range(1.0f, 4.0f);

            Vector3 pos = new Vector3(Xstart, randomPosition, 1);
            transform.position = pos;
            transform.localScale = new Vector3(randomScale, randomScale,1);

        }
    }
}
