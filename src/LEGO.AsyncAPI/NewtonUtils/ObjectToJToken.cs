// Copyright (c) The LEGO Group. All rights reserved.

namespace LEGO.AsyncAPI.NewtonUtils
{
    using Newtonsoft.Json.Linq;

    internal static class ObjectToJToken
    {
        public static JToken Map(object o)
        {
            return o == null ? JToken.Parse("null") : JToken.FromObject(o, JsonSerializerUtils.Serializer);
        }
    }
}