using System;
using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// テクスチャや SpriteAtlas の設定の基底クラス
    /// Inspector のエディタ拡張を共通化するために必要
    /// </summary>
    public abstract class PreprocessorSettingsBase : ScriptableObject
    {
    }

    /// <summary>
    /// テクスチャや SpriteAtlas の個別の設定の基底クラス
    /// Inspector のエディタ拡張を共通化するために必要
    /// </summary>
    [Serializable]
    public abstract class PreprocessorSettingBase
    {
    }
}