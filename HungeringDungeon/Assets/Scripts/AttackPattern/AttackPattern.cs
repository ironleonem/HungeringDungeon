using UnityEngine;
using System.Collections;
using System;

public interface AttackPattern {

	void fire(ProjectileComposite shot, Transform t, Action<ProjectileComposite> configure);
}
