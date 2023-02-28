using System.Collections;
using System.Collections.Generic;
using Nova;
using UnityEngine;

// [System.Serializable]
public class InventoryItemVisuals : ItemVisuals
{   
    public UIBlock contentRoot;
    public UIBlock2D image;
    public UIBlock2D countBarFill;
    public TextBlock count;

    public void Bind(InventoryItem data){
        if(data.isEmpty){
            contentRoot.gameObject.SetActive(false);
        }else{
            contentRoot.gameObject.SetActive(true);
            image.SetImage(data.item.image);
            count.Text = data.count.ToString();
            countBarFill.Size.X.Percent = Mathf.Clamp01(data.count / (float)InventoryItem.MaxCount);
        }
    }
}
 