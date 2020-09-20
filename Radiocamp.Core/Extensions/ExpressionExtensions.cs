using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Dartware.Radiocamp.Core
{
	public static class ExpressionExtensions
	{

		public static TypeDefenition GetPropertyValue<TypeDefenition>(this Expression<Func<TypeDefenition>> lambda) => lambda.Compile().Invoke();

		public static TypeDefenition GetPropertyValue<InputTypeDefenition, TypeDefenition>(this Expression<Func<InputTypeDefenition, TypeDefenition>> lambda, InputTypeDefenition input) => lambda.Compile().Invoke(input);

		public static void SetPropertyValue<TypeDefenition>(this Expression<Func<TypeDefenition>> lambda, TypeDefenition value)
		{

			MemberExpression expression = (lambda as LambdaExpression).Body as MemberExpression;
			PropertyInfo propertyInfo = (PropertyInfo)expression.Member;
			Object target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

			propertyInfo.SetValue(target, value);

		}

		public static void SetPropertyValue<InputTypeDefenition, TypeDefenition>(this Expression<Func<InputTypeDefenition, TypeDefenition>> lambda, TypeDefenition value, InputTypeDefenition input)
		{

			MemberExpression expression = (lambda as LambdaExpression).Body as MemberExpression;
			PropertyInfo propertyInfo = (PropertyInfo)expression.Member;

			propertyInfo.SetValue(input, value);

		}

	}
}