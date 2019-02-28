using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainObj : MonoBehaviour {

    public enum Type { water, grass, wood, mountain }

    public Type type;

    public void SetType(int typeInt)
    {
        switch (typeInt)
        {
            case 0:
                type = Type.grass;
                break;
            case 1:
                type = Type.water;
                break;
            case 2:
                type = Type.wood;
                break;
            case 3:
                type = Type.mountain;
                break;
            default:
                Debug.LogError("Terrain Type Error");
                break;
        }
    }
}
