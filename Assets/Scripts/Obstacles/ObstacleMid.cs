﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Obstacle middle.
/// 
/// This class is subclass of Obstacle.
/// 
/// This class is designed for medium obstacle such as medium monster.
/// </summary>
public class ObstacleMid : Obstacle 
{
	/// <summary>
	/// The small obstacle prefab that medium obstacle
	/// will become if notified to become small.
	/// </summary>
	public GameObject smallObstacle;

	//on collision
	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.tag == Tags.player)
		{
			Debug.Log("hit player");

			other.gameObject.SendMessageUpwards("TakeDamage", damage);

			isDead = true;
		}
	}

	protected override void BounceObstacle (Vector2 bounceDir)
	{
		base.BounceObstacle (bounceDir);
	}

	public override void BecomeSmallObstacle ()
	{
		base.BecomeSmallObstacle ();

		GameObject newObstacle = GameController.sharedGameController.objectPool.GetObjectFromPool (smallObstacle, transform.position, Quaternion.identity);

		Obstacle o = newObstacle.GetComponent<Obstacle> ();

		o.Destination = Destination;

		GameController.sharedGameController.objectPool.RecycleObject (gameObject);
	}
}