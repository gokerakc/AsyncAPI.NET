// Copyright (c) The LEGO Group. All rights reserved.

namespace LEGO.AsyncAPI.Expressions
{
    /// <summary>
    /// Body expression.
    /// </summary>
    public sealed class BodyExpression : SourceExpression
    {
        /// <summary>
        /// body string.
        /// </summary>
        public const string Body = "body";

        /// <summary>
        /// Prefix for a pointer.
        /// </summary>
        public const string PointerPrefix = "#";

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyExpression"/> class.
        /// </summary>
        public BodyExpression()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyExpression"/> class.
        /// </summary>
        /// <param name="pointer">a JSON Pointer [RFC 6901](https://tools.ietf.org/html/rfc6901).</param>
        public BodyExpression(JsonPointer pointer)
            : base(pointer?.ToString())
        {
            if (pointer == null)
            {
                throw Error.ArgumentNull(nameof(pointer));
            }
        }

        /// <summary>
        /// Gets the expression string.
        /// </summary>
        public override string Expression
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Value))
                {
                    return Body;
                }

                return Body + PointerPrefix + this.Value;
            }
        }

        /// <summary>
        /// Gets the fragment string.
        /// </summary>
        public string Fragment
        {
            get
            {
                return this.Value;
            }
        }
    }
}