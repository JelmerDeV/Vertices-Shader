using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject : MonoBehaviour {
	private float rotateSpeed;
	private float seconds;
	private Renderer rend;
	// Use this for initialization
	void Start () {
		seconds = 10f;
		//rotateSpeed = 10;
		rend = gameObject.GetComponent<Renderer>();

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0.3f,1.5f,0.3f);

	}


	IEnumerator vanish(){
		//gameObject.SetActive (false);
		rend.enabled = false;
		yield return new WaitForSeconds (seconds);
		Debug.Log ("lala");
		//gameObject.SetActive (true);
		rend.enabled = true;
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Player") ){

			Debug.Log ("test");
			StartCoroutine(vanish());
		}
	}
		
}
