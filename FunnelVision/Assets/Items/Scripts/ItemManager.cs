using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Transform[] slotPos;

    public List<Item> itemPool;
    public List<Item> itemSlots;
    public GameObject[] items;

    public List<GameObject> slots;

    public float interval = 10f;

    private void Start()
    {
        items = new GameObject[itemSlots.Count];
        StartCoroutine(ItemCooldown());
    }

    public void GetItem()
    {
        int r = Random.Range(0, itemPool.Count);
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i] == null)
            {
                itemSlots[i] = itemPool[r];

                items[i] = Instantiate(itemSlots[i].prefab, new Vector3(0f,0f,0f), Quaternion.identity);

                slots[i].SetActive(true);
                slots[i].GetComponent<ItemDisplay>().item = itemSlots[i];
                slots[i].GetComponent<ItemDisplay>().updateItem();
                

                Debug.Log("Item Slot: " + (i+1) + " now has " + itemSlots[i].name);
                break;
            }
        } 
    }

    private void ItemSelect()
    {
        if (Input.GetKeyDown("1"))
        {
            items[0].GetComponent<UseItem>().Use();
            itemSlots[0] = null;
            items[0] = null;

            slots[0].SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            items[1].GetComponent<UseItem>().Use();
            itemSlots[1] = null;
            items[1] = null;

            slots[1].SetActive(false);
        }
        if (Input.GetKeyDown("3"))
        {
            items[2].GetComponent<UseItem>().Use(); 
            itemSlots[2] = null;
            items[2] = null;

            slots[2].SetActive(false);
        }
    }

    private void Update()
    {
        ItemSelect();
    }

    IEnumerator ItemCooldown()
    {
        yield return new WaitForSeconds(interval);
        GetItem();
        StartCoroutine(ItemCooldown());
    }
}
