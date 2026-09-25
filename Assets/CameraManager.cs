using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //　プレイヤーのトランスフォーム
    [SerializeField] private Transform mPlayer;

    //カメラが移動できる最大値
    [SerializeField] private float mLimitX = 100.0f;

    // 毎フレーム実行 Updateより遅れる
    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (mPlayer == null)
        {
            return;
        }
        // Mathf.Clamp(制限する対象, 最小値, 最大値)
        float tClampedX = Mathf.Clamp(mPlayer.position.x, 0f, mLimitX);

        // カメラの座意表を変更
        transform.position = new Vector3(tClampedX, transform.position.y, transform.position.z);
    }
}
