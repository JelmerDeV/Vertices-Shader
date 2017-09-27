using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour {
	private Renderer renderer;

	private Transform bodyTransform;
	[SerializeField][Range(-0.002f , 0.003f)]private float Value = 0f;

	private float maxValue;
	private float minValue;

	void Start () {
		Value = 0f;
		maxValue = 0.003f;
		minValue = -0.002f;
		bodyTransform = transform.Find ("body");

		renderer = bodyTransform.gameObject.GetComponent<Renderer>();
		//renderer = gameObject.GetComponent<Renderer>();
		renderer.material.shader = Shader.Find ("Custom/Vertices");
		renderer.material.renderQueue = 3000; // force the renderqueue to transparant setting

		//renderer.material.SetFloat("_Shininess" += 0.01);
	}
	

	void Update () {
		//Debug.Log (Value);
		if (Value < minValue) {
			Value = minValue;
		} else if (Value > maxValue)
			Value = maxValue;

		renderer.material.SetFloat ("_Amount", Value);


	}

	void Grow(){
		Value += 0.001f;
	}

	void Shrink(){
		Value -= 0.001f;
	}

	void OnTriggerEnter(Collider col){
		//print (col.gameObject.tag);

		if(col.gameObject.CompareTag("Fastfood"))
		{
			//Destroy (col.gameObject);

			Grow ();
		}
		if (col.gameObject.CompareTag ("Healthy")) 
		{
			//Destroy (col.gameObject);
			Shrink ();
		}
	}
}
