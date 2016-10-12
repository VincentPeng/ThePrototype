using UnityEngine;
using System.Collections;

public class TiledBackground : MonoBehaviour {

	public int normalScale = 1;
	// Use this for initialization
	void Start() {
		float newWidth = Mathf.Ceil(Screen.width / PixelPerfectCamera.scale);
		float newHeight = Mathf.Ceil(Screen.height / PixelPerfectCamera.scale);
		transform.localScale = new Vector3(newWidth, newHeight, 1);
		GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth / normalScale, newHeight / normalScale, 1);
	}
	
	// Update is called once per frame
	void Update() {
	
	}
}
