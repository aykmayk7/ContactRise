using CR.Contact.Application.Commands.Create;
using CR.Contact.Application.Responses;
using System.Collections;
using System.Collections.Generic;

namespace CR.Contact.Test
{
    public class DataHelper
    {
        public class CreateContactObj : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new ContactCreate()
                    {
                      Name = "Aykan",
                      Surname = "Surname",
                      Company = "RISE"
                    }
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class UpdateContactObj : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new ContactResponse()
                    {
                        Id = GetTestContactId(),
                        Name = "AYKAN",
                        Surname = "CESUR",
                        Company = "RISE"
                    }
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class DeleteContactObj : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new ContactResponse()
                    {
                        Id = GetTestContactId()
                                }
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public static string GetTestContactId()
        {
            return "507f1f77bcf86cd799439011";
        }

        public static string GetTestContact()
        {
            return "507f191e810c19729de860ea";
        }
    }
}
