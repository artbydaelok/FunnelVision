using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private int hp;
    public int maxHp;
    public float interval;
    private float _interval;

    public Transform player;
    public float moveSpeed;
    public float maxSpeed = 0.5f;
    protected bool playerCaught = false;

    private GameObject fov;

    private Rigidbody2D rb;
    private Vector2 movement;

    private bool isSpotted = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();

        fov = GameObject.Find("fieldofview");

        // set both hp and speed to a certain value so that we can reset these values later
        hp = maxHp; 
        moveSpeed = maxSpeed;

        _interval = interval;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        direction.Normalize();
        movement = direction;

        if (hp <= 0) // if hp is at 0, destroy this enemy
        {
            Death();
        }
    }

    private void FixedUpdate()
    {
        if (!playerCaught)
        {
            moveCharacter(movement);
        }
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("VisionField"))
        {
            isSpotted = true;

            StartCoroutine(Spotted());
        } 
        else if (other.CompareTag("Player")) // If the enemy hits the player
        {
            Debug.Log("Player Hit");
            StartCoroutine(PlayerCaught());
            // Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("VisionField"))
        {
            isSpotted = false;
            
        }
    }

    IEnumerator Spotted()
    {
        if (isSpotted) // if the enemy is within the FOV
        {
            if (fov.GetComponent<IsFocused>().currentlyFocused())
            {
                interval *= 0.5f;
                Debug.Log("I am being focused right now");
            }
            else
            {
                interval = _interval;
            }

            yield return new WaitForSeconds(interval); // wait 1 second
            hp--; // reduce its health
            StartCoroutine(Spotted()); // repeat this action until hp is at 0
        }
        else
        {
            hp = maxHp;
        }
    }

    protected virtual IEnumerator PlayerCaught()
    {
        playerCaught = true;
        GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void moveCharacter(Vector2 direction)
    {
        if (isSpotted) // if the enemy is spotted, slow down
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0f, 0.02f);
        }
        else // if the enemy is out of sight, set its speed to max speed (regular speed)
        {
            moveSpeed = maxSpeed;
        }

        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
