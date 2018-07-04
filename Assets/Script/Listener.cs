using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Listener : MonoBehaviour
{

	// Use this for initialization
	Slider slider;
	[SerializeField] private Button buttonAdd;
	[SerializeField] private Button buttonReduce;

	public delegate void TheSliderListener (int change);

	public void setListener(TheSliderListener li){
		if (thelistener == null) {
			thelistener = li;
		} else {
			thelistener += li;
		}
	}

	private TheSliderListener thelistener;

	void Start ()
	{
 		slider = GetComponent<Slider> ();
		slider.maxValue = 5;
		slider.minValue = 0;
		slider.value = 3;
		buttonAdd.onClick.AddListener (() => {
			 	thelistener(1);
		}
		);
		buttonReduce.onClick.AddListener (() => {
			 thelistener(-1);
		}
		);
		name="MYMonoBehaviour";
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
