
using UnityEngine;
using System.Collections.Generic;
using GamingIsLove.Makinom.Components;

namespace GamingIsLove.Makinom
{
    [EditorSettingInfo("Conditional", "Uses Object.DestroyImmediate in the editor, otherwise uses Unity's game object destruction (GameObject.Destroy).")]
    public class ConditionalDestroySetting : BaseDestroySetting
    {
        public ConditionalDestroySetting()
        {

        }

        public override void Destroy(GameObject gameObject)
        {
            Destroy(gameObject, time: 0f);
        }

        public override void Destroy(GameObject gameObject, float time)
        {
            if (gameObject.TryGetComponent<SpawnedPrefabObject>(out var pooled) &&
                pooled.usedPrefab != null &&
                Maki.Pooling.IsPooled(pooled.usedPrefab, gameObject))
            {
                pooled.SetActive(false, time);
                return;
            }

#if UNITY_6000_4_OR_NEWER // Fix OnDisable not being called on children
#else
            gameObject.SetActive(false);
#endif // UNITY_6000_4_OR_NEWER

            if (time < 0f)
                Object.DestroyImmediate(gameObject);
#if UNITY_EDITOR
            else if (!Application.isPlaying || UnityEditor.EditorApplication.isPaused)
                Object.DestroyImmediate(gameObject);
#endif // UNITY_EDITOR
            else
                Object.Destroy(gameObject, Mathf.Max(0f, time));
        }
    }
}
