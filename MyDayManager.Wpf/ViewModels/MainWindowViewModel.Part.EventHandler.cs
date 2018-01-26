using Sorschia.Events;

namespace MyDayManager.ViewModels
{
    partial class MainWindowViewModel
    {
        private void TitleBarTextChanged(string title)
        {
            Title = title;
        }

        private void AppMessageChanged(AppMessage message)
        {
            MessageQueue.Enqueue(message.Content);
        }
    }
}
