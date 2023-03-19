using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class BagData
{
    public void SaveToFile(string savePath, Dictionary<string, Cell> cells)
    {
        BagStruct bagStruct = new()
        {
            CellStructs = new List<CellStruct>()
        };

        foreach (var cell in cells)
        {
            CellStruct cellStruct = new()
            {
                Name = cell.Key,
                CountResources = cell.Value.CurrentCountResources,
                MaxCountResources = cell.Value.MaxCountResources
            };

            bagStruct.CellStructs.Add(cellStruct);
        }

        string json = JsonConvert.SerializeObject(bagStruct.CellStructs);
        File.WriteAllText(savePath, json);
    }

    public void LoadFromFile(string savePath, Dictionary<string, Cell> cells, Transform transform)
    {
        string json = File.ReadAllText(savePath);

        BagStruct bagStruct = new()
        {
            CellStructs = new List<CellStruct>()
        };

        bagStruct.CellStructs = JsonConvert.DeserializeObject<List<CellStruct>>(json);

        foreach (var cell in cells)
        {
            for (int j = 0; j < bagStruct.CellStructs.Count; j++)
            {
                if (cell.Key == bagStruct.CellStructs[j].Name)
                {
                    cell.Value.SetMaxCountResources(bagStruct.CellStructs[j].MaxCountResources);
                    cell.Value.InstantiateResources(bagStruct.CellStructs[j].CountResources, transform);
                }
            }
        }
    }
}
