using System;
using UnityEditor;
using UnityEngine;

namespace UniTexturePreprocessor
{
	public abstract class OverrideValueBase
	{
	}

	[Serializable]
	public abstract class OverrideValue<T> : OverrideValueBase
	{
		[SerializeField] private string m_label      = string.Empty;
		[SerializeField] private bool   m_isOverride = false;
		[SerializeField] private T      m_value      = default;

		public string Label      => m_label;
		public bool   IsOverride => m_isOverride;
		public T      Value      => m_value;

		protected OverrideValue( string label, T defaultValue )
		{
			m_label = label;
			m_value = defaultValue;
		}
	}

	[Serializable]
	public sealed class OverrideIntValue : OverrideValue<int>
	{
		public OverrideIntValue( string label, int defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideTextureResizeAlgorithm : OverrideValue<TextureResizeAlgorithm>
	{
		public OverrideTextureResizeAlgorithm( string label, TextureResizeAlgorithm defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideTextureImporterFormat : OverrideValue<TextureImporterFormat>
	{
		public OverrideTextureImporterFormat( string label, TextureImporterFormat defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideTextureImporterCompression : OverrideValue<TextureImporterCompression>
	{
		public OverrideTextureImporterCompression( string label, TextureImporterCompression defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideBoolValue : OverrideValue<bool>
	{
		public OverrideBoolValue( string label, bool defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideAndroidETC2FallbackOverride : OverrideValue<AndroidETC2FallbackOverride>
	{
		public OverrideAndroidETC2FallbackOverride( string label, AndroidETC2FallbackOverride defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideTextureImporterType : OverrideValue<TextureImporterType>
	{
		public OverrideTextureImporterType( string label, TextureImporterType defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideTextureImporterShape : OverrideValue<TextureImporterShape>
	{
		public OverrideTextureImporterShape( string label, TextureImporterShape defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideTextureImporterAlphaSource : OverrideValue<TextureImporterAlphaSource>
	{
		public OverrideTextureImporterAlphaSource( string label, TextureImporterAlphaSource defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideTextureImporterNPOTScale : OverrideValue<TextureImporterNPOTScale>
	{
		public OverrideTextureImporterNPOTScale( string label, TextureImporterNPOTScale defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideTextureImporterMipFilter : OverrideValue<TextureImporterMipFilter>
	{
		public OverrideTextureImporterMipFilter( string label, TextureImporterMipFilter defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideTextureWrapMode : OverrideValue<TextureWrapMode>
	{
		public OverrideTextureWrapMode( string label, TextureWrapMode defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideFilterMode : OverrideValue<FilterMode>
	{
		public OverrideFilterMode( string label, FilterMode defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideSpriteImportMode : OverrideValue<SpriteImportMode>
	{
		public OverrideSpriteImportMode( string label, SpriteImportMode defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideSpriteMeshType : OverrideValue<SpriteMeshType>
	{
		public OverrideSpriteMeshType( string label, SpriteMeshType defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideUintValue : OverrideValue<uint>
	{
		public OverrideUintValue( string label, uint defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideVector2 : OverrideValue<Vector2>
	{
		public OverrideVector2( string label, Vector2 defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideFloatValue : OverrideValue<float>
	{
		public OverrideFloatValue( string label, float defaultValue ) : base( label, defaultValue )
		{
		}
	}

	[Serializable]
	public sealed class OverrideSpriteAlignment : OverrideValue<SpriteAlignment>
	{
		public OverrideSpriteAlignment( string label, SpriteAlignment defaultValue ) : base( label, defaultValue )
		{
		}
	}
}