using System;
using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// テクスチャや SpriteAtlas の設定の基底クラス
    /// </summary>
    public abstract class PreprocessorSettingsBaseT<T> : PreprocessorSettingsBase
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

    /// <summary>
    /// テクスチャや SpriteAtlas の個別の設定の基底クラス
    /// </summary>
    [Serializable]
    public abstract class PreprocessorSettingBaseT<T> : PreprocessorSettingBase
    {
        //================================================================================
        // 変数(SerializeField)
        //================================================================================
        [SerializeField] private string m_path;
        [SerializeField] private T      m_settings;

        //================================================================================
        // プロパティ
        //================================================================================
        public string Path     => m_path;
        public T      Settings => m_settings;
    }
}