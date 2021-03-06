using System;
using System.Collections.Generic;
using UnityEngine;
using UnityPlatformer;
using UnityEngine.Assertions;

namespace UnityPlatformer {
  /// <summary>
  /// Animator class using UnityEngine.Animator
  /// </summary>
  public class CharacterAnimatorUnity: CharacterAnimator {
    /// <summary>
    /// Unity docs: Interface to control the Mecanim animation system.
    /// </summary>
    public Animator animator;
    /// <summary>
    /// Animation that is currently playing
    /// </summary>
    string playing;
    /// <summary>
    /// call animator.Play
    /// </summary>
    public override void Start() {
      base.Start();
      Assert.IsNotNull(animator, "(CharacterAnimatorUnity) Unnasigned property Animator at " + gameObject.GetFullName());
    }
    public override void Play(string animation) {
      if (playing == animation) {
        return;
      }

      //Debug.Log("play: " + animation + " // " + character.state, gameObject);
      playing = animation;
      animator.Play(animation);
    }

    public override void PlaybackSpeed(float speed) {
      // save it for completness but it's not used
      previousSpeed = animator.speed;
      animator.speed = speed;
    }

    public override void StopPlayback() {
      animator.StopPlayback();
    }

    public override void StartPlayback() {
      animator.StartPlayback();
    }
    /// <summary>
    /// Get animation length in seconds using RuntimeAnimatorController
    /// </summary>
    public override float GetAnimationLength(string animation) {
      RuntimeAnimatorController ac = animator.runtimeAnimatorController;
      for(int i = 0; i<ac.animationClips.Length; i++) {
        if(ac.animationClips[i].name == animation) {
          return ac.animationClips[i].length;
        }
      }

      return 0.0f;
    }
  }
}
