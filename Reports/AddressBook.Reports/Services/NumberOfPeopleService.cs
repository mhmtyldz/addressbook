using AddressBook.Reports.Models;
using AddressBook.Reports.Services.Interfaces;
using AddressBook.Reports.Settings;
using AddressBook.Shared.Messages;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Reports.Services
{
    public class NumberOfPeopleService : INumberOfPeopleService
    {
        private readonly IMongoCollection<NumberOfPeople> _numberOfPeopleCollection;

        public NumberOfPeopleService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _numberOfPeopleCollection = database.GetCollection<NumberOfPeople>(databaseSettings.NumberOfPeopleCollectionName);
        }

        public async Task<bool> Update(NumberOfPeopleAtThatLocationCommand numberOfPeopleCommand)
        {
            var result = false;
            try
            {
                switch (numberOfPeopleCommand.ProcessType)
                {
                    case ProcessType.ContactCreated:
                        var numberOfPeopleRow = await _numberOfPeopleCollection.Find(x => x.ContactId == numberOfPeopleCommand.ContactId).FirstOrDefaultAsync();
                        if (numberOfPeopleRow != null)
                        {
                            numberOfPeopleRow.ContactId = numberOfPeopleCommand.ContactId;
                            numberOfPeopleRow.LocationId = numberOfPeopleCommand.LocationId;
                            await _numberOfPeopleCollection.FindOneAndReplaceAsync(x => x.ContactId == numberOfPeopleCommand.ContactId, numberOfPeopleRow);
                        }
                        else
                        {
                            var numberOfPeople = new NumberOfPeople
                            {
                                ContactId = numberOfPeopleCommand.ContactId,
                                LocationId = numberOfPeopleCommand.LocationId
                            };
                            await _numberOfPeopleCollection.InsertOneAsync(numberOfPeople);
                        }
                        result = true;
                        break;
                    case ProcessType.ContactDeleted:
                        var deletedNumberOf = await _numberOfPeopleCollection.FindOneAndDeleteAsync(x => x.ContactId == numberOfPeopleCommand.ContactId.ToLower());
                        if (deletedNumberOf != null)
                            result = true;
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {

                result = false;

            }

            return result;
        }
    }
}