using System;
using System.ComponentModel;

namespace Eto.Drawing
{
	/// <summary>
	/// Represents a floating point size with width and height components
	/// </summary>
	[TypeConverter (typeof (SizeFConverter))]
	public struct SizeF : IEquatable<SizeF>
	{
		/// <summary>
		/// Implicitly converts the specified integral <paramref name="size"/> to a floating point <see cref="SizeF"/>
		/// </summary>
		/// <param name="size">Size to convert</param>
		/// <returns>A new instance of a floating point SizeF with the same value as the specified <paramref name="size"/></returns>
		public static implicit operator SizeF (Size size)
		{
			return new SizeF (size.Width, size.Height);
		}

		/// <summary>
		/// Gets or sets the width
		/// </summary>
		public float Width { get; set; }

		/// <summary>
		/// Gets or sets the height
		/// </summary>
		public float Height { get; set; }

		/// <summary>
		/// Gets an empty size with a zero width and height
		/// </summary>
		public static readonly SizeF Empty = new SizeF (0, 0);

		/// <summary>
		/// Returns the minimum width and height of two sizes
		/// </summary>
		/// <param name="size1">First size to get the minimum values</param>
		/// <param name="size2">Second size to get the minimum values</param>
		/// <returns>A new instance of a Size struct with the minimum width and height of either sizes</returns>
		public static SizeF Min (SizeF size1, SizeF size2)
		{
			return new SizeF (Math.Min (size1.Width, size2.Width), Math.Min (size1.Height, size2.Height));
		}

		/// <summary>
		/// Returns the maximum width and height of two sizes
		/// </summary>
		/// <param name="size1">First size to get the maximum values</param>
		/// <param name="size2">Second size to get the maximum values</param>
		/// <returns>A new instance of a Size struct with the maximum width and height of either sizes</returns>
		public static SizeF Max (SizeF size1, SizeF size2)
		{
			return new SizeF (Math.Max (size1.Width, size2.Width), Math.Max (size1.Height, size2.Height));
		}

		/// <summary>
		/// Returns the absolute width and height of the specified <paramref name="size"/>
		/// </summary>
		/// <param name="size">Size to convert</param>
		/// <returns>A new instance of a Size struct with absolute (positive) width and height</returns>
		public static SizeF Abs (SizeF size)
		{
			return new SizeF(Math.Abs (size.Width), Math.Abs (size.Height));
		}

		/// <summary>
		/// Initializes a new SizeF class with the specified width and height
		/// </summary>
		/// <param name="width">Initial width of the size</param>
		/// <param name="height">Initial height of the size</param>
		public SizeF (float width, float height)
			: this()
		{
			this.Width = width;
			this.Height = height;
		}

		/// <summary>
		/// Initializes a new SizeF class with width and height corresponding to the <see cref="PointF.X"/> and <see cref="PointF.Y"/> of the specified <paramref name="point"/>
		/// </summary>
		/// <param name="point">Point to convert to a SizeF struct</param>
		public SizeF (PointF point)
			: this(point.X, point.Y)
		{
		}

		/// <summary>
		/// Gets a value indicating that the specified <paramref name="point"/> is within the <see cref="Width"/> and <see cref="Height"/> of this size
		/// </summary>
		/// <param name="point">Point to test</param>
		/// <returns>True if the <paramref name="point"/> has an X and Y value between 0 and the Width and Height of this size, respectively. False otherwise</returns>
		public bool Contains (PointF point)
		{
			return Contains (point.X, point.Y);
		}

		/// <summary>
		/// Gets a value indicating that the specified <paramref name="x"/> and <paramref name="y"/> values are within the <see cref="Width"/> and <see cref="Height"/> of this size
		/// </summary>
		/// <param name="x">X value to test</param>
		/// <param name="y">Y value to test</param>
		/// <returns>True if the <paramref name="x"/> and <paramref name="y"/> values are between 0 and the Width and Height of this size, respectively. False otherwise</returns>
		public bool Contains (float x, float y)
		{
			if (Width == 0 || Height == 0)
				return false;
			return (x >= 0 && x <= Width && y >= 0 && y <= Height);
		}

		/// <summary>
		/// Gets a value indicating that both the <see cref="Width"/> and <see cref="Height"/> are zero
		/// </summary>
		public bool IsZero {
			get { return Width == 0 && Height == 0; }
		}

		/// <summary>
		/// Gets a value indicating that either the <see cref="Width"/> or <see cref="Height"/> are zero
		/// </summary>
		public bool IsEmpty {
			get { return Width == 0 || Height == 0; }
		}

        public static SizeF operator -(SizeF size)
        {
            return
                new SizeF(-size.Width, -size.Height);
        }
		
		/// <summary>
		/// Multiplies the <see cref="Width"/> and <see cref="Height"/> of two sizes
		/// </summary>
		/// <param name="size1">First size to multiply</param>
		/// <param name="size2">Second size to multiply</param>
		/// <returns>A new instance of a SizeF struct with the product of both sizes</returns>
		public static SizeF operator * (SizeF size1, SizeF size2)
		{
			SizeF result = size1;
			result.Width = size1.Width * size2.Width;
			result.Height = size1.Height * size2.Height;
			return result;
		}

		/// <summary>
		/// Multiplies the <see cref="Width"/> and <see cref="Height"/> of a <paramref name="size"/> by the specified <paramref name="factor"/>
		/// </summary>
		/// <param name="size">Size to multiply</param>
		/// <param name="factor">Factor to multiply both the Width and Height by</param>
		/// <returns>A new instance of a SizeF struct with the product of the <paramref name="size"/> and <paramref name="factor"/></returns>
		public static SizeF operator * (SizeF size1, float multiplier)
		{
			SizeF result = size1;
			result.Width = size1.Width * multiplier;
			result.Height = size1.Height * multiplier;
			return result;
		}

		/// <summary>
		/// Divides the <see cref="Width"/> and <see cref="Height"/> of two sizes
		/// </summary>
		/// <param name="size1">Size to divide</param>
		/// <param name="size2">Size to divide by</param>
		/// <returns>A new instance of a SizeF struct with the division of <paramref name="size1"/> by <paramref name="size2"/></returns>
		public static SizeF operator / (SizeF size1, SizeF size2)
		{
			SizeF result = size1;
			result.Width = size1.Width / size2.Width;
			result.Height = size1.Height / size2.Height;
			return result;
		}

		/// <summary>
		/// Divides the <see cref="Width"/> and <see cref="Height"/> of a <paramref name="size"/> by the specified <paramref name="factor"/>
		/// </summary>
		/// <param name="size">Size to divide</param>
		/// <param name="factor">Factor to divide both the Width and Height by</param>
		/// <returns>A new instance of a SizeF struct with the width and height of <paramref name="size"/> divided by <paramref name="factor"/></returns>
		public static SizeF operator / (SizeF size1, float factor)
		{
			SizeF result = size1;
			result.Width = size1.Width / factor;
			result.Height = size1.Height / factor;
			return result;
		}

		/// <summary>
		/// Adds the <see cref="Width"/> and <see cref="Height"/> values of two sizes together
		/// </summary>
		/// <param name="size1">First size to add</param>
		/// <param name="size2">Second size to add</param>
		/// <returns>A new instance of a SizeF struct with the addition of the width and height of both sizes</returns>
		public static SizeF operator + (SizeF size1, SizeF size2)
		{
			SizeF result = size1;
			result.Width = size1.Width + size2.Width;
			result.Height = size1.Height + size2.Height;
			return result;
		}

		/// <summary>
		/// Subtracts the <see cref="Width"/> and <see cref="Height"/> value of one size from another
		/// </summary>
		/// <param name="size1">Size to subtract from</param>
		/// <param name="size2">Size to subtract</param>
		/// <returns>A new instance of a SizeF struct with the width and height of <paramref name="size1"/> minus <paramref name="size2"/></returns>
		public static SizeF operator - (SizeF size1, SizeF size2)
		{
			SizeF result = size1;
			result.Width = size1.Width - size2.Width;
			result.Height = size1.Height - size2.Height;
			return result;
		}

		/// <summary>
		/// Subtracts a <paramref name="value"/> from the <see cref="Width"/> and <see cref="Height"/> of the specified <paramref name="size"/>
		/// </summary>
		/// <param name="size">Size to subtract from</param>
		/// <param name="value">Value to subtract from the width and height</param>
		/// <returns>A new instance of a SizeF struct with the width and height of <paramref name="size"/> minus <paramref name="value"/></returns>
		public static SizeF operator - (SizeF size1, float value)
		{
			return new SizeF (size1.Width - value, size1.Height - value);
		}

		/// <summary>
		/// Adds a <paramref name="value"/> to the <see cref="Width"/> and <see cref="Height"/> of the specified <paramref name="size"/>
		/// </summary>
		/// <param name="size">Size to add to</param>
		/// <param name="value">Value to add to the width and height</param>
		/// <returns>A new instance of a SizeF struct with the width and height of <paramref name="size"/> plus <paramref name="value"/></returns>
		public static SizeF operator + (SizeF size1, float value)
		{
			return new SizeF (size1.Width + value, size1.Height + value);
		}

		/// <summary>
		/// Compares two sizes for equality
		/// </summary>
		/// <param name="size1">First size to compare</param>
		/// <param name="size2">Second size to compare</param>
		/// <returns>True if both the width and height of both sizes are equal, false otherwise</returns>
		public static bool operator == (SizeF size1, SizeF size2)
		{
			return (size1.Width == size2.Width && size1.Height == size2.Height);
		}

		/// <summary>
		/// Compares two sizes for inequality
		/// </summary>
		/// <param name="size1">First size to compare</param>
		/// <param name="size2">Second size to compare</param>
		/// <returns>True if either the width and height of both sizes are not equal, false if they are both equal</returns>
		public static bool operator != (SizeF size1, SizeF size2)
		{
			return (size1.Width != size2.Width || size1.Height != size2.Height);
		}

		/// <summary>
		/// Compares this size to the specified <paramref name="obj"/>
		/// </summary>
		/// <param name="obj">Object to compare with</param>
		/// <returns>True if the specified <paramref name="obj"/> is a Size and is equal to this instance</returns>
		public override bool Equals (object obj)
		{
			return obj is SizeF && (SizeF)obj == this;
		}

		/// <summary>
		/// Gets the hash code for this Size
		/// </summary>
		/// <returns>Hash code value for this size</returns>
		public override int GetHashCode ()
		{
			return Width.GetHashCode () ^ Height.GetHashCode ();
		}

		/// <summary>
		/// Converts this Size struct to a string
		/// </summary>
		/// <returns>String representation of this SizeF</returns>
		public override string ToString ()
		{
			return String.Format ("Width={0} Height={1}", Width, Height);
		}

		/// <summary>
		/// Compares this size to the <paramref name="other"/> size
		/// </summary>
		/// <param name="other">Other size to compare with</param>
		/// <returns>True if the <paramref name="other"/> size is equal to this instance</returns>
		public bool Equals (SizeF other)
		{
			return other == this;
		}
	}
}
