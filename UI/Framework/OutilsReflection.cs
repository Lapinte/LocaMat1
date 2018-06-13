using System;
using System.Linq.Expressions;
using System.Reflection;

namespace LocaMat.UI.Framework
{
    public static class OutilsReflection
    {
        public static PropertyInfo GetInformationPropriete<T>(Expression<Func<T, object>> expression)
        {
            if (expression.NodeType != ExpressionType.Lambda)
            {
                throw new ArgumentException("L'expression doit être une expression lambda", "expression");
            }

            var lambda = (LambdaExpression)expression;
            var memberExpression = ExtraireMemberExpression(lambda.Body);

            if (memberExpression == null)
            {
                throw new ArgumentException("L'expression doit être une expression d'accès membre", "expression");
            }

            if (memberExpression.Member.DeclaringType == null)
            {
                throw new InvalidOperationException("La propriété n'a pas de type");
            }

            return memberExpression.Member.DeclaringType.GetProperty(memberExpression.Member.Name);
        }

        private static MemberExpression ExtraireMemberExpression(Expression expression)
        {
            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                return ((MemberExpression)expression);
            }

            if (expression.NodeType == ExpressionType.Convert)
            {
                var operande = ((UnaryExpression)expression).Operand;
                return ExtraireMemberExpression(operande);
            }

            return null;
        }
    }
}
