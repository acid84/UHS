using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Utgiftshantering.ViewModel
{
	public class BaseViewModel : ViewModelBase
	{
		public RelayCommand SaveCommand { get; set; }

		public virtual void Update() { }
		public virtual void Save() { }

		public void RaisePropertyChanged<T>(Expression<Func<T>> property)
		{
			RaisePropertyChanged(property.GetMemberInfo().Name);
		}
	}

}

namespace System.Linq.Expressions
{
	public static class ReflectionExtensionMethods
	{
		public static MemberInfo GetMemberInfo(this Expression expression)
		{
			MemberExpression operand;
			LambdaExpression lambdaExpression = (LambdaExpression)expression;
			if (lambdaExpression.Body as UnaryExpression != null)
			{
				UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
				operand = (MemberExpression)body.Operand;
			}
			else
			{
				operand = (MemberExpression)lambdaExpression.Body;
			}
			return operand.Member;
		}
	}
}
