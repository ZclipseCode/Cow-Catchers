using UnityEngine;

public class LassoZone : MonoBehaviour
{
    PlayerInfo playerInfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lassoable"))
        {
            GameObject lassoable = collision.gameObject;

            LassoableInfo info = lassoable.GetComponent<LassoableInfo>();
            playerInfo.ChangeScore(info.GetValue());

            Destroy(lassoable);
        }
    }

    public void SetPlayerInfo(PlayerInfo value) => playerInfo = value;
}
