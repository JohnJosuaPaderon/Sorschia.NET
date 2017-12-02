using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Sorschia.ViewModels
{
    public abstract class PopupViewModelBase : BindableBase, IInteractionRequestAware
    {
        public PopupViewModelBase(IEventAggregator eventAggregator)
        {
            _EventAggregator = eventAggregator;

            CloseCommand = new DelegateCommand(Close);
            ResetMouseCaptureCommand = new DelegateCommand(ResetMouseCapture);
        }

        protected readonly IEventAggregator _EventAggregator;

        public DelegateCommand CloseCommand { get; }
        public DelegateCommand ResetMouseCaptureCommand { get; }
        public Action FinishInteraction { get; set; }

        private INotification _Notification;
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

        protected virtual void Close()
        {
            FinishInteraction?.Invoke();
        }

        private void ResetMouseCapture()
        {
            Mouse.Capture(null);
        }
    }

    public abstract class PopupViewModelBase<TNotification> : BindableBase, IInteractionRequestAware
        where TNotification : INotification
    {
        public PopupViewModelBase(IEventAggregator eventAggregator)
        {
            _EventAggregator = eventAggregator;

            CloseCommand = new DelegateCommand(Close);
            ResetMouseCaptureCommand = new DelegateCommand(ResetMouseCapture);
            InitializeCommand = new DelegateCommand(Initialize);
        }

        protected readonly IEventAggregator _EventAggregator;

        public DelegateCommand CloseCommand { get; }
        public DelegateCommand ResetMouseCaptureCommand { get; }
        public DelegateCommand InitializeCommand { get; }
        public Action FinishInteraction { get; set; }

        private TNotification _Notification;
        public INotification Notification
        {
            get { return _Notification; }
            set
            {
                SetProperty(ref _Notification, (TNotification)value, () => Content = value.Content);
            }
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

        protected TNotification PopupNotification
        {
            get { return _Notification; }
            set
            {
                SetProperty(ref _Notification, value, () => Content = value.Content);
            }
        }

        private string _Header;
        public string Header
        {
            get { return _Header; }
            set { SetProperty(ref _Header, value); }
        }

        protected virtual void Initialize()
        {
            // TODO: Initialization
        }

        protected virtual void Close()
        {
            FinishInteraction?.Invoke();
        }

        private void ResetMouseCapture()
        {
            Mouse.Capture(null);
        }
    }
}
