using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    int score;

    public void ChangeScore(int change)
    {
        if (score + change >= 0)
        {
            score += change;
        }
        else
        {
            score = 0;
        }
    }
}
