using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraphicalizationOfFunctions
{
    internal class NewWalker : CSharpSyntaxWalker
    {
        public int Complexity { get; private set; } = 1;

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            Complexity++;

            base.VisitWhileStatement(node);
        }

        public override void VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
        {
            Complexity++;

            base.VisitCaseSwitchLabel(node);
        }

        public override void VisitCasePatternSwitchLabel(CasePatternSwitchLabelSyntax node)
        {
            Complexity++;

            base.VisitCasePatternSwitchLabel(node);
        }

        public override void VisitDoStatement(DoStatementSyntax node)
        {
            Complexity++;

            base.VisitDoStatement(node);
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        {
            Complexity++;

            base.VisitIfStatement(node);
        }

        public override void VisitForStatement(ForStatementSyntax node)
        {
            Complexity++;

            base.VisitForStatement(node);
        }

        public override void VisitConditionalExpression(ConditionalExpressionSyntax node)
        {
            Complexity++;

            base.VisitConditionalExpression(node);
        }

        public override void VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            Complexity++;

            base.VisitConditionalAccessExpression(node);
        }

        public override void VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            if (node.IsKind(SyntaxKind.CoalesceExpression) ||
                node.IsKind(SyntaxKind.LogicalAndExpression) ||
                node.IsKind(SyntaxKind.LogicalOrExpression))
            {
                Complexity++;
            }

            base.VisitBinaryExpression(node);
        }

        public override void VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            var kind = node.Kind();
            if (kind == SyntaxKind.CoalesceAssignmentExpression)
            {
                Complexity++;
            }
            else if (kind is SyntaxKind.AndPattern or SyntaxKind.OrPattern)
            {
                Complexity++;
            }

            base.VisitAssignmentExpression(node);
        }

        public override void VisitSwitchExpressionArm(SwitchExpressionArmSyntax node)
        {
            Complexity++;

            base.VisitSwitchExpressionArm(node);
        }
    }
}
