using System.Collections.Generic;
public class roleTemplateContainer
{
	public class roleTemplate
	{
		public string id;
		public string name;
		public int hp;
		public float speed;
		public int def;
		public int atk;
		public float critical;
		public float dodge;
		public string res_path;
	}


	private Dictionary<string,roleTemplate> tplData = new Dictionary<string,roleTemplate>()
	{
		{"10001",new roleTemplate{id="10001",name="傻逼",hp=4,speed=4,def=0,atk=0,critical=0,dodge=0,res_path="prefabs/role"}},
		{"10002",new roleTemplate{id="10002",name="傻逼",hp=4,speed=4,def=0,atk=0,critical=0,dodge=0,res_path="prefabs/role"}},
		{"10003",new roleTemplate{id="10003",name="傻逼",hp=4,speed=4,def=0,atk=0,critical=0,dodge=0,res_path="prefabs/role"}},
		{"10004",new roleTemplate{id="10004",name="傻逼",hp=4,speed=4,def=0,atk=0,critical=0,dodge=0,res_path="prefabs/role"}},
		{"10005",new roleTemplate{id="10005",name="傻逼",hp=4,speed=4,def=0,atk=0,critical=0,dodge=0,res_path="prefabs/role"}},
		{"10006",new roleTemplate{id="10006",name="傻逼",hp=4,speed=4,def=0,atk=0,critical=0,dodge=0,res_path="prefabs/role"}},
		{"10007",new roleTemplate{id="10007",name="傻逼",hp=4,speed=4,def=0,atk=0,critical=0,dodge=0,res_path="prefabs/role"}},
		{"10008",new roleTemplate{id="10008",name="傻逼",hp=4,speed=4,def=0,atk=0,critical=0,dodge=0,res_path="prefabs/role"}},
		{"10009",new roleTemplate{id="10009",name="傻逼",hp=4,speed=4,def=0,atk=0,critical=0,dodge=0,res_path="prefabs/role"}},
		{"10010",new roleTemplate{id="10010",name="傻逼",hp=4,speed=4,def=0,atk=0,critical=0,dodge=0,res_path="prefabs/role"}}

	};
	public Dictionary<string,roleTemplate> TplData 
	{
		get{return tplData;}
	}
}
