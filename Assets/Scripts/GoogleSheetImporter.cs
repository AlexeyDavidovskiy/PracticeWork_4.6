using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GoogleSheetImporter : MonoBehaviour
{
    [SerializeField] private TextAsset stats;

    private async void Start()
    {
        if (stats == null)
        {
            Debug.LogError("Таблица не найдена!");
            return;
        }

        List<Item> items = await ItemParser.ParseAsync(stats.text);
        Debug.Log($"Загружено {items.Count} предметов!");
    }
}

[System.Serializable]
public class Item
{
    public string ID { get; }
    public int CellCapacity { get; }
    public string Title { get; }
    public string Description { get; }
    public string IconName { get; }

    public Item(string id, int cellCapacity, string title, string description, string iconName)
    {
        ID = id;
        CellCapacity = cellCapacity;
        Title = title;
        Description = description;
        IconName = iconName;
    }
}