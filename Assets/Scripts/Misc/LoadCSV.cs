using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCSV : MonoBehaviour
{
    private string[] data;

    public void LoadNewCSV(int wave)
    {
        TextAsset csv = Resources.Load<TextAsset>("Wave"+wave);
        data = csv.text.Split(new char[] { '\n' });
    }

    public string[] ReadSpawnRow(int i)
    {
        string[] row = data[i].Split(',');
        return row;
    }
}
