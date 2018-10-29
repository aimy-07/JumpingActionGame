using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Joystick))]
public class JoystickEditor : Editor {

    private SerializedProperty _radiusProperty;
    private SerializedProperty _shouldResetPositionProperty;
    private SerializedProperty _positionProperty;

    private void OnEnable()
    {
        _radiusProperty = serializedObject.FindProperty("_radius");
        _shouldResetPositionProperty = serializedObject.FindProperty("_shouldResetPosition");
        _positionProperty = serializedObject.FindProperty("_position");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        float radius = EditorGUILayout.FloatField("動作範囲の半径", _radiusProperty.floatValue);
        if (radius != _radiusProperty.floatValue)
        {
            _radiusProperty.floatValue = radius;
        }

        bool shouldResetPosition = EditorGUILayout.Toggle("Stickが中心に戻るか", _shouldResetPositionProperty.boolValue);
        if (shouldResetPosition != _shouldResetPositionProperty.boolValue)
        {
            _shouldResetPositionProperty.boolValue = shouldResetPosition;
        }

        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUILayout.LabelField("position(-1~1) X:" + _positionProperty.vector2Value.x.ToString("F2") + ", Y:" + _positionProperty.vector2Value.y.ToString("F2"));
        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }
}
