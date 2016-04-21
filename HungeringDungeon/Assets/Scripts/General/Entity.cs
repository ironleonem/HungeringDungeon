using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Entity : MonoBehaviour {

	public Marks[] marks = new Marks[MARKS.num];
	public int hitPoints;
	private int totalHealth;
	Canvas canvas;
	Text water;
	Text fire;
	RectTransform healthLeftBar;
	RectTransform healthTotalBar;
	Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();

		if(hitPoints == 0)
			hitPoints = 100;

		totalHealth = hitPoints;

		for(int i = 0; i<MARKS.num; i++){
			marks[i] = new Marks();
		}

//		water = Instantiate(Resources.Load<Text>("MarkText"));
//		water.transform.SetParent(canvas.transform);
//		water.rectTransform.anchoredPosition = cam.WorldToScreenPoint(transform.position + new Vector3(-.5f, 0.0f, 0.5f));
//
//		fire = Instantiate(Resources.Load<Text>("MarkText"));
//		fire.transform.SetParent(canvas.transform);
//		fire.rectTransform.anchoredPosition = cam.WorldToScreenPoint(transform.position + new Vector3(0.5f, 0.0f, 0.5f));

//		RectTransform healthbar = Instantiate(Resources.Load<RectTransform>("HealthBar")) as RectTransform;
//		healthbar.SetParent(canvas.transform);
//		Debug.Log("healthbar = "+healthbar);
//
//		healthLeftBar = healthbar.GetChild(1) as RectTransform;//.FindChild("Remaining") as RectTransform;//.localScale = new Vector3(0, 0, 1);
//		Debug.Log ("healthLeft = " + healthLeftBar);
//		//healthLeftBar.rectTransform.SetParent(canvas.transform);
//		healthLeftBar.anchoredPosition = cam.WorldToScreenPoint(transform.position + new Vector3(0.0f, 0.0f, 0.7f));
//		healthLeftBar.localScale = new Vector3(0, 0, 1);
//
//		healthTotalBar = healthbar.transform.GetChild(0)  as RectTransform;//.localScale = new Vector3(0, 0, 1);
//		Debug.Log ("healthTotal = " + healthTotalBar);
//		//healthTotalBar.rectTransform.SetParent(canvas.transform);
//		healthTotalBar.anchoredPosition = cam.WorldToScreenPoint(transform.position + new Vector3(0.0f, 0.0f, 0.7f));
//		healthTotalBar.localScale = new Vector3(0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
	 	if(hitPoints<=0){
			Destroy(this.gameObject);
		}

		for(int i = 0; i<MARKS.num; i++){
			marks[i].decay(Time.deltaTime);
		}

//		if(marks[MARKS.water].getCount()>0)
//			water.text = ""+marks[MARKS.water].getCount();
//		else
//			water.text = "";
//		water.rectTransform.anchoredPosition = cam.WorldToScreenPoint(transform.position + new Vector3(-.5f, 0.0f, 0.5f));
//
//		if(marks[MARKS.fire].getCount()>0)
//			fire.text = ""+marks[MARKS.fire].getCount();
//		else
//			fire.text = "";
//		fire.rectTransform.anchoredPosition = cam.WorldToScreenPoint(transform.position + new Vector3(0.5f, 0.0f, 0.5f));

//		if(hitPoints<totalHealth){
//			healthLeftBar.localScale = new Vector3((float)hitPoints/(float)totalHealth, 0.2f, 1f);
//			healthLeftBar.localPosition = new Vector3((-.5f)+(healthLeftBar.localScale.x/(2.0f)), 1.0f, 0.55f);
//			healthTotalBar.localScale = new Vector3(1f, 0.2f, 1f);
//		}
		//healthBar.anchoredPosition = cam.WorldToScreenPoint(transform.position + new Vector3(0.0f, 0.0f, 0.9f));
	}

	public void dealDamage(int d){
		hitPoints -= d;
		hitPoints = Mathf.Min(hitPoints, totalHealth);
		hitPoints = Mathf.Max (hitPoints, 0);
	}

	void OnDestroy(){
		//Debug.Log ("name:"+gameObject.name+", tag:"+tag);
		if(tag == "Player"){
			GameObject.FindWithTag("GameManager").GetComponent<GameOver>().gameOver();
		}
//		Destroy(water);
//		Destroy(fire);
	}
	
}
