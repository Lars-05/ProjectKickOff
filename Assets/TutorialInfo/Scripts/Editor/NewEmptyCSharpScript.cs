#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using TMPro;

public class TMPFontReplacer
{
    [MenuItem("Tools/Replace All TMP Fonts")]
    static void ReplaceAllTMPFonts()
    {
        TMP_FontAsset newFont = Selection.activeObject as TMP_FontAsset;
        if (newFont == null)
        {
     
            return;
        }

        TMP_Text[] allText = GameObject.FindObjectsOfType<TMP_Text>();
        foreach (var text in allText)
        {
            Undo.RecordObject(text, "Replace TMP Font");
            text.font = newFont;
            EditorUtility.SetDirty(text);
        }
        
    }
}
#endif