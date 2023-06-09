﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentsClubsWeb.Models;

#pragma warning disable 219, 612, 618
#nullable enable

namespace StudentsClubsWeb.Data.Compiled
{
    internal partial class ClubEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "StudentsClubsWeb.Models.Club",
                typeof(Club),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(Club).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Club).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);

            var createdAt = runtimeEntityType.AddProperty(
                "CreatedAt",
                typeof(DateTime),
                propertyInfo: typeof(Club).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Club).GetField("<CreatedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var description = runtimeEntityType.AddProperty(
                "Description",
                typeof(string),
                propertyInfo: typeof(Club).GetProperty("Description", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Club).GetField("<Description>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 2000);

            var image = runtimeEntityType.AddProperty(
                "Image",
                typeof(string),
                propertyInfo: typeof(Club).GetProperty("Image", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Club).GetField("<Image>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);

            var name = runtimeEntityType.AddProperty(
                "Name",
                typeof(string),
                propertyInfo: typeof(Club).GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Club).GetField("<Name>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 100);

            var viewsCount = runtimeEntityType.AddProperty(
                "ViewsCount",
                typeof(int),
                propertyInfo: typeof(Club).GetProperty("ViewsCount", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Club).GetField("<ViewsCount>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static RuntimeSkipNavigation CreateSkipNavigation1(RuntimeEntityType declaringEntityType, RuntimeEntityType targetEntityType, RuntimeEntityType joinEntityType)
        {
            var skipNavigation = declaringEntityType.AddSkipNavigation(
                "Members",
                targetEntityType,
                joinEntityType.FindForeignKey(
                    new[] { joinEntityType.FindProperty("ClubsId")! },
                    declaringEntityType.FindKey(new[] { declaringEntityType.FindProperty("Id")! })!,
                    declaringEntityType)!,
                true,
                false,
                typeof(List<AppUser>),
                propertyInfo: typeof(Club).GetProperty("Members", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Club).GetField("<Members>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var inverse = targetEntityType.FindSkipNavigation("Clubs");
            if (inverse != null)
            {
                skipNavigation.Inverse = inverse;
                inverse.Inverse = skipNavigation;
            }

            return skipNavigation;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Clubs");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
