using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class LoadFromFileExample : MonoBehaviour
{
    void Start()
    {
        //string path = "AssetBundles/cubewall.unity3d";
        //// 同步加载
        //AssetBundle shareAB = AssetBundle.LoadFromFile("AssetBundles/share.unity3d");
        //AssetBundle cubeWallAB = AssetBundle.LoadFromFile("AssetBundles/cubewall.unity3d");
        //// 获取目标资源
        //GameObject wallPrefab = cubeWallAB.LoadAsset<GameObject>("CubeWall");
        //// 实例化
        //Instantiate(wallPrefab);

        ////Object[] objs=ab.LoadAllAssets();

        ////foreach (Object obj in objs)
        ////{
        ////    Instantiate(obj);
        ////}

        //// 第一种加载AB的方式 LoadFromMemoryAsync 异步加载
        //AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        //yield return request;
        //AssetBundle ab = request.assetBundle;

        //// 第二种加载AB的方式 LoadFromMemory 同步加载
        //AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(path));

        //// 第三种加载AB的方式 LoadFromFileAsync 异步加载
        //AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
        //yield return request;
        //AssetBundle ab = request.assetBundle;

        // 第四种加载AB的方式 LoadFromFile 同步加载略

        //// 第五种加载AB的方式 WWW 同步加载
        //while (Caching.ready == false)
        //{
        //    yield return null;
        //}

        ////WWW www = WWW.LoadFromCacheOrDownload(@"file://D:/Du_Unity3D_Project/SiKi/20230504_Asset_Bundle_Project/" + path, 1);
        //WWW www = WWW.LoadFromCacheOrDownload(@"http://AssetBundles/cubewall.unity3d", 1);
        //yield return www;
        //if (string.IsNullOrEmpty(www.error) == false)
        //{
        //    Debug.Log(www.error);
        //    yield break;
        //}
        //AssetBundle ab = www.assetBundle;

        //// 第六种方式 使用 UnityWebRequest，可视为 WWW 的优化，使用起来更加方便
        //// 指定URL
        //string url = @"file://D:/Du_Unity3D_Project/SiKi/20230504_Asset_Bundle_Project/";
        //UnityWebRequest request = UnityWebRequest.GetAssetBundle(url);
        //// 下载
        //yield return request.Send();
        //// 取得 AssetBundle
        ////AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        //AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;

        //// 使用
        //GameObject wallPrefab = ab.LoadAsset<GameObject>("CubeWall");
        //Instantiate(wallPrefab);

        // 加载 AssetBundleManifest 文件
        AssetBundle manifestAB = AssetBundle.LoadFromFile("AssetBundles/AssetBundles");
        AssetBundleManifest manifest = manifestAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        // 获取所有依赖项
        foreach(string name in manifest.GetAllAssetBundles())
        {
            print(name);
        }

        string[] strings= manifest.GetAllDependencies("cubewall.unity3d");
        foreach (string name in strings)
        {
            print(name);
            AssetBundle.LoadFromFile("AssetBundles/" + name);
        }
    }
}
