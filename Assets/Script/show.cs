using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show : MonoBehaviour {

	[SerializeField] private Slider slider;
	// Use this for initialization
	Text text;
	void Start () {
		text = GetComponent <Text>();
		Debug.Log ("slider     "+slider.value+"          ");
		Component[] cs = slider.GetComponents<Component> ();
		Debug.Log ("cs     "+cs.Length+"          ");

		foreach (Component c in cs) {
			Debug.Log ("     "+c.name+"          "+c.GetHashCode()+" "+c.GetInstanceID()+" "+c.GetType().Name);
		}
		Listener listener = slider.GetComponent<Listener> ();
		Debug.Log ("     "+(listener==null));
		listener.setListener (MyListener);
		text.text = slider.value.ToString();

	}

	void MyListener(int change){
		slider.value+= change;
		text.text = slider.value.ToString();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
