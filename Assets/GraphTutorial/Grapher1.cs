using UnityEngine;

public class Grapher1 : MonoBehaviour {
	public int speed = 1;
	public enum FunctionOption {
		Linear,
		Exponential,
		Parabola,
		Sine
	}

	private delegate float FunctionDelegate (float x, int speed);
	private static FunctionDelegate[] functionDelegates = {
		Linear,
		Exponential,
		Parabola,
		Sine
	};

	public FunctionOption function;
	public int resolution = 10;

	private int currentResolution;
	private ParticleSystem.Particle[] points;

	void Start () {
		CreatePoints();
	}

	private void CreatePoints () {
		if(resolution < 2){
			resolution = 2;
		}
		currentResolution = resolution;
		points = new ParticleSystem.Particle[resolution];
		float increment = 1f / (resolution - 1);
		for(int i = 0; i < resolution; i++){
			float x = i * increment;
			points[i].position = new Vector3(x, 0f, 0f);
			points[i].color = new Color(x, 0f, 0f);
			points[i].size = 0.1f;
		}
	}

	void Update () {
		if(currentResolution != resolution){
			CreatePoints();
		}
		FunctionDelegate f = functionDelegates[(int)function];
		for(int i = 0; i < resolution; i++){
			Vector3 p = points[i].position;
			p.y = f(p.x, speed);
			points[i].position = p;
			Color c = points[i].color;
			c.g = p.y;
			points[i].color = c;
		}
		particleSystem.SetParticles(points, points.Length);
	}

	private static float Linear (float x, int speed) {
		return x;
	}

	private static float Exponential (float x, int speed) {
		return x * x;
	}

	private static float Parabola (float x, int speed){
		x = 2f * x - 1f;
		return x * x;
	}

	private static float Sine (float x, int speed){
		return 0.5f + 0.5f * Mathf.Sin(2 * Mathf.PI * x + Time.timeSinceLevelLoad*speed);
	}
}