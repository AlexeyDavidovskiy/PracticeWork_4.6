using Cathei.BakingSheet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetContainer : SheetContainerBase
{
    public SheetContainer(Microsoft.Extensions.Logging.ILogger logger) : base(logger) { }

    public ConsumableSheet Consumables { get;private set; }
}
