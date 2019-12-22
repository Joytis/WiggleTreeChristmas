using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public static class AnimatorExtensions {
    public static IEnumerator PlayAndWait(this Animator animator, string name) {
        animator.Play(name, 0, 0f);

        //Wait until we enter the current state
        animator.Update(0f);
        while (animator.GetCurrentAnimatorStateInfo(0).IsName(name)) {
            yield return null;
        }
    }
}