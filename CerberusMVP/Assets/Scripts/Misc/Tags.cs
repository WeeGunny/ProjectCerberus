using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    [Serializable]
    public struct Tag {
        public string tagName;
        public bool tagBool;
    }
    public List<Tag> tags = new List<Tag>();
}
