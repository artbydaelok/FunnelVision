using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 1f;
    private Vector2 target;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Stuff is happening");
        if (other.CompareTag("VisionField"))
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
