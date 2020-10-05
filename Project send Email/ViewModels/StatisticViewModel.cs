using Project_send_Email.ViewModels.Base;

namespace Project_send_Email.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        #region SendMessagesCount : int - Число отправленных сообщений

        /// <summary>Число отправленных сообщений</summary>
        private int _SendMessagesCount;

        /// <summary>Число отправленных сообщений</summary>
        public int SendMessagesCount { get => _SendMessagesCount; private set => Set(ref _SendMessagesCount, value); }

        #endregion

        public void MessageSended() => SendMessagesCount++;
    }
}
