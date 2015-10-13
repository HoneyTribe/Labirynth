using System;
using UnityEngine;
namespace AssemblyCSharp
{
		public class TextureAppender
		{
			private Texture2D textureAtlas;
			private Rect[] uv;

			public TextureAppender (Texture2D[] textures)
			{
				uv = new Rect[textures.Length];

				int sizeX = textures [0].width;
				int sizeY = 0;
				foreach (Texture2D texture in textures)
				{
					sizeY += texture.height;
				}

				Texture2D output = new Texture2D(sizeX, sizeY);
				int currHeight = 0;
				for (int i=0; i<textures.Length; i++)
				{
					for (int y=0; y<textures[i].height; y++)
					{
						for (int x=0; x<textures[i].width; x++)
						{
							output.SetPixel(x, currHeight + y, textures[i].GetPixel(x,y));
						}
					}
					uv[i] = new Rect(0, currHeight/(float)sizeY, textures[i].width/(float)sizeX, textures[i].height/(float)sizeY);
					currHeight += textures[i].height;
				}
				output.Apply();
				output.Compress (true);
				textureAtlas = output;
			}

			public Texture2D getTextureAtlas()
			{
				return textureAtlas;
			}

			public Rect[] getUV()
			{
				return uv;
			}				
		}
}

