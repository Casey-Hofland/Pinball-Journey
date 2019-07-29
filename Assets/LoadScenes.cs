using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public int[] scenesToLoad;

    void Start()
    {
        StartCoroutine(WaitForLoaded());
    }

    IEnumerator WaitForLoaded()
    {
        List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

        foreach (var buildIndex in scenesToLoad)
        {
            var asyncOp = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
            asyncOp.allowSceneActivation = false;
            scenesLoading.Add(asyncOp);
        }

        foreach (var asyncOp in scenesLoading)
        {
            while(!asyncOp.isDone)
            {
                yield return null;
            }
        }

        for (int i = 0; i < scenesLoading.Count; i++)
        {
            scenesLoading[i].allowSceneActivation = true;
        }

        yield return null;
    }
}
