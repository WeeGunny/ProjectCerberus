using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonScriptableObject<T> :ScriptableObject where T : SingletonScriptableObject<T>
{
    private static T instance;
    public static T Instance
    {
        get
        { if(!instance)
            {
                T[] assets = Resources.LoadAll<T>("");
                if (assets == null || assets.Length<1)
                {
                    throw new System.Exception("Could not find any instances of this object");
                }else if (assets.Length>1)
                {
                    Debug.LogWarning("There is more than one instace of this object, selecting first one found");
                }
                instance = assets[0];
            }
            return instance;
        }

    }
}
