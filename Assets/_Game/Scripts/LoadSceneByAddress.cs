using UnityEngine;
#if USING_ADDRESSABLES
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
#endif // USING_ADDRESSABLES

namespace TCGE
{
    internal sealed class LoadSceneByAddress : MonoBehaviour
    {
        public string key = string.Empty; // address string
        
        [SerializeField] UnityEngine.UI.Slider slider;
        
#if USING_ADDRESSABLES
        private AsyncOperationHandle<SceneInstance> loadHandle;
        private float progress;

        void Start()
        {
            loadHandle = Addressables.LoadSceneAsync(key, priority: 1);
        }

        void OnGUI()
        {
            slider.value = loadHandle.PercentComplete;
            var c = slider.colors;
            if (progress != loadHandle.PercentComplete)
            {
                c.normalColor = Color.white;
                progress = loadHandle.PercentComplete;
            }
            else
            {
                c.normalColor = Color.gray;
            }
        }
#endif // USING_ADDRESSABLES
    }
}
