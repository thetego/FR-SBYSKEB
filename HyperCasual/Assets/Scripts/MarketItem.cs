using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketItem : MonoBehaviour
{
	public Image icon;
	public Text price;
	public int priceInt, index;

	private void Awake()
	{
		icon = transform.GetChild(0).GetComponent<Image>();
		price = transform.GetChild(1).GetComponent<Text>();
	}
	public void Buy()
	{
		
	}
}
