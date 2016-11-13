using UnityEngine;
using System.Collections;

namespace UnityPlatformer {
  /// <summary>
  /// Track tile
  /// </summary>
  public class Track : BoxTileTrigger {
    /// <summary>
    /// Velocity that will be add to characters inside track
    /// </summary>
    public Vector3 velocity;
    /// <summary>
    /// Enable track
    /// </summary>
    override public void CharacterEnter(Character p) {
      // only the first one enable the rope
      if (p.track == null) {
        p.EnterArea(Areas.Track);
        p.track = this;
        p.worldVelocity += velocity;
      }
    }
    /// <summary>
    /// Disable track
    /// </summary>
    override public void CharacterExit(Character p) {
      // same as above, only diable if we leave the section we are grabbing
      if (p.track == this) {
        p.ExitArea(Areas.Track);
        p.track = null;
        p.worldVelocity -= velocity;
      }
    }
  }
}