using UnityEngine;

[CreateAssetMenu(menuName ="CharaParameter/AttackTable",fileName = "AttackTable")]
public class AttackTable : ScriptableObject{

    [SerializeField]
    [HeaderAttribute("発生フレーム数")]
    public int oFlame;
    [SerializeField]
    [HeaderAttribute("持続フレーム数")]
    public int cFlame;
    [SerializeField]
    [HeaderAttribute("硬直フレーム数")]
    public int sFlame;
    [SerializeField]
    [HeaderAttribute("ゲージ上昇値")]
    public int power;
    [SerializeField]
    [HeaderAttribute("飛び道具か")]
    public bool missile;
}
