using UnityEngine;
using System.Collections;

public class TiledBackground : MonoBehaviour {

	public int normalScale = 1;
	public Transform hero;
	private float lastY;

	public float offsetFactor = 1f;
	// Use this for initialization
	void Start() {
		float newWidth = Mathf.Ceil(Screen.width / PixelPerfectCamera.scale);
		float newHeight = Mathf.Ceil(Screen.height / PixelPerfectCamera.scale);
		transform.localScale = new Vector3(newWidth, newHeight, 1);
		GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth / normalScale, newHeight / normalScale, 1);

		lastY = hero.position.y;
	}
	
	// Update is called once per frame
	void Update() {
		Vector2 curOffset = GetComponent<Renderer>().material.mainTextureOffset;
		float deltaY = (hero.position.y - lastY) * offsetFactor;
		lastY = hero.position.y;
		curOffset.y += deltaY;
		GetComponent<Renderer>().material.mainTextureOffset = curOffset;
	}
}
