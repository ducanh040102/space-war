using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCSV : MonoBehaviour
{
    private string[] data;
    private TextAsset csv;

    public bool IsDataNull(int wave)
    {
        csv = Resources.Load<TextAsset>("Wave" + wave);
        if (csv == null)
            return true;

        return false;
    }

    public void LoadNewCSV()
    {
        data = csv.text.Split(new char[] { '\n' });
    }

    public string[] ReadSpawnRow(int i)
    {
        

        string[] row = data[i].Split(',');
        return row;
    }
}
