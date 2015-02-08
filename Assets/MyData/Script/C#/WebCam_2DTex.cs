using UnityEngine;
using System.Collections;

public class WebCam_2DTex : MonoBehaviour {

	int camWidth_px = 1024;
	int camHeight_px = 768;

	int pivot_x;
	int pivot_y;
	
	WebCamTexture webcamTexture;
	
	void Start () {

		pivot_x = Screen.width / 2;
		pivot_y = Screen.height / 2;


		var devices = WebCamTexture.devices;
		if (devices.Length > 0){
	
			webcamTexture = new WebCamTexture(camWidth_px,camHeight_px);
			webcamTexture.Play();
			
		}else{
			Debug.Log("Webカメラが検出できませんでした");
			return;
		}
	}
	
	void OnGUI(){
		GUI.depth = 1;
		GUI.DrawTexture(new Rect(pivot_x - (camWidth_px/2), pivot_y - (camHeight_px/2),  camWidth_px,camHeight_px), webcamTexture);
	}
	
	//Sceneを変更する場合にカメラを止める
	public void EndCam(){
		webcamTexture.Stop ();
	}
}
