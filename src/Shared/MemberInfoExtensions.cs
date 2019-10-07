// Copyright (c) Kaive Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// ReSharper disable once CheckNamespace
namespace System.Reflection
{
    internal static class MemberInfoExtensions
    {
        public static Type GetMemberType(this MemberInfo memberInfo)
            => (memberInfo as PropertyInfo)?.PropertyType ?? ((FieldInfo)memberInfo)?.FieldType;
    }
}