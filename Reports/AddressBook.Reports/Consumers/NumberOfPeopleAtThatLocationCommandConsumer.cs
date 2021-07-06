using AddressBook.Reports.Services.Interfaces;
using AddressBook.Shared.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Reports.Consumers
{
    public class NumberOfPeopleAtThatLocationCommandConsumer : IConsumer<NumberOfPeopleAtThatLocationCommand>
    {
        private readonly INumberOfPeopleService _numberOfPeopleService;
        public NumberOfPeopleAtThatLocationCommandConsumer(INumberOfPeopleService numberOfPeopleService)
        {
            _numberOfPeopleService = numberOfPeopleService;
        }
        public async Task Consume(ConsumeContext<NumberOfPeopleAtThatLocationCommand> context)
        {
            await _numberOfPeopleService.Update(context.Message);
        }
    }
}
