using System;
using System.Linq.Expressions;

namespace CSharpCommon.Utils.Extensions {
    public static class ExpressionExtensions
    {
 
        public static Expression RemoveCast(this Expression expr) {
            if ((expr.NodeType == ExpressionType.Convert) ||
                (expr.NodeType == ExpressionType.ConvertChecked)) {
                var unary = expr as UnaryExpression;
                if (unary != null)
                    return unary.Operand;
            }
            return expr;
        }

        public static string GetName<T, TResult>(this Expression<Func<T, TResult>> expr) {
            return expr.GetMemberInfo().Member.Name;
        }

        public static MemberExpression GetMemberInfo(this Expression method) {
            LambdaExpression lambda = method as LambdaExpression;

            MemberExpression memberExpr = null;
            if (lambda.Body.NodeType == ExpressionType.Convert) {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            } else if (lambda.Body.NodeType == ExpressionType.MemberAccess) {
                memberExpr = lambda.Body as MemberExpression;
            }

            return memberExpr;
        }
    }
}
