using Cathei.BakingSheet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableSheet : Sheet<ConsumableSheet.Row>
{
  public class Row : SheetRow 
    {
        public string Title { get; private set; }
        public int CellCapacity { get; private set; }
    }
}
