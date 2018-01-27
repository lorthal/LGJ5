using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {

    public enum Language
    {
        PL,
        ENG
    }

    public static Vector3 GetPositionWithoutY(Vector3 position)
    {
        return new Vector3(position.x,0,position.z);
    }
}
