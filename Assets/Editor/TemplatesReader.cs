using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections.Generic;

public class TemplatesReader : ScriptableObject
{
    static string csRoot = Application.dataPath + "/scripts/templates/";
    static string csPath = "{0}/scripts/templates/{1}.cs";
    static string cs_using = "using System.Collections.Generic;\n";
    static string cs_variable = "\t\tpublic {0} {1};\n";
    static string cs_class = "{0}public class {1}\n{2}\n";
    static string cs_pub_field = "\tprivate Dictionary<{0},{1}> tplData = new Dictionary<{2},{3}>()\n{4};\n\tpublic Dictionary<{5},{6}> TplData {7}";

    [MenuItem("工具/生产模板表代码")]
    static void DoIt()
    {
        if(Directory.Exists(csRoot))
        {
            Directory.Delete(csRoot,true);
        }
        Directory.CreateDirectory(csRoot);

        string[] paths = Directory.GetFiles(Application.dataPath + "/templates/");
        foreach (string s in paths)
        {
            if (s.IndexOf(".meta") == -1)
            {
                string className = Path.GetFileNameWithoutExtension(s) + "Template";
                int fieldCount = 0;
                TextAsset text = AssetDatabase.LoadAssetAtPath<TextAsset>(s.Substring(s.IndexOf("Assets")));
                string txt = text.text;//.Remove(text.text.LastIndexOf("/r/n") - 1);
                string[] data = txt.Split(new string[] { "\t", "\r\n" }, StringSplitOptions.None);
                if (data.Length % 2 != 0)
                {
                    string[] a = new string[data.Length - 1];
                    for (int i = 0; i < a.Length; i++)
                    {
                        a[i] = data[i];
                    }
                    data = a;
                }
                string[] fields = txt.Substring(0, txt.IndexOf("\r\n")).Split('\t');
                fieldCount = fields.Length;
                string[] fieldsType = new string[fieldCount];
                for (int i = 0; i < fieldCount; i++)
                {
                    fieldsType[i] = data[i + fieldCount];
                }
                string[] dt = new string[data.Length - 2 * fieldCount];
                for (int i = 0; i < data.Length - 2 * fieldCount; i++)
                {
                    dt[i] = data[i + 2 * fieldCount];
                }
                CreateTemplateDataClass(className, fields, fieldsType, dt);
            }
        }
    }

    static void CreateTemplateDataClass(string tplName, string[] fields, string[] fieldsType, string[] data)
    {
        string scripts = "";
        string scripts1 = "";
        string variables = "";
        string dicItemStr = "\t{\n";
        for (int i = 0; i < fields.Length; i++)
        {
            variables += string.Format(cs_variable, fieldsType[i], fields[i]);
        }

        for (int i = 0; i < data.Length; i += fields.Length)
        {
            string s1 = data[i];
            string s = "";
            if (fieldsType[0] == "string")
            {
                s = "\t\t{\"" + s1 + "\"," + "new " + tplName + "{";
            }
            else if (fieldsType[0] == "int")
            {
                s = "\t\t{" + s1 + "," + "new " + tplName + "{";
            }
            for (int j = 0; j < fields.Length; j++)
            {
                if (fieldsType[j] == "string")
                {
                    s += fields[j] + "=" + "\"" + data[i + j] + "\"";
                }
                else
                {
                    s += fields[j] + "=" + data[i + j];
                }
                if (j < fields.Length - 1)
                {
                    s += ",";
                }
            }
            if (i < data.Length - fields.Length)
            {
                s += "}},";
            }
            else
            {
                s += "}}";
            }
            dicItemStr += s + "\n";
        }
        dicItemStr += "\n\t}";

        scripts = string.Format(cs_class, "\t", tplName, "\t{\n" + variables + "\t}\n");
        string pub_fild = string.Format(cs_pub_field, fieldsType[0], tplName, fieldsType[0], tplName, dicItemStr, fieldsType[0], tplName, "\n\t{\n\t\tget{return tplData;}\n\t}");

        scripts1 = string.Format(cs_class, cs_using, tplName + "Container\n{", scripts + "\n" + pub_fild + "\n}");

        string path = string.Format(csPath, Application.dataPath, tplName + "Container");
        StreamWriter sw = File.CreateText(path);
        sw.Close();
        File.WriteAllText(path, scripts1);
        AssetDatabase.Refresh();
    }
}