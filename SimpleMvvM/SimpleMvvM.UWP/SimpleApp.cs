﻿using System;
using System.Collections.Generic;

namespace SimpleMvvM.UWP
{
    public static class SimpleApp
    {
        private static readonly Dictionary<Type, Type> ViewsFactory = new Dictionary<Type, Type>();

        public static void RegisterView(Type view, Type viewModel)
        {
            ViewsFactory[viewModel] = view;
        }

        public static Type Resolve(Type viewModel)
        {
            try
            {
                return ViewsFactory[viewModel];
            }
            catch (Exception exception)
            {
                throw new ArgumentNullException(nameof(viewModel), exception.Message);
            }
        }
    }
}