using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRequestsFactory : MonoBehaviour {

    public static ItemRequestsFactory Instance = null;  


	public void Awake()
	{
        Instance = this;
	}

	[SerializeField] Sprite iphone;
    [SerializeField] Sprite display;
    [SerializeField] Sprite chasis;
    [SerializeField] Sprite body;
    [SerializeField] Sprite cardboardBox;

    public ItemRequest[] getLevel01()
    {
        Sprite[] materials = { display, chasis, body, cardboardBox };
        ItemRequest[] items = new ItemRequest[5];


        for (int i = 0; i < 5; i++)
        {
            ItemRequest item = new ItemRequest(iphone, "iPhone" + i, i + 25, materials);
            items[i] = item;
        }

        return items;
    }

}
