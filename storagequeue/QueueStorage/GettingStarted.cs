using Microsoft.Azure;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;
using System.Threading.Tasks;

namespace QueueStorage
{
    public class GettingStarted
    {
        
        public async Task RunQueueStorageOperationsAsync()
        {
            string queueName = "js-queue-items";
            CloudQueue queue = CreateQueueAsync(queueName).Result; 
            await ProcessBatchOfMessagesAsync(queue); 
        }

        public async Task<CloudQueue> CreateQueueAsync(string queueName)
        {
            CloudStorageAccount storageAccount = Common.CreateStorageAccountFromConnectionString(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            Console.WriteLine("FOR KEDA--- Azure Storage Queue message sender.....");

            CloudQueue queue = queueClient.GetQueueReference(queueName);
            try
            {
                await queue.CreateIfNotExistsAsync();
            }
            catch 
            {
                Console.WriteLine("If you are running with the default configuration please make sure you have started the storage emulator.  ess the Windows key and type Azure Storage to select and run it from the list of applications - then restart the sample.");
                Console.ReadLine();
                throw;
            }
            return queue;
        }

        public async Task ProcessBatchOfMessagesAsync(CloudQueue queue)
        {
            Console.WriteLine("Pls wait.. Sending 2000 messages.");
            for (int i = 0; i < 2000; i++)
            {
                await queue.AddMessageAsync(new CloudQueueMessage(string.Format("{0} - {1}", i, "Hello World")));
                Console.Write(">" + i);
            }
        }
    }
}
