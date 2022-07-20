using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootingEnemy : Enemy
{
    public GameObject projectile;

    protected override void Death()
    {
        Shoot();
        base.Death();
    }
    private void Shoot()
    {
        Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
    }

    protected override IEnumerator PlayerCaught()
    {
        playerCaught = true;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
