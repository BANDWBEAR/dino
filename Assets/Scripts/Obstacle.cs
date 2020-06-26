using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    public GameObject effect;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggered");
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().takeDamage(1);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}