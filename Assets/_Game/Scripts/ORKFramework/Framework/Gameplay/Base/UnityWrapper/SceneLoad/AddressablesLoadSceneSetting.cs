
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace GamingIsLove.Makinom
{
    [EditorSettingInfo("Addressables", "Load a scene from an Addressables key.")]
    public class AddressablesLoadSceneSetting : BaseLoadSceneSetting
    {
        public AddressablesLoadSceneSetting()
        {

        }

        public override void LoadScene(string sceneName, LoadSceneMode mode)
        {
#if INCLUDE_ADDRESSABLES
            //Maki.StartCoroutine(LoadAsync(sceneName, mode));
            _ = UnityEngine.AddressableAssets.Addressables.LoadSceneAsync(sceneName, mode, priority: 1);
#else
            SceneManager.LoadScene(sceneName, mode);
#endif // INCLUDE_ADDRESSABLES
        }

        public override void LoadSceneAsync(string sceneName, LoadSceneMode mode)
        {
#if INCLUDE_ADDRESSABLES
            //Maki.StartCoroutine(LoadAsync(sceneName, mode));
            _ = UnityEngine.AddressableAssets.Addressables.LoadSceneAsync(sceneName, mode, priority: 1);
#else
            SceneManager.LoadSceneAsync(sceneName, mode);
#endif // INCLUDE_ADDRESSABLES
        }

#if INCLUDE_ADDRESSABLES
        private static async Awaitable LoadAsync(string key, LoadSceneMode mode)
        {
            //var activityIndicator = new ActivityIndicator(start: true);
            var sceneHandle = UnityEngine.AddressableAssets.Addressables.LoadSceneAsync(key, mode, priority: 1);

            var handler = Maki.Game.Variables;
            var screenFader = Maki.UI.ScreenFader;
            while (!sceneHandle.IsDone)
            {
                float percentComplete = sceneHandle.PercentComplete;
                handler?.Set("loading", percentComplete);
                screenFader?.SetColor(new Color(0, 0, 0, percentComplete));
                await Awaitable.NextFrameAsync();
            }

            //activityIndicator.Dispose();
        }
#endif // INCLUDE_ADDRESSABLES
    }
}
