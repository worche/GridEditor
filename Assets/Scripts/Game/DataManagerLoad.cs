using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManagerLoad : MonoBehaviour
{
    EditorDataBasic data;
    public string file = "Data.txt";
    public GameObject circlePrefab;
    List<GameObject> circles = new List<GameObject>();

    public void Load()
    {
        ClearCircles();

        data = new EditorDataBasic();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);

        DataToWrite();
    }

    string ReadFromFile(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("File not exists");
            return null;
        }
    }

    public void DataToWrite()
    {
        if (data == null)
        {
            Debug.Log("Data Error");
            return;
        }


        for (int i = 0; i < data.totalCircle; i++)
        {
            Vector3 pos = data.circlePos[i];
            Color color = data.circleColor[i];
            Vector3 scale = data.circleScale[i];

            GameObject circle= Instantiate(circlePrefab, pos, Quaternion.identity,this.transform);
            circle.GetComponent<SpriteRenderer>().color = color;
            circle.transform.localScale = scale;
            circles.Add(circle);
        }

    }

    void ClearCircles()
    {
        if (circles == null)
            return;

        foreach (var circle in circles)
        {
            Destroy(circle);
        }
        circles.Clear();
    }
}
