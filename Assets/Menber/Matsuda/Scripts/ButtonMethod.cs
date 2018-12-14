using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMethod : MonoBehaviour {
    [SerializeField] private float mMaxScale = 1.1f;
    [SerializeField] private float mMinScale;
    [SerializeField] private float mTimer = 0.5f;

    private RectTransform mRectTransform;
    private bool mIsScaleUp = false;
    private bool mIsAction = false;

    private void Start()
    {
        mRectTransform = GetComponent<RectTransform>();
        mIsAction = true;
        ScaleUp();
    }

    public void StartAction()
    {
        mIsAction = true;
        ScaleUp();
    }
    public void StopAction()
    {
        StartCoroutine(ScaleUpAction());
    }
    private void ScaleUp()
    {
        StartCoroutine(ScaleUpAction());
    }
    IEnumerator ScaleUpAction()
    {
        var localScale = mRectTransform.localScale;
        var scale = localScale.x;
        var time = 0f;
        while (time < 1)
        {
            if (!mIsAction) yield break;
            time += (1 / mTimer) * Time.deltaTime;
            if (time >= 1f) time = 1f;
            scale = Mathf.Lerp(mMinScale, mMaxScale, time);
            localScale.x = scale;
            localScale.y = scale;
            mRectTransform.localScale = localScale;
            yield return null;
        }
        if (mIsAction) ScaleDown();
    }
    private void ScaleDown()
    {
        StartCoroutine(ScaleDownAction());
    }
    IEnumerator ScaleDownAction()
    {
        var localScale = mRectTransform.localScale;
        var scale = localScale.x;
        var time = 0f;
        while (time < 1)
        {
            if (!mIsAction) yield break;
            time += (1 / mTimer) * Time.deltaTime;
            if (time >= 1f) time = 1f;
            scale = Mathf.Lerp(mMinScale, mMaxScale, 1 - time);
            localScale.x = scale;
            localScale.y = scale;
            mRectTransform.localScale = localScale;
            yield return null;
        }
        if (mIsAction) ScaleUp();
    }
    public void ChangeButton()
    {
        SceneManagers.Instance.ChangeSceneState();
    }

}
