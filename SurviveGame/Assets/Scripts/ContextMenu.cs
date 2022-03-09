using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenu : MonoBehaviour
{
	private Canvas canvas;


	void Start()
	{
		canvas = GetComponent<Canvas>(); //Получение компонента Canvas
		canvas.enabled = false; //Отключение инвентаря при старте
	}


	public void UpdateUI()
	{
		//if (Input.GetKeyDown(KeyCode.E))
		//{
			canvas.enabled = !canvas.enabled; //При нажатии на кнопку I окно будет отображаться или скрываться
		//}
	}
}
