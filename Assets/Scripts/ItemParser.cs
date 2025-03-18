using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class ItemParser
{
    public static async Task<List<Item>> ParseAsync(string sheetData)
    {
        return await Task.Run(() =>
        {
            string[] lines = sheetData.Split('\n');
            List<Item> items = new List<Item>();

            if (lines.Length <= 1)
            {
                Debug.LogError("���� ������ ��� �� �������� ������!");
                return items;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line)) continue;

                string[] values = line.Contains(";") ? line.Split(';') : line.Split(',');

                if (values.Length < 5)
                {
                    Debug.LogWarning($"������ � ������ {i}: ������������ ������! ({values.Length} ��������)");
                    continue;
                }

                string id = values[0].Trim();
                if (!int.TryParse(values[1].Trim(), out int cellCapacity))
                {
                    Debug.LogWarning($"������ � ������ {i}: �������� �������� CellCapacity ('{values[1]}'). �������� �� 1.");
                    cellCapacity = 1;
                }
                string title = values[2].Trim();
                string description = values[3].Trim();
                string iconName = values[4].Trim();

                items.Add(new Item(id, cellCapacity, title, description, iconName));
            }

            return items;
        });
    }
}
