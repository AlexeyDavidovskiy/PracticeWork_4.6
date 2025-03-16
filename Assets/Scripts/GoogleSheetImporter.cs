using System.Collections.Generic;
using UnityEngine;

public class GoogleSheetImporter : MonoBehaviour
{
    [SerializeField] private TextAsset stats;

    private void Start()
    {
        if (stats == null)
        {
            Debug.LogError("Таблица не найдена!");
            return;
        }

        ParseGoogleSheet(stats.text);
    }

    private void ParseGoogleSheet(string sheetData)
    {
        string[] lines = sheetData.Split('\n');
        List<Item> items = new List<Item>();

        if (lines.Length <= 1)
        {
            Debug.LogError("Файл пустой или не содержит данных!");
            return;
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;

            string[] values = line.Contains(";") ? line.Split(';') : line.Split(',');

            if (values.Length < 5)
            {
                Debug.LogWarning($"Ошибка в строке {i}: недостаточно данных! ({values.Length} значений)");
                continue;
            }

            string id = values[0].Trim();
            int cellCapacity;
            if (!int.TryParse(values[1].Trim(), out cellCapacity))
            {
                Debug.LogWarning($"Ошибка в строке {i}: неверное значение CellCapacity ('{values[1]}'). Заменено на 1.");
                cellCapacity = 1;
            }
            string title = values[2].Trim();
            string description = values[3].Trim();
            string iconName = values[4].Trim();

            Item newItem = new Item
            {
                ID = id,
                CellCapacity = cellCapacity,
                Title = title,
                Description = description,
                IconName = iconName
            };

            items.Add(newItem);
            Debug.Log($"Добавлен предмет: {newItem.ID} ({newItem.Title})");
        }

        Debug.Log($"Загружено {items.Count} предметов!");
    }

    [System.Serializable]
    public class Item
    {
        public string ID;
        public int CellCapacity;
        public string Title;
        public string Description;
        public string IconName;
    }
}