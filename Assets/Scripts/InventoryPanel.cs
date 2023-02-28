using System.Collections;
using System.Collections.Generic;
using Nova;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public ItemDatabase itemDatabase = null;
    [Header("Character")]
    public GridView characterGrid = null;

    public int CharacterCount = 24;

    [Header("Row Styling")]
    public RadialGradient rowGradient;

    private List<InventoryItem> characterItems = null;

    private void Start(){
        characterItems = itemDatabase.GetRandomItems(CharacterCount);
        characterGrid.AddDataBinder<InventoryItem, InventoryItemVisuals>(BindItem);
        characterGrid.SetSliceProvider(ProvideSlice);
        characterGrid.SetDataSource(characterItems);
    }

    private void ProvideSlice(int sliceIndex, GridView gridView, ref GridSlice2D gridSlice){
        gridSlice.Layout.AutoSize.Y = AutoSize.Shrink;
        gridSlice.AutoLayout.AutoSpace = true;
        gridSlice.Layout.Padding.Value = 30;
        gridSlice.Gradient = rowGradient;
    }

    private void BindItem(Data.OnBind<InventoryItem> evt, InventoryItemVisuals visuals, int index) => visuals.Bind(evt.UserData);

    
}
