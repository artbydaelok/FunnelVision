using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindSpot : UseItem
{
    private GameObject player;
    private GameObject bfov;
    public override void Use()
    {
        player = GameObject.Find("Player");
        bfov = player.transform.Find("backfov").gameObject;
        bfov.SetActive(true);
        StartCoroutine(Remove());

    }
    IEnumerator Remove()
    {
        yield return new WaitForSeconds(5);
        bfov.SetActive(false);
        Destroy(gameObject);
    }
}
