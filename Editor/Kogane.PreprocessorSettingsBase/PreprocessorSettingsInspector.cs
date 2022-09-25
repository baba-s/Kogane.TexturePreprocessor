// using UnityEditor;
// using UnityEditorInternal;
// using UnityEngine;
//
// namespace Kogane.Internal
// {
//     /// <summary>
//     /// PreprocessorSettingsBase の Inspector を管理するエディタ拡張
//     /// </summary>
//     [CustomEditor( typeof( PreprocessorSettingsBase ), true )]
//     internal sealed class PreprocessorSettingsInspector : Editor
//     {
//         //==============================================================================
//         // 変数
//         //==============================================================================
//         private SerializedProperty m_property;
//         private ReorderableList    m_reorderableList;
//
//         //==============================================================================
//         // 関数
//         //==============================================================================
//         /// <summary>
//         /// 有効になった時に呼び出されます
//         /// </summary>
//         private void OnEnable()
//         {
//             m_property = serializedObject.FindProperty( "m_list" );
//
//             m_reorderableList = new ReorderableList( serializedObject, m_property )
//             {
//                 elementHeight       = 44,
//                 drawElementCallback = OnDrawElement
//             };
//         }
//
//         /// <summary>
//         /// 無効になった時に呼び出されます
//         /// </summary>
//         private void OnDisable()
//         {
//             m_property        = null;
//             m_reorderableList = null;
//         }
//
//         /// <summary>
//         /// リストの要素を描画する時に呼び出されます
//         /// </summary>
//         private void OnDrawElement( Rect rect, int index, bool isActive, bool isFocused )
//         {
//             var element = m_property.GetArrayElementAtIndex( index );
//             rect.height -= 4;
//             rect.y      += 2;
//             EditorGUI.PropertyField( rect, element );
//         }
//
//         /// <summary>
//         /// GUI を表示する時に呼び出されます
//         /// </summary>
//         public override void OnInspectorGUI()
//         {
//             serializedObject.Update();
//             m_reorderableList.DoLayoutList();
//             serializedObject.ApplyModifiedProperties();
//         }
//     }
// }