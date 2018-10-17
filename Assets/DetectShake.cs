using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectShake : MonoBehaviour {

	float accelerometerUpdateInterval = 1.0f / 60.0f;
	// The greater the value of LowPassKernelWidthInSeconds, the slower the
	// filtered value will converge towards current input sample (and vice versa).
	float lowPassKernelWidthInSeconds = 1.0f;
	// This next parameter is initialized to 2.0 per Apple's recommendation,
	// or at least according to Brady! ;)
	float shakeDetectionThreshold = 2.0f;

	float lowPassFilterFactor;
	Vector3 lowPassValue;
	private TextMeshProUGUI txt;
	public bool isShake = false;
	float time = 0.0f;
	// Use this for initialization
	void Start () {
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
		shakeDetectionThreshold *= shakeDetectionThreshold;
		lowPassValue = Input.acceleration;
		txt = gameObject.GetComponent<TextMeshProUGUI>();
		txt.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
		Vector3 deltaAcceleration = acceleration - lowPassValue;

		if(isShake)
		{
			time += Time.deltaTime;
		}
		if(time >= 2.0f)
		{
			isShake = false;
			time = 0.0f;
			txt.enabled = false;
		}

		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
		{
			// Perform your "shaking actions" here. If necessary, add suitable
			// guards in the if check above to avoid redundant handling during
			// the same shake (e.g. a minimum refractory period).
			Debug.Log("Shake event detected at time "+Time.time);
			txt.enabled = true;
			isShake = true;
			time = 0.0f;
		}
	}
}
