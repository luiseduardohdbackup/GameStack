using System;
using GameStack;
using OpenTK;
using GameStack.Graphics;

namespace GameStack.Gui {
	public class ImageView : View {
		Matrix4 _scale;

		public ImageView (Sprite sprite, LayoutSpec spec = null, bool fill = true) : base(spec) {
			this.Sprite = sprite;
			this.Color = Vector4.One;
			this.Fill = fill;
		}

		public Sprite Sprite { get; set; }
		public Vector4 Color { get; set; }
		public bool Fill { get; set; }

		public override void Layout () {
			base.Layout();
			var resizable = this.Sprite as SlicedSprite;
			if (resizable != null)
				resizable.Resize(this.Size.ToVector2());

			var szsprite = this.Sprite.Size;
			var szview = this.Size;
			_scale = Matrix4.Scale(szview.Width / szsprite.X, szview.Height / szsprite.Y, 1);
		}

		protected override void OnDraw (ref Matrix4 transform) {
			var t = transform;
			if (this.Fill)
				Matrix4.Mult(ref _scale, ref transform, out t);

			SpriteMaterial spriteMat;
			if (Color != Vector4.One && (spriteMat = Sprite.Material as SpriteMaterial) != null) {
				var c = spriteMat.Color;
				spriteMat.Color = Color;
				this.Sprite.Draw(ref t);
				spriteMat.Color = c;
			} else
				this.Sprite.Draw(ref t);
		}
	}
}
