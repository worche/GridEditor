using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManagerLoad : MonoBehaviour
{
    EditorDataBasic data;
    public string file = "Data.txt";
    public GameObject circlePrefab;

    public void Load()
    {
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
            return;

        for (int i = 0; i < data.totalCircle; i++)
        {
            Vector3 pos = data.circlePos[i];
            Color color = data.circleColor[i];

            GameObject circle= Instantiate(circlePrefab, pos, Quaternion.identity);
            circle.GetComponent<SpriteRenderer>().color = color;
        }


    }
}
