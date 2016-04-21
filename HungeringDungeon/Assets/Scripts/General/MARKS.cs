using UnityEngine;
using System.Collections;

public class MARKS{
	public static readonly int num = 2;
	public static readonly int water = 0;
	public static readonly int fire = 1;
}

public class Marks{
	int count;
	float timeToDecay;

	public Marks(){
		count = 0;
		timeToDecay = 0.0f;
	}

	public int getCount(){
		return count;
	}

	public void add(int i){
		count+=i;
		if(count>10) 
			count = 10;
		timeToDecay = 3.0f;
		//Debug.Log ("Mark added. Current Count:"+count);
	}

	public void decay(float dt){
		if(timeToDecay > 0.0f){
			timeToDecay -= dt;
		}else{
			count--;
			if(count<0)
				count = 0;
			timeToDecay = 1.0f;
		}
	}

	public void consume(){
		count = 0;
	}

	public void consume(int numConsumed){
		count = Mathf.Max( count-numConsumed, 0);
	}
}
