using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {
    public int expFoodCount = 1000;
    public int hpFoodCount = 100;
    public GameObject expFood;
    public GameObject hpFood;
    public TextAsset mapData;
    public List<Vector3> FoodPoints;
    public int mapCol;
    public int mapRow;
    public float size;

	// Use this for initialization
	void Start () {
        string[] s = mapData.text.Split('|');
        mapCol = int.Parse(s[0]);
        mapRow = int.Parse(s[1]);
        size = float.Parse(s[2]);
        for(int i = 3; i < s.Length; i++)
        {
            if(s[i] != "0")
            {
                int idx = i - 3;
                int col = idx % mapCol;
                int row = idx / mapCol;
                Vector3 v = new Vector3(col * size, 0.5f, row * size) + new Vector3(-48,0,-48);
                FoodPoints.Add(v);
            }
        }
        StartCoroutine(SpawnFood());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnFood()
    {
        for(int i = 0; i < expFoodCount / 10; i++)
        {
            SpawnExp();
            yield return new WaitForSeconds(0.05f);
        }
        for (int i = 0; i < hpFoodCount / 10; i++)
        {
            SpawnHp();
            yield return new WaitForSeconds(0.05f);
        }
    }

    void SpawnExp()
    {
        for(int i = 0; i < 10; i++)
        {
            int pos = Random.Range(0, FoodPoints.Count + 1);
            GameObject food = (GameObject)Instantiate(expFood, FoodPoints[pos], Quaternion.identity);
            FoodPoints.RemoveAt(pos);
        }
    }

    void SpawnHp()
    {
        for (int i = 0; i < 10; i++)
        {
            int pos = Random.Range(0, FoodPoints.Count + 1);
            GameObject food = (GameObject)Instantiate(hpFood, FoodPoints[pos], Quaternion.identity);
            FoodPoints.RemoveAt(pos);
        }
    }
}
