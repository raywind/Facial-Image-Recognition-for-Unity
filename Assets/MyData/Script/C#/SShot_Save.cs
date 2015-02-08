using UnityEngine;
using System.Collections;
using System.IO;

public class SShot_Save : MonoBehaviour {

	string format = "yyyy-MM-dd-HH-mm-ss"; 
	string filePath;
	bool is_file_exsist;
	
	bool GUI_visible;

	void Start () {
		GUI_visible = true;
	}
	
	void Update(){
		if(is_file_exsist==true){
			is_file_exsist=false;
			GUI_visible=true;
			transform.gameObject.GetComponent<Post_Image>().StartPostImage(filePath);
		}
	}

	void OnGUI(){
		GUI.depth = 0;
		if(GUI_visible==true){
			if (GUI.Button (new Rect (0, 0, 100, 50), "Shot")) {
				GUI_visible=false;
				transform.GetComponentInChildren<SShot_Save> ().SShot_SendMessage ();
			}
		}
	}

	
	public void SShot_SendMessage(){

		filePath = Application.dataPath+"/../"+System.DateTime.Now.ToString (format)+".jpg";
		
		this.transform.SendMessage ("SShotJS",filePath);
		StartCoroutine (SSfileExsist (filePath));
	}

	//ファイルの保存完了を待つ
	IEnumerator  SSfileExsist(string _filePath){
		while (!File.Exists (_filePath))
		{
			// File.Existsがtrueになるまで待機
			yield return new WaitForEndOfFrame();
		}
		is_file_exsist = true;
	}
}
