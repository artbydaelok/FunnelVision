using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dilate : UseItem
{
    private GameObject fov;

    public override void Use()
    {
        fov = GameObject.Find("fieldofview");
        fov.transform.localScale *= new Vector2(1f, 2f);
        StartCoroutine(Remove());

        Debug.Log("Focus");
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(5);
        fov.transform.localScale *= new Vector2(1f, 0.5f);
        Destroy(gameObject);
    }
}
