using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class MapDrawerEditor : MonoBehaviour {
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    public Transform tl;
    public Transform tr;
    public Transform bl;
    public Transform br;
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(tl.position.x, transform.position.y, tl.position.z);
        //RaycastHit hit0;
        //if (Physics.Raycast(p0.position, -Vector3.up, out hit0, 1000))
        //{
        //    Debug.Log(hit0.collider.gameObject.layer);
        //}
    }
	
	// Update is called once per frame
	void Update () {
        
        Debug.DrawLine(p0.position, p0.position - new Vector3(0, 1000, 0), Color.red);
        Debug.DrawLine(p1.position, p1.position - new Vector3(0, 1000, 0), Color.red);
        Debug.DrawLine(p2.position, p2.position - new Vector3(0, 1000, 0), Color.red);
        Debug.DrawLine(p3.position, p3.position - new Vector3(0, 1000, 0), Color.red);
    }

    void OnGUI()
    {
        if(GUILayout.Button("Draw--Map"))
        {
            print("ddddddddddddddddd");
        }
    }

    void Draw()
    {

    }
}
