#region Copyright & License Information
/*
 * Copyright 2007-2011 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation. For more information,
 * see COPYING.
 */
#endregion

using OpenRA.Graphics;
using OpenRA.Mods.RA.Render;
using OpenRA.Traits;

namespace OpenRA.Mods.Cnc
{
	[Desc("Provides an overlay for the Tiberian Dawn hover craft.")]
	public class WithRoofInfo : ITraitInfo, Requires<RenderSpritesInfo>
	{
		public readonly string Sequence = "roof";

		public object Create(ActorInitializer init) { return new WithRoof(init.self, this); }
	}

	public class WithRoof
	{
		public WithRoof(Actor self, WithRoofInfo info)
		{
			var rs = self.Trait<RenderSprites>();
			var roof = new Animation(self.World, rs.GetImage(self), () => self.Trait<IFacing>().Facing);
			roof.Play(info.Sequence);
			rs.Add("roof", new AnimationWithOffset(roof, null, null, 1024));
		}
	}
}
