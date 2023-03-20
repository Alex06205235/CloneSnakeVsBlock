using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = System.Random;

public class HPBlock : MonoBehaviour
{
    private HPBlock _hpBlock;
    public Snake snake;
    [SerializeField] TextMeshProUGUI Hpblock;

    private void Start()
    {
        Random random = new Random();
        int[] _hpBlock = new int[1];
        for (int i = 0; i < _hpBlock.Length; i++)
        {
            _hpBlock[i] = random.Next(1, 30);
        }
    }

    public void Update()
    {
        Hpblock.SetText(_hpBlock.ToString());
    }
}
