using UnityEngine;

public class OldAdroidFix : MonoBehaviour
{

    public Material OldAndroidMaterial;

#if UNITY_ANDROID && !UNITY_EDITOR
    private void Awake()
    {
        if(GetSDKLevel() < 19)
        {
            GetComponent<Renderer>().sharedMaterial = OldAndroidMaterial;
        }
    }

    public int GetSDKLevel()
    {
        var clazz = AndroidJNI.FindClass("android.os.Build$VERSION");
        var fieldID = AndroidJNI.GetStaticFieldID(clazz, "SDK_INT", "I");
        var sdkLevel = AndroidJNI.GetStaticIntField(clazz, fieldID);
        return sdkLevel;
    }
#endif
}
