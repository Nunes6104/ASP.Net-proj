using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Field |
    System.AttributeTargets.Method | System.AttributeTargets.Parameter | System.AttributeTargets.Property,
    AllowMultiple = true)]

    public class NumUnico: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int num;
            if (int.TryParse(value.ToString(), out num))
            {
                BD bd = new BD();
                int t = bd.GetAlunos().Where(a => a.Num == num).Count();
                return t == 0;
            }
            else return false;
        }
    }
}