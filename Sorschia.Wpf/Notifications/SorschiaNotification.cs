﻿using Prism.Mvvm;

namespace Sorschia.Notifications
{
    public class SorschiaNotification : BindableBase, ISorschiaNotification
    {
        public SorschiaNotification()
        {
            Title = string.Empty;
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private object _Content;
        public object Content
        {
            get { return _Content; }
            set { SetProperty(ref _Content, value); }
        }
    }
}
