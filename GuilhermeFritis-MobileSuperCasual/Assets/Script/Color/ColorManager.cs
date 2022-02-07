using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Padrao.Core.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;

    public void ChangeColorByType(ArtManager.ArtType type){
        ColorSetup setup = null;
        foreach(var item in colorSetups){
            if(item.artType == type){
                setup = item;
            }
        }
        
        for(int i = 0; i < materials.Count; i++){
            materials[i].SetColor("_Color", setup.colors[i]);
        }
    }

}

[System.Serializable]
public class ColorSetup{

    public ArtManager.ArtType artType;
    public List<Color> colors;

}
