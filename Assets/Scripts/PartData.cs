using UnityEngine;

public enum Attribute
{
    HEAD,
    BODY,
    HORNS,
    LEGS,
    TAIL,
    WINGS,
}

[CreateAssetMenu(fileName = "PartData", menuName = "New Part")]
public class PartData : ScriptableObject
{
    public string partName;
    public int cost;
    public Sprite uiIcon;
    public GameObject partPrefab;
    public Attribute attribute;
    public string[] tags;

    public Mesh mesh;
}
