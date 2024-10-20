namespace CryptoServiceBybit.Processor.Processors
{
    internal class TaskQueue
    {
        private SemaphoreSlim _semaphore;
        public TaskQueue()
        {
            _semaphore = new SemaphoreSlim(1);
        }

        public async Task<T> Enqueue<T>(Func<Task<T>> task)
        {
            await _semaphore.WaitAsync();
            try
            {
                return await task.Invoke();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task Enqueue(Func<Task> task)
        {
            await _semaphore.WaitAsync();
            try
            {
                await task.Invoke();
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
