using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIsystem : MonoBehaviour {
	Image HealthMeter;
	public float maxHealth;
	float curHP;


	// Use this for initialization
	void Start () {
		HealthMeter = GetComponent<Image>();
		curHP = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		HealthMeter.fillAmount = curHP / maxHealth;
	}
}
