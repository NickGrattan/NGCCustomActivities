using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;

namespace NGCCustomActivities
{
    class TestCondition
    {
        public TestCondition(SPListItem listItem, string fieldName, string op, object val)
        {
            this.listItem = listItem;
            this.fieldName = fieldName;
            this.op = op;
            this.val = val;
        }

        SPListItem listItem;
        string fieldName;
        string op;
        Object val;

        public bool Test()
        {
            Type t = val.GetType();
            if (t == typeof(DateTime))     // null values can never be true
            {
                if (listItem[fieldName] == null)
                    return false;
                else
                    return TestDateTime((DateTime)listItem[fieldName], op, (DateTime)val);
            }
            else if (t == typeof(Double) || t == typeof(Int32))
            {
                if (listItem[fieldName] == null) // null values can never be true
                    return false;
                double dop1 = Convert.ToDouble(listItem[fieldName]);
                double dop2 = Convert.ToDouble(val);
                if (listItem[fieldName] == null)
                    return false;
                else
                    return TestDouble(dop1, op, dop2);
            }
            else if (t == typeof(bool))
            {
                if (listItem[fieldName] == null) // null values can never be true
                    return false;
                else
                    return TestBool((bool)listItem[fieldName], op, (bool)val);
            }
            else // everything else defaults to string
            {
                return TestString(listItem[fieldName] as string, op, val.ToString());
            }
        }

        private bool TestDateTime(DateTime op1, string op, DateTime op2)
        {
            if (op == "Equal")
            {
                return (op1 == op2);
            }
            else if (op == "NotEqual")
            {
                return (op1 != op2);
            }
            else if (op == "GreaterThan")
            {
                return op1 > op2;
            }
            else if (op == "GreaterThanOrEqual")
            {
                return op1 >= op2;
            }
            else if (op == "LessThan")
            {
                return op1 < op2;
            }
            else if (op == "LessThanOrEqual")
            {
                return op1 <= op2;
            }
            else if (op == "EqualNoTime")
            {
                return op1.Date == op2.Date;
            }
            else
            {
                throw new Exception("Unknown operator '" + op + "' in test");
            }
        }

        private bool TestDouble(double op1, string op, double op2)
        {
            if (op == "Equal")
            {
                return (Math.Abs((op1 - op2)) < 0.00001);
            }
            else if (op == "NotEqual")
            {
                return !(Math.Abs((op1 - op2)) < 0.00001);
            }
            else if (op == "GreaterThan")
            {
                return op1 > op2;
            }
            else if (op == "GreaterThanOrEqual")
            {
                return op1 >= op2;
            }
            else if (op == "LessThan")
            {
                return op1 < op2;
            }
            else if (op == "LessThanOrEqual")
            {
                return op1 <= op2;
            }
            else
            {
                throw new Exception("Unknown operator '" + op + "' in test");
            }
        }

        private bool TestString(string op1, string op, string op2)
        {
            if (string.IsNullOrEmpty(op1))
                op1 = string.Empty;
            if (string.IsNullOrEmpty(op2))
                op2 = string.Empty;
            if(op1.Contains(";#"))
                op1 = op1.Substring(op1.IndexOf(";#") + 2);
            if (op2.Contains(";#"))
                op2 = op2.Substring(op2.IndexOf(";#") + 2);

            // test unary operators first
            if (op == "IsEmpty")
            {
                return (string.IsNullOrEmpty(op1));
            }
            else if (op == "NotIsEmpty")
            {
                return (!string.IsNullOrEmpty(op1));
            }
            // test for equality/inequality
            else if (op == "Equal")
            {
                return op1 == op2;
            }
            else if (op == "NotEqual")
            {
                return op1 != op2;
            }
            else if (op == "StartsWith")
            {
                return op1.StartsWith(op2);
            }
            else if (op == "NotStartsWith")
            {
                return !op1.StartsWith(op2);
            }
            else if (op == "EndsWith")
            {
                return op1.EndsWith(op2);
            }
            else if (op == "NotEndsWith")
            {
                return !op1.EndsWith(op2);
            }
            else if (op == "Contains")
            {
                return op1.Contains(op2);
            }
            else if (op == "NotContains")
            {
                return !op1.Contains(op2);
            }
            else if (op == "EqualNoCase")
            {
                return op1.ToUpper() == op2.ToUpper();
            }
            else if (op == "ContainsNoCase")
            {
                return op1.ToUpper().Contains(op2.ToUpper());
            }
            else
            {
                throw new Exception("Unknown operator '" + op + "' in test");
            }
        }

        private bool TestBool(bool op1, string op, bool op2)
        {
            if (op == "Equal")
            {
                return op1 == op2;
            }
            else
            {
                return op1 != op2;
            }
        }
    }
}
