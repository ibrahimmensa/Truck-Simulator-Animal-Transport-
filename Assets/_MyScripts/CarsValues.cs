using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarsValues : MonoBehaviour
{
	[Header("Vehicle UnlockCriteria")]
	public float price = 0.0f;
	public int xps = 0;
	public int CashPrice;
	[Header("About Vehicle")]
	[TextArea]
	public string aboutVehicle;
	[Space]
    public string vehicleName;
    public float rotationSpeed = 10.0f;

	[Range(0,3500)] public float engine;
    [Range(0, 30)] public float accleration;
    [Range(0, 50)] public float handling;
    [Range(0, 2000)] public float brakes;


	[Header("Upgrades Values")]
	public float[] EngineUpgradePrice;
	public float[] AcclerationUpgradePrice;
	public float[] HandlingUpgradePrice;
	public float[] BrakesUpgradePrice;

	public int carIndex = 0;

	public float upgrade_value_power;
	public float upgrade_value_brake;
	public float upgrade_value_speed;
	public Texture[] tex;
	public Renderer rend;
	public bool jeep02 =false;
	public bool jeep01 =false;
	public Material CarMat;
	public int purchaseIndex;
	// Use this for initialization
	void Start ()
	{
//		PlayerPrefs.SetFloat ("Car"+carIndex+"EngineValue", engine);
//		PlayerPrefs.SetFloat ("Car"+carIndex+"AcclerationValue", accleration);
//		PlayerPrefs.SetFloat ("Car"+carIndex+"HandlingValue", handling);
//		PlayerPrefs.SetFloat ("Car"+carIndex+"BrakesValue", brakes);
////		Debug.Log (PlayerPrefs.GetInt ("FirstTime"));

//		Debug.Log ("Car0" + carIndex + " Engine : "+ PlayerPrefs.GetFloat ("Car" + carIndex + "EngineValue"));
//		Debug.Log ("Car0" + carIndex + " Acc : "+ PlayerPrefs.GetFloat ("Car" + carIndex + "AcclerationValue"));
//		Debug.Log ("Car0" + carIndex + " Handling : "+ PlayerPrefs.GetFloat ("Car" + carIndex + "HandlingValue"));
//		Debug.Log ("Car0" + carIndex + " Brakes : "+ PlayerPrefs.GetFloat ("Car" + carIndex + "BrakesValue"));
	}

	// Update is called once per frame
	void Update ()
	{
		//Debug.Log ("Car0" + carIndex + " Engine : "+ PlayerPrefs.GetFloat ("Car" + carIndex + "EngineValue"));
	//	Debug.Log ("Car0" + carIndex + " Acc : "+ PlayerPrefs.GetFloat ("Car" + carIndex + "AcclerationValue"));
//		Debug.Log ("Car0" + carIndex + " Handling : "+ PlayerPrefs.GetFloat ("Car" + carIndex + "HandlingValue"));
	//	Debug.Log ("Car0" + carIndex + " Brakes : "+ PlayerPrefs.GetFloat ("Car" + carIndex + "BrakesValue"));
	}
	public void BlackTex()
	{
		if (!jeep02 && !jeep01) {
			rend.material.mainTexture = tex [0];
			rend.material.SetTexture ("_EmissionMap", tex [0]);
		} else if(jeep02 && !jeep01) {
			rend.materials [1].color = Color.black;
		}
		else if (!jeep02 && jeep01)
		{
			CarMat.color = Color.black;

		}
	}
	public void blueTex()
	{
		if (!jeep02 && !jeep01) {
			rend.material.mainTexture = tex [1];
			rend.material.SetTexture ("_EmissionMap", tex [1]);
		}
		else if(jeep02 && !jeep01) {
			//	temp = rend.materials [1];
			//	temp.SetColor("_Color", Color.blue);
			rend.materials [1].color = Color.blue;
			//	rend.materials[1] = temp;
			//			rend.materials[1].shader = Shader.Find("Offroad_1_Body");
			//			rend.materials[1].SetColor("Offroad_1_Body_D", Color.blue);
			//			Debug.Log(rend.materials[1].shader);
			//			rend.materials[1].s


		}
		else if (!jeep02 && jeep01)
		{
			CarMat.color = Color.blue;

		}
	}
	public void yellowTex()
	{
		if (!jeep02 && !jeep01) {
			rend.material.mainTexture = tex [2];
			rend.material.SetTexture ("_EmissionMap", tex [2]);
		}else if(jeep02 && !jeep01) {
			rend.materials [1].color = Color.yellow;
		}
		else if (!jeep02 && jeep01)
		{
			CarMat.color = Color.yellow;

		}
	}
	public void whiteTex()
	{
		if (!jeep02 && !jeep01) {
			rend.material.mainTexture = tex [3];
			rend.material.SetTexture ("_EmissionMap", tex [3]);
		} else if (jeep02 && !jeep01) {
			rend.materials [1].color = Color.green;
		} 
		else if (!jeep02 && jeep01)
		{
			CarMat.color = Color.green;

		}
	}
	public void redTex()
	{
		if (!jeep02 && !jeep01) {
			rend.material.mainTexture = tex [4];
			rend.material.SetTexture ("_EmissionMap", tex [4]);
		}
		else if(jeep02 && !jeep01) {
			rend.materials [1].color = Color.red;
		}
		else if (!jeep02 && jeep01)
		{
			CarMat.color = Color.red;

		}
}
//	public void purchase_Item()
//	{
//		Purchaser.instance.BuyProduct (purchaseIndex);
//	}
}
