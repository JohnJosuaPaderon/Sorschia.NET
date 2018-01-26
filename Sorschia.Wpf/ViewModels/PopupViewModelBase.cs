using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using System;

namespace Sorschia.ViewModels
{
    public abstract class PopupViewModelBase : ViewModelBase
    {
        public PopupViewModelBase(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            CloseCommand = new DelegateCommand(Close);
        }

        public DelegateCommand CloseCommand { get; }
        public Action FinishInteraction { get; set; }

        protected INotification _Notification;

        public INotification Notification
        {
            get { return _Notification; }
            set { SetProperty(ref _Notification, value, () => Content = value.Content); }
        }

        public object Content
        {
            get { return Notification?.Content; }
            set
            {
                if (Notification != null)
                {
                    Notification.Content = value;
                    RaisePropertyChanged();
                }
            }
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw SorschiaException.InvalidOperation("Navigating to Popup is invalid.");
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw SorschiaException.InvalidOperation("Navigating from Popup is invalid.");
        }

        protected virtual void Close()
        {
            FinishInteraction?.Invoke();
        }
    }

    public abstract class PopupViewModelBase<TNotification> : PopupViewModelBase
        where TNotification : INotification
    {
        public PopupViewModelBase(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
        
        protected TNotification PopupNotification
        {
            get { return (TNotification)Notification; }
            set
            {
                SetProperty(ref _Notification, value, () => Content = value.Content);
            }
        }
    }
}
