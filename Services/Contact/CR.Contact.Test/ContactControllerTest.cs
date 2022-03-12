using CR.Contact.Application.Commands.Create;
using CR.Contact.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace CR.Contact.Test
{
    public class ContactControllerTest
    {
        private readonly ContactController _ContactController;

        [Fact]
        public async Task ContactController_ActionExecutes_ReturnsViewForList()
        {
            var result = await _ContactController.GetAllContacts();

        }

        public async Task ContactController_ActionExecutes_ReturnsViewForCreateContact(ContactCreate ContactCreate)
        {

            var result = await _ContactController.CreateContact(ContactCreate);

        }
    }
}