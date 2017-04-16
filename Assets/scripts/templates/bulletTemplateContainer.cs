using System.Collections.Generic;
public class bulletTemplateContainer
{
	public class bulletTemplate
	{
		public string id;
		public string name;
		public string path;
	}


	private Dictionary<string,bulletTemplate> tplData = new Dictionary<string,bulletTemplate>()
	{
		{"50001",new bulletTemplate{id="50001",name="普通箭矢",path="prefabs/arrow01"}},
		{"50002",new bulletTemplate{id="50002",name="忍者镖",path="prefabs/arrow01"}},
		{"50003",new bulletTemplate{id="50003",name="激光棒",path="prefabs/arrow01"}},
		{"50004",new bulletTemplate{id="50004",name="手里剑",path="prefabs/arrow01"}},
		{"50005",new bulletTemplate{id="50005",name="铁锤",path="prefabs/arrow01"}},
		{"50006",new bulletTemplate{id="50006",name="哑铃",path="prefabs/arrow01"}},
		{"50007",new bulletTemplate{id="50007",name="火球",path="prefabs/arrow01"}},
		{"50008",new bulletTemplate{id="50008",name="红色针",path="prefabs/arrow01"}}

	};
	public Dictionary<string,bulletTemplate> TplData 
	{
		get{return tplData;}
	}
}
