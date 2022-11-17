using System.Collections.Generic;
using System.Xml;
using System.Linq;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;

public class MyUtilities 
{
	#region xml
	public static string[] GetDialogsFromXml(string fileName,string nodeName) 
	{
		XmlDocument xd = new XmlDocument();
		
		TextAsset ta = Resources.Load<TextAsset>("DialogData/XML/"+fileName);
		xd.LoadXml(ta.text);
		Resources.UnloadAsset(ta);
		XmlElement root = xd.DocumentElement;
		XmlNode dialogNode = root.GetElementsByTagName(nodeName)[0];
		XmlNodeList contentList = dialogNode.ChildNodes;
		string[] strs = new string[contentList.Count];
		for (int i = 0; i < strs.Length; i++)
		{
			strs[i] = contentList[i].InnerText;
		}
		return strs;
	}
	#endregion
	#region json
	public static string[] GetDialogsFromJson(string fileName,string nodeName) 
	{
		string json = File.ReadAllText("Assets/Resources/DialogData/Json/" + fileName + ".json",Encoding.UTF8);
		DialogOb dialogOb = JsonMapper.ToObject<DialogOb>(json);	
		var t = dialogOb.root.Where(item => item.dialogName == nodeName);
		return t.FirstOrDefault().dialogContents;
	}
	#endregion

	

}
public class DialogJs
{
	public string dialogName;
	public string[] dialogContents;
}
public class DialogOb
{
	public List<DialogJs> root;
}