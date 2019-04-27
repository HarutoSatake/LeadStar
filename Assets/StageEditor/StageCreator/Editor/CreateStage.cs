using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class CreateStage : ScriptableWizard
{
    [Header("<Name>.s<Number>")]
    public string stageName = "<Name>.s<Number>";

    [Header("StageName")]
    public string stageTitle = "NewStage";

    [MenuItem("StageEditer/NewStage")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<CreateStage>("StageEditer", "Create");
    }

    void OnWizardCreate()
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            var dir = AssetDatabase.GUIDToAssetPath(AssetDatabase.CreateFolder("Assets/Stages", stageName));
            var scene = dir + "/" + stageName + ".unity";
            var stage = dir + "/" + stageName + ".asset";
            AssetDatabase.CopyAsset(@"Assets/StageEditor/Template/Template.unity", scene);
            AssetDatabase.CopyAsset(@"Assets/StageEditor/Template/Template.asset", stage);
            Stage stageobj = AssetDatabase.LoadAssetAtPath(stage, typeof(ScriptableObject)) as Stage;
            stageobj.sceneName = stageName;
            stageobj.stageName = stageTitle;
            EditorUtility.SetDirty(stageobj);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorSceneManager.OpenScene(scene, OpenSceneMode.Single);
        }
    }

    void OnWizardUpdate()
    {
        helpString = "ステージ名を入れて作成ボタンを押してください。";
    }
}