using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ExportStage : ScriptableWizard
{
    [Header("<Name>.s<Number>")]
    public string stageName = "<Name>.s<Number>";

    [MenuItem("StageEditer/ExportStage")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<ExportStage>("ExportStage", "Export");
    }

    void OnWizardCreate()
    {
        var guids = AssetDatabase.FindAssets("", new string[]{
            "Assets/Stages/" + stageName
        });

        var assets = new string[guids.Length];
        for (int i = 0; i < guids.Length; ++i)
            assets[i] = AssetDatabase.GUIDToAssetPath(guids[i]);

        var file = EditorUtility.SaveFilePanel("ステージをエクスポート", "Assets/../..", stageName, "unitypackage");
        if (!string.IsNullOrEmpty(file))
            AssetDatabase.ExportPackage(assets, file, ExportPackageOptions.Recurse);
    }

    void OnWizardUpdate()
    {
        helpString = "エクスポートしたいステージ名を入れてエクスポートボタンを押してください。";

        var scene = EditorSceneManager.GetActiveScene();
        if (scene.path.StartsWith("Assets/Stages/"))
        {
            stageName = scene.name;
            Repaint();
        }
    }
}
