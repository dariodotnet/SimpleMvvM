using System;
using System.Collections.Generic;

namespace SimpleMvvM.Core
{
    public static class ViewsFactory
    {
        private static readonly IDictionary<Type, Type> HubTypes = new Dictionary<Type, Type>();

        public static void Register<TViewModel, TView>() where TViewModel : BindableBase
        {
            HubTypes[typeof(TViewModel)] = typeof(TView);
        }

        public static Type Resolve<TViewModel>(TViewModel viewModel) where TViewModel : BindableBase
        {
            return HubTypes[typeof(TViewModel)];
        }
    }
}