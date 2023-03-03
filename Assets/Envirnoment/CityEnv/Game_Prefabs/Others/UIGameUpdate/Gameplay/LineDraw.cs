using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class LineDraw : MonoBehaviour
{
	public LineRenderer line;
	public Transform target;
	public NavMeshAgent agent;
	public float lineWidth = 2f;
    public Vector3 initRotation;

    void Awake()
    {
        initRotation = transform.eulerAngles;
    }

    void Start ()
	{
        Invoke("DelayedCall", 1.5f);
    }


	IEnumerator getPath ()
	{
        transform.rotation = Quaternion.Euler(initRotation);
        line.SetPosition (0, transform.position);
		agent.SetDestination (target.position);
		yield return new WaitForEndOfFrame ();
		DrawPath (agent.path);
		agent.isStopped = true;
		yield return new WaitForSeconds (0.2f);
		var length = (this.transform.position - target.position).magnitude;
		StartCoroutine (getPath ());
		yield return null;
	}

	public void DrawPath (NavMeshPath path)
	{
		if (path.corners.Length < 1)
			return;

		line.positionCount = path.corners.Length;
		for (int i = 0; i < path.corners.Length; i++) {
			line.SetPosition (i, path.corners [i]);
		}
	}

    public void DelayedCall()
    {
        //target = GameManager.instance.playerSettings.player.transform;
        line = GetComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        StartCoroutine(getPath());
    }
}
