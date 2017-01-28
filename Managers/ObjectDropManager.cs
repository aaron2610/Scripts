using UnityEngine;
using System.Collections;


public class ObjectDropManager : MonoBehaviour
{
	public GameObject stone;
	public GameObject stick;
	public GameObject bushRoot;
	public GameObject concreteChunk;
	public GameObject pipe;
	public GameObject metalChunk;

	public static GameObject stoneObj;
	public static GameObject stickObj;
	public static GameObject bushRootObj;
	public static GameObject concreteChunkObj;
	public static GameObject pipeObj;
	public static GameObject metalChunkObj;

	void Start ()
	{
		stoneObj = stone;
		stickObj = stick;
		bushRootObj = bushRoot;
		concreteChunkObj = concreteChunk;
		pipeObj = pipe;
		metalChunkObj = metalChunk;
	}
}