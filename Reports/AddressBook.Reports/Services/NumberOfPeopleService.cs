using AddressBook.Reports.Models;
using AddressBook.Reports.Services.Interfaces;
using AddressBook.Reports.Settings;
using AddressBook.Shared.Messages;
using AddressBook.Shared.ViewModel;
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

        public async Task<NumberOfSomethingViewModel> GetNumberOfSomethingInfo()
        {
            var result = await _numberOfPeopleCollection.Find(x => true).ToListAsync();

            var numberOfPeoples = result.GroupBy(x => x.LocationId).Select(x => new NumberOfPeopleViewModel
            {
                LocationId = x.Key,
                Count = x.Count()
            }).ToList();

            var numberOfPhoneNumbers = result.Where(x => !string.IsNullOrEmpty(x.PhoneNumber)).GroupBy(x => x.LocationId).Select(x => new NumberOfPhoneNumberViewModel
            {
                LocationId = x.Key,
                Count = x.Count()
            }).ToList();

            var response = new NumberOfSomethingViewModel
            {
                NumberOfPeople = numberOfPeoples,
                NumberOfPhoneNumber = numberOfPhoneNumbers
            };
            return response;
        }

        public async Task Update(NumberOfPeopleAtThatLocationCommand numberOfPeopleCommand)
        {
            try
            {
                //:TODO Çok fazla kod tekrarı var. Zaman kalırsa Düzeltilecek. 
                switch (numberOfPeopleCommand.ProcessType)
                {
                    case ProcessType.ContactCreated:
                        var numberOfPeople = new NumberOfPeople
                        {
                            ContactId = numberOfPeopleCommand.ContactId,
                            LocationId = numberOfPeopleCommand.LocationId,
                            PhoneNumber = numberOfPeopleCommand.PhoneNumber
                        };
                        await _numberOfPeopleCollection.InsertOneAsync(numberOfPeople);
                        break;
                    case ProcessType.ContactDeleted:
                        var deletedNumberOf = await _numberOfPeopleCollection.FindOneAndDeleteAsync(x => x.ContactId == numberOfPeopleCommand.ContactId.ToLower());
                        break;
                    case ProcessType.ContactInfoUpdated:
                        var numberOfPeopleRow = await _numberOfPeopleCollection.Find(x => x.ContactId == numberOfPeopleCommand.ContactId).FirstOrDefaultAsync();
                        if (numberOfPeopleRow != null)
                        {
                            numberOfPeopleRow.ContactId = numberOfPeopleCommand.ContactId;
                            numberOfPeopleRow.LocationId = numberOfPeopleCommand.LocationId;
                            numberOfPeopleRow.PhoneNumber = numberOfPeopleCommand.PhoneNumber;
                            await _numberOfPeopleCollection.FindOneAndReplaceAsync(x => x.ContactId == numberOfPeopleCommand.ContactId, numberOfPeopleRow);
                        }
                        else
                        {
                            var numberOfPeople3 = new NumberOfPeople
                            {
                                ContactId = numberOfPeopleCommand.ContactId,
                                LocationId = numberOfPeopleCommand.LocationId,
                                PhoneNumber = numberOfPeopleCommand.PhoneNumber
                            };
                            await _numberOfPeopleCollection.InsertOneAsync(numberOfPeople3);
                        }
                        break;
                    case ProcessType.ContactInfoDeleted:
                        var deletedNumberOf2 = await _numberOfPeopleCollection.FindOneAndDeleteAsync(x => x.ContactId == numberOfPeopleCommand.ContactId.ToLower());
                        break;
                    case ProcessType.ContactInfoCreated:
                        var numberOfPeople2 = new NumberOfPeople
                        {
                            ContactId = numberOfPeopleCommand.ContactId,
                            LocationId = numberOfPeopleCommand.LocationId,
                            PhoneNumber = numberOfPeopleCommand.PhoneNumber
                        };
                        await _numberOfPeopleCollection.InsertOneAsync(numberOfPeople2);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}