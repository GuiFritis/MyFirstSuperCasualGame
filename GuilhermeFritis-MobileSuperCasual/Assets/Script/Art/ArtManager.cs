using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Padrao.Core.Singleton;
public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType{
        CITY, WOODS, SNOW, DESERT
    }

    public List<ArtSetup> artSetups;

    public ArtSetup GetSetupByType(ArtType artType){
        foreach (var item in artSetups)
        {
            if(item.artType == artType){
                return item;
            }
        }
        return null;
    }

}

[System.Serializable]
public class ArtSetup{
    public ArtManager.ArtType artType;
    public GameObject piece;

    public GameObject particle;
}
