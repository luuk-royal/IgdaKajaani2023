using UnityEngine;

[CreateAssetMenu(fileName = "NewMiniGame", menuName = "MiniGame Data", order = 0)]
public class MiniGameData : ScriptableObject
{
    public string sceneName;
    public int score;
}