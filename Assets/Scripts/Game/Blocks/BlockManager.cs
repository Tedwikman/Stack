using UnityEngine;

using System.Collections.Generic;

public class BlockManager : MonoBehaviour
{
	public static BlockManager Instance
	{ get { return _instance; } }
	private static BlockManager _instance = null;

	private List<BlockObject> blockList = new List<BlockObject>();

	private void Awake()
	{
		_instance = this;
	}

	private void OnDestroy()
	{
		_instance = null;
	}

	public void AddBlock(BlockObject block)
	{
		this.blockList.Add(block);
	}

	public void RemoveAllBlocks()
	{
		for(int i = 0; i < this.blockList.Count; i++)
		{
			Destroy(this.blockList[i].gameObject);
		}

		this.blockList.Clear();
	}
}
