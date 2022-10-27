using UnityEngine;

public static class HashAnimationNames
{
    public static int Idle { get => Animator.StringToHash("WarriorIdle"); }
    public static int Run { get => Animator.StringToHash("WarriorRun"); }
    public static int Jump { get => Animator.StringToHash("WarriorJump"); }
    public static int Fall { get => Animator.StringToHash("WarriorFall"); }
    public static int Death { get => Animator.StringToHash("WarriorDeath"); }
    public static int Braking { get => Animator.StringToHash("WarriorBraking"); }
    public static int Attack { get => Animator.StringToHash("WarriorAttack"); }

}
