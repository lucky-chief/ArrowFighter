using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;

public class MapDrawerEditor : MonoBehaviour {
    public float size = 0.8f;

    private Vector3 p0;
    private Vector3 p1;
    private Vector3 p2;
    private Vector3 p3;

    public Transform tl;
    public Transform tr;
    public Transform bl;
    public Transform br;

    string mapInfo;
    int mapCol;
    int mapRow;
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(tl.position.x, transform.position.y, tl.position.z);
        float vn = size * 0.5f;
        p0 = new Vector3(vn,0,vn);
        p1 = new Vector3(-vn, 0, vn);
        p2 = new Vector3(-vn, 0, -vn);
        p3 = new Vector3(vn, 0, -vn);

        mapCol = Mathf.FloorToInt((br.position.x - bl.position.x) / size) + 1;
        mapRow = Mathf.FloorToInt((tr.position.z - br.position.z) / size) + 1;

        print("cccc" + mapCol + "cccc" + mapRow);
        //RaycastHit hit0;
        //if (Physics.Raycast(p0.position, -Vector3.up, out hit0, 1000))
        //{
        //    Debug.Log(hit0.collider.gameObject.layer);
        //}
    }
	
	// Update is called once per frame
	void Update () {
        
        Debug.DrawLine(p0 + transform.position, p0 + transform.position - new Vector3(0, 1000, 0), Color.red);
        Debug.DrawLine(p1 + transform.position, p1 + transform.position - new Vector3(0, 1000, 0), Color.red);
        Debug.DrawLine(p2 + transform.position, p2 + transform.position - new Vector3(0, 1000, 0), Color.red);
        Debug.DrawLine(p3 + transform.position, p3 + transform.position - new Vector3(0, 1000, 0), Color.red);
    }

    void OnGUI()
    {
        if(GUILayout.Button("Draw--Map"))
        {
            Draw();
        }
    }

    void Draw()
    {
        Append(mapCol.ToString());
        Append(mapRow.ToString());
        Append(size.ToString());

        for(int i = 0; i < mapCol; i++)
        {
            for(int j = 0; j < mapRow; j++)
            {
                if(RayCheck(i, j))
                {
                    Append("1");
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(i, 0, -j) * size + tl.position;
                    cube.transform.localScale = Vector3.one * size;
                }
                else
                {
                    Append("0");
                }
            }
        }
        SaveToFile();
    }

    void SaveToFile()
    {
        print("dddddddddddd" + count);
        mapInfo = mapInfo.Substring(0, mapInfo.Length - 1);
        File.WriteAllText(Application.dataPath + "/Resources/Config/MapData.txt",mapInfo,Encoding.UTF8); 
    }

    bool RayCheck(int col,int row)
    {
        int hitCount = 0; 
        transform.position = new Vector3(col,0,-row) * size + new Vector3(tl.position.x, transform.position.y, tl.position.z);
        if (Physics.Raycast(p0 + transform.position, -Vector3.up,1000,1 << LayerMask.NameToLayer("Wall")))
        {
            hitCount++;
        }
        if (Physics.Raycast(p1 + transform.position, -Vector3.up, 1000, 1 << LayerMask.NameToLayer("Wall")))
        {
            hitCount++;
        }
        if (Physics.Raycast(p2 + transform.position, -Vector3.up, 1000, 1 << LayerMask.NameToLayer("Wall")))
        {
            hitCount++;
        }
        if (Physics.Raycast(p3 + transform.position, -Vector3.up, 1000, 1 << LayerMask.NameToLayer("Wall")))
        {
            hitCount++;
        }
        return hitCount < 1;
    }
    int count = 0;
    void Append(string info)
    {
        count++;
        mapInfo += info + "|";
    }
}
