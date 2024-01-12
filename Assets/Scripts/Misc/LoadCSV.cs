using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCSV : MonoBehaviour
{
    public static LoadCSV instance;

    private string[] data;
    private TextAsset csv;

    private void Awake()
    {
        instance = this;
    }

    public string[] LoadNewCSV(string dataname)
    {
        csv = Resources.Load<TextAsset>(dataname);
        if (csv == null)
            return null;

        data = csv.text.Split(new char[] { '\n' });
        return data;
    }

    public string[] ReadSpawnRow(int i)
    {
        string[] row = data[i].Split(',');
        return row;
    }
}
