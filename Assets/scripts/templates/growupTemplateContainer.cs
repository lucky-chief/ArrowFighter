using System.Collections.Generic;
public class growupTemplateContainer
{
	public class growupTemplate
	{
		public int level;
		public int exp;
	}


	private Dictionary<int,growupTemplate> tplData = new Dictionary<int,growupTemplate>()
	{
		{1,new growupTemplate{level=1,exp=0}},
		{2,new growupTemplate{level=2,exp=10}},
		{3,new growupTemplate{level=3,exp=20}},
		{4,new growupTemplate{level=4,exp=35}},
		{5,new growupTemplate{level=5,exp=55}},
		{6,new growupTemplate{level=6,exp=80}},
		{7,new growupTemplate{level=7,exp=110}},
		{8,new growupTemplate{level=8,exp=145}},
		{9,new growupTemplate{level=9,exp=185}},
		{10,new growupTemplate{level=10,exp=230}},
		{11,new growupTemplate{level=11,exp=280}},
		{12,new growupTemplate{level=12,exp=335}},
		{13,new growupTemplate{level=13,exp=395}},
		{14,new growupTemplate{level=14,exp=460}},
		{15,new growupTemplate{level=15,exp=530}},
		{16,new growupTemplate{level=16,exp=605}},
		{17,new growupTemplate{level=17,exp=685}},
		{18,new growupTemplate{level=18,exp=770}},
		{19,new growupTemplate{level=19,exp=860}},
		{20,new growupTemplate{level=20,exp=955}},
		{21,new growupTemplate{level=21,exp=1055}},
		{22,new growupTemplate{level=22,exp=1160}},
		{23,new growupTemplate{level=23,exp=1270}},
		{24,new growupTemplate{level=24,exp=1385}},
		{25,new growupTemplate{level=25,exp=1505}},
		{26,new growupTemplate{level=26,exp=1630}},
		{27,new growupTemplate{level=27,exp=1760}},
		{28,new growupTemplate{level=28,exp=1895}},
		{29,new growupTemplate{level=29,exp=2035}},
		{30,new growupTemplate{level=30,exp=2180}},
		{31,new growupTemplate{level=31,exp=2330}},
		{32,new growupTemplate{level=32,exp=2485}},
		{33,new growupTemplate{level=33,exp=2645}},
		{34,new growupTemplate{level=34,exp=2810}},
		{35,new growupTemplate{level=35,exp=2980}}

	};
	public Dictionary<int,growupTemplate> TplData 
	{
		get{return tplData;}
	}
}
