using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class CreateABs
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBandles()
    {
        string dir = "AssetBundles";
        if (Directory.Exists(dir)==false)
        {
            Directory.CreateDirectory(dir);
        }

        // BuildAssetBundleOptions.ChunkBasedCompression 使用LZ4压缩
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }
}
