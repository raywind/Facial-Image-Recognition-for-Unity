using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class Post_Image : MonoBehaviour {

	//パラメータ（今回は年齢性別，笑顔，お楽しみ判定機能のみ実施）
	public string APIKey="475770492f51726d41495437782f314c694b50396246473375374f6757554e2f4d5035454672375a723644";
	public string optionFlgMinFaceWidth="1";
	public string facePartsCoordinates="0";
	public string blinkJudge="0";
	public string ageAndgenderJudge="1";
	public string angleJudge="0";
	public string smileJudge="1";
	public string enjoyJudge="1";
	public string response ="xml";
	

	public void StartPostImage(string filePath){

		StartCoroutine ("PostNetwork", filePath);

	}
	
	IEnumerator PostNetwork(string filePath) {

		string url = "https://api.apigw.smt.docomo.ne.jp/puxImageRecognition/v1/faceDetection"+
					 "?APIKEY="                +APIKey+
					 "&optionFlgMinFaceWidth=" +optionFlgMinFaceWidth+
					 "&facePartsCoordinates="  +facePartsCoordinates+
					 "&blinkJudge="            +blinkJudge+
					 "&ageAndgenderJudge="     +ageAndgenderJudge+
					 "&angleJudge="            +angleJudge+
					 "&enjoyJudge="            +enjoyJudge+
					 "&response="              +response;
		
		byte[] bytes = System.IO.File.ReadAllBytes(filePath);
		//byte[] bytes = System.IO.File.ReadAllBytes(Application.dataPath+"/../m030011.jpg");

		Dictionary<string,string> has = new Dictionary<string,string>();
		has.Add("Content-Type", "application/octet-stream");

		WWW www = new WWW(url,bytes,has);
		yield return www;
		
		if (www.error==null) {
			// 成功処理
			File.Delete(filePath);
			Debug.Log(www.text);
			transform.gameObject.GetComponent<XMLParse>().StartParse(www.text);	
		}
		else {
			// エラー処理
			File.Delete(filePath);
		}
		www.Dispose();
	}
}
