using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DitheredShadows))]
[ExecuteInEditMode]
public class DitheredShadowsEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DitheredShadows myTarget = (DitheredShadows)target;
		EditorGUILayout.BeginVertical("Box");
		if (myTarget.point = EditorGUILayout.Toggle("Point Lights",myTarget.point))
		{
			myTarget.point_size = EditorGUILayout.Slider("Size", myTarget.point_size, 0, 0.1f);
		}
		EditorGUILayout.EndVertical();
		EditorGUILayout.BeginVertical("Box");
		if (myTarget.direction = EditorGUILayout.Toggle("Directional Lights", myTarget.direction))
		{
			myTarget.direction_size = EditorGUILayout.Slider("Size", myTarget.direction_size, 0, 0.1f);
		}
		EditorGUILayout.EndVertical();
		EditorGUILayout.BeginVertical("Box");
		if (myTarget.spot = EditorGUILayout.Toggle("Spot Lights", myTarget.spot))
		{
			myTarget.spot_size = EditorGUILayout.Slider("Size", myTarget.spot_size, 0, 0.1f);
		}
		EditorGUILayout.EndVertical();
	}
	
}
