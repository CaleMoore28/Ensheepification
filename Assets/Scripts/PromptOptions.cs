using UnityEngine;

[CreateAssetMenu(fileName = "PromptOptions", menuName = "Scriptable Objects/PromptOptions")]
public class PromptOptions : ScriptableObject
{
    [TextArea]
    //POSSIBLE USELESS fILE
    // format is prompt, attribute number, tag number
    public object[,] dialogue = {
        {"SheepGPT, generate me a sheep with $attribute that is also $tag.", 1, 1}, 
        {"$attribute $tag", 1, 1},
        {"$attribute $tag $tag", 1, 2},
        {"$attribute $attribute", 2, 0}
    };

}
