using UnityEngine;
using System.Collections;

public class PixelPerfectCamera : MonoBehaviour {

	public static float pixelToUnits = 1f;
	public static float scale = 1f;

	private Vector2 designResolution = new Vector2(90f, 160f);

	void Start() {
		Camera camera = GetComponent<Camera>();

		if (camera.orthographic) {
			print(Screen.height);
			scale = Screen.height / designResolution.y;
			pixelToUnits = scale;
			camera.orthographicSize = (Screen.height / 2) / pixelToUnits;
		}
	}
}
