using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Item`/ CreateAssetMenuAttribute New Item")]

[System.Serializable]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public GameObject prefab;
}
