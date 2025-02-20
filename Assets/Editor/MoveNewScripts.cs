using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    class MoveNewScripts : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            string targetFolder = "Assets/Scripts";

            if (!AssetDatabase.IsValidFolder(targetFolder))
            {
                AssetDatabase.CreateFolder("Assets", "Scripts");
            }

            foreach (string asset in importedAssets)
            {
                if (asset.EndsWith(".cs") && Path.GetDirectoryName(asset) == "Assets")
                {
                    string fileName = Path.GetFileName(asset); 
                    string newPath = Path.Combine(targetFolder, fileName); 

                    if (!File.Exists(newPath))
                    {
                        AssetDatabase.MoveAsset(asset, newPath);
                    }
                }
            }
        }
    }
}