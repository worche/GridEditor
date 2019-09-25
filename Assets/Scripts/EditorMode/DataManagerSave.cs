using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManagerSave : MonoBehaviour
{
    [HideInInspector]
    public EditorDataBasic data = new EditorDataBasic();

    [SerializeField] GridManager circlesGrid;
    public string file = "Data.txt";

    void WriteToData()
    {

        data.circlePos.Clear();
        data.circleColor.Clear();
        data.circleId.Clear();

        int i = 0;
        foreach (var circle in circlesGrid.circles)
        {

            //CircleStats kullanılarak bu bilgilere erişilebilirdi
            Vector3 pos = circle.transform.position;
            Color color = circle.GetComponent<SpriteRenderer>().color;

            data.circlePos.Add(pos);
            data.circleColor.Add(color);
            data.circleId.Add(i);

            i++;
        }
        data.totalCircle = i;
    }

    public void Save()
    {
        WriteToData();

        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);

    }


    void WriteToFile(string fileName, string json)
    {
        string path = Application.persistentDataPath + "/" + fileName;
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
            Debug.Log(path);
        }
    }

}
