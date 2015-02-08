using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class SShotManager : MonoBehaviour {

	Dictionary<string,string> dic_result;

	//Start
	void Start () {
		dic_result = new Dictionary<string,string>();
	}

	//最終的にXMLの解析結果がDictionaryに格納される
	public void setResult(Dictionary<string,string> _dic_result){
		dic_result = _dic_result;
		// 抽出後にまとめた辞書データに格納されているキーと値のペアを列挙
		foreach (KeyValuePair<string, string> pair in (Dictionary<string,string>)_dic_result)
		{
			Debug.Log( pair.Key + " : " + pair.Value);
		}
	}
}
