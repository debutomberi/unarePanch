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
    [HeaderAttribute("必殺技")]
    public bool deathblow;
    [SerializeField]
    [HeaderAttribute("飛び道具か")]
    public bool missile;
    [SerializeField]
    [HeaderAttribute("飛ぶ時間")]
    public float flyTime = 1.0f;
    [SerializeField]
    [HeaderAttribute("攻撃の見た目")]
    public Sprite[] AttackSprite = new Sprite[5];


}
