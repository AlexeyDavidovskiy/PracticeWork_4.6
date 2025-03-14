using Cathei.BakingSheet;
using System.IO;
using UnityEngine;

public class GoogleSheetImporter : MonoBehaviour
{
    private SheetContainer sheetContainer;
    private async void Start()
    {
        sheetContainer = GetComponent<SheetContainer>();
        string googleSheetId = "1o5mmUREZxFsQ_sTkvZJU9e_DLFm2iic8OjKucXtPRMA";
        string googleCredential = File.ReadAllText("D:\\Job\\Unity\\DOTS and ECS\\PracticeWork_4.6\\PracticeWork_4.6\\skillboxlesson-453102-d577c73051de.json");

        var googleConverter = new GoogleSheetConverter(googleSheetId, googleCredential);


        await sheetContainer.Bake(googleConverter);

        var jsonConverter = new JsonSheetConverter("D:\\Job\\Unity\\DOTS and ECS\\PracticeWork_4.6\\PracticeWork_4.6");

        await sheetContainer.Bake(jsonConverter);
        var row = sheetContainer.Consumables["apple"];

        logger.LogInformation(row.Title);
    }
}

