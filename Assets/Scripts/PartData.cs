using UnityEngine;

[CreateAssetMenu(fileName = "PartData", menuName = "New Part")]
public class PartData : ScriptableObject
{
    public enum Attribute
    {
        HEAD,
        BODY,
        HORNS,
        LEGS,
    }

    public string partName;
    public int cost;
    public Sprite uiIcon;
    public GameObject partPrefab;
    public Attribute attribute;
    public string[] tags;
}
