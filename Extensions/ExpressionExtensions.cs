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
    }
}
