using UnityEngine;
using TMPro;

public class ScoresComponent : MonoBehaviour
{
    public int Best
    {
        get;
        set;
    }

    public int Current
    {
        get;
        set;
    }

    public static TextMeshProUGUI _scoreTextComponent;

    public void UpdateBestScores(int count)
    {
        Best = count;
    }
    void Start()
    {
        Current = 0;
        _scoreTextComponent = gameObject.GetComponent<TextMeshProUGUI>();
        _scoreTextComponent.text = Current.ToString();
    }

    void Update()
    {
        _scoreTextComponent.text = Current.ToString();
        
    }
}