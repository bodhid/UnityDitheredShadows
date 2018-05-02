using UnityEngine;
using UnityEngine.Rendering;
[ExecuteInEditMode]
[System.Serializable]
public class DitheredShadows : MonoBehaviour {
	public static Shader deferredShading, screenSpaceShadows;
	public static Texture2D noise;
	private bool _point = true;
	private bool _direction = true;
	private bool _spot = true;
	public bool point
	{
		get
		{
			return _point;
		}
		set
		{
			_point = value;
			UpdateGraphics();
		}
	}
	public bool direction
	{
		get
		{
			return _direction;
		}
		set
		{
			_direction = value;
			UpdateGraphics();
		}
	}
	public bool spot
	{
		get
		{
			return _spot;
		}
		set
		{
			_spot = value;
			UpdateGraphics();
		}
	}
	public float point_size=0.03f;
	public float direction_size = 0.03f;
	public float spot_size = 0.03f;
	const BuiltinShaderType DS = BuiltinShaderType.DeferredShading;
	const BuiltinShaderType SSS = BuiltinShaderType.ScreenSpaceShadows;
	const BuiltinShaderMode CUSTOM = BuiltinShaderMode.UseCustom;
	const BuiltinShaderMode BUILT_IN = BuiltinShaderMode.UseBuiltin;

	private void OnEnable()
	{
		UpdateGraphics();
	}

	private void UpdateGraphics()
	{
		if (deferredShading == null) deferredShading = Resources.Load<Shader>("Internal-DeferredShading-Dithering");
		if (screenSpaceShadows == null) screenSpaceShadows = Resources.Load<Shader>("Internal-ScreenSpaceShadows-Dithering");
		if (noise == null) noise = Resources.Load<Texture2D>("NoiseHigh");
		GraphicsSettings.SetShaderMode(DS, ((_point || _spot)&&enabled) ? CUSTOM : BUILT_IN);
		GraphicsSettings.SetCustomShader(DS, ((_point || _spot) && enabled) ? deferredShading : null);
		GraphicsSettings.SetShaderMode(SSS, (direction && enabled) ? CUSTOM : BUILT_IN);
		GraphicsSettings.SetCustomShader(SSS, (direction && enabled) ? screenSpaceShadows : null);
		UpdateShaders();
	}

	private void UpdateShaders()
	{
		Shader.SetGlobalTexture("_Noise", noise);
		Shader.SetGlobalFloat("_DitherPoint", (_point && enabled) ? point_size : 0);
		Shader.SetGlobalFloat("_DitherDirection", (_direction && enabled) ? direction_size : 0);
		Shader.SetGlobalFloat("_DitherSpot", (_spot && enabled) ? spot_size : 0);
	}

	void Update ()
	{
		UpdateShaders();
	}
	private void OnDisable()
	{
		UpdateGraphics();
	}
}
