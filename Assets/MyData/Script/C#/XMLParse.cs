using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Collections.Generic;

public class XMLParse : MonoBehaviour {

	// Use this for initialization
	public void StartParse (string result) {

		//In resulut 
		Dictionary<string,string> dic = new Dictionary<string,string>();;

		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(new StringReader(result));
		
		XmlNodeList detectionList = xmlDoc.GetElementsByTagName("detectionFaceInfo");
		
		foreach (XmlNode faceInfo in detectionList)
		{
			XmlNodeList facecontent = faceInfo.ChildNodes;
			
			foreach (XmlNode faceItens in facecontent)
			{
				//年齢判定結果をDictionaryに追加
				if(faceItens.Name == "ageJudge")
				{
					XmlNodeList ageJudgecontent = faceItens.ChildNodes;
					foreach (XmlNode ageJudgeItens in ageJudgecontent){
						if(ageJudgeItens.Name == "ageResult")
						{
							dic.Add("ageResult",ageJudgeItens.InnerText);
						}
						else if(ageJudgeItens.Name == "ageScore")
						{
							dic.Add("ageScore",ageJudgeItens.InnerText);
						}
					}
				}
				//性別判定結果をDictionaryに追加
				else if(faceItens.Name == "genderJudge")
				{
					XmlNodeList genderJudgecontent = faceItens.ChildNodes;
					foreach (XmlNode genderJudgeItens in genderJudgecontent){
						if(genderJudgeItens.Name == "genderResult")
						{
							dic.Add("genderResult",genderJudgeItens.InnerText);
						}
						else if(genderJudgeItens.Name == "genderScore")
						{
							dic.Add("genderScore",genderJudgeItens.InnerText);
						}
					}
				}
				//笑顔判定結果をDictionaryに追加
				else if(faceItens.Name == "smileJudge")
				{
					XmlNodeList smileJudgecontent = faceItens.ChildNodes;
					foreach (XmlNode smileJudgeItens in smileJudgecontent){
						if(smileJudgeItens.Name == "smileLevel")
						{
							dic.Add("smileLevel",smileJudgeItens.InnerText);
						}
					}
				}
				//お楽しみ判定結果をDictionaryに追加
				else if(faceItens.Name == "enjoyJudge")
				{
					XmlNodeList enjoyJudgecontent = faceItens.ChildNodes;
					foreach (XmlNode enjoyJudgeItens in enjoyJudgecontent){
						if(enjoyJudgeItens.Name == "similarAnimal")
						{
							dic.Add("similarAnimal",enjoyJudgeItens.InnerText);
						}
						else if(enjoyJudgeItens.Name == "doyaLevel")
						{
							dic.Add("doyaLevel",enjoyJudgeItens.InnerText);
						}
						else if(enjoyJudgeItens.Name == "troubleLevel")
						{
							dic.Add("troubleLevel",enjoyJudgeItens.InnerText);
						}
					}
				}
			}
		}
		transform.GetComponent<SShotManager> ().setResult (dic);
	}
}
