using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    public Item item;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;

    public Image itemArtwork;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateItem()
    {
        itemName.text = item.name;
        itemDescription.text = item.description;
        
        itemArtwork.sprite = item.artwork;
    }
}
