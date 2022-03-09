using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TheBoxCanvas : MonoBehaviour
{
	// Start is called before the first frame update
	private Canvas canvas;
	private BoxOpen _b;

	void Start()
	{
		canvas = GetComponent<Canvas>(); //Получение компонента Canvas
		canvas.enabled = false; //Отключение инвентаря при старте
	}

	
	public void UpdateUI(BoxOpen B)
	{
		_b = B;
		if(Input.GetKeyDown(KeyCode.E))
		{
			canvas.enabled = !canvas.enabled; //При нажатии на кнопку I окно будет отображаться или скрываться
		}
		if (B.GetTrigger())
			canvas.enabled = false;
	}
}
