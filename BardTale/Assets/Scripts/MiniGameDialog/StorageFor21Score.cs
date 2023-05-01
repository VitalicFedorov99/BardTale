using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageFor21Score : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<string> texts;


    public string GetText(int id) => texts[id];
    public Sprite GetSprite(int id) => sprites[id];

    public int GetCount() => sprites.Count;
}
