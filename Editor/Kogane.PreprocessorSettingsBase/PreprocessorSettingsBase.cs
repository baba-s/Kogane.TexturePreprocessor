using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// テクスチャや SpriteAtlas の設定の基底クラス
    /// </summary>
    public abstract class PreprocessorSettingsBaseT<T> : ScriptableObject
    {
        //================================================================================
        // 変数(SerializeField)
        //================================================================================
        [SerializeField] private T[] m_list;

        //================================================================================
        // プロパティ
        //================================================================================
        public T[] List => m_list;
    }
}