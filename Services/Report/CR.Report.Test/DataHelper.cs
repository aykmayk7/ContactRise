using CR.Report.Application.Commands.Create;
using CR.Report.Application.Responses;
using System;
using System.Collections;
using System.Collections.Generic;
using static CR.Core.Enumerations;

namespace CR.Report.Test
{
    public class DataHelper
    {
        public class CreateReportObj : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new ReportCreate()
                    {
                      ReportName = "Deneme"
                    }
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class UpdateReportObj : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new ReportResponse()
                    {
                        Id = GetTestReportId(),
                        CompletedDate = DateTime.Now,
                        ReportDate= DateTime.Now.AddDays(-1),
                        ReportStatus = ReportStatusEnum.Ready,
                        ReportTarget = Guid.NewGuid().ToString()
                    }
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public static string GetTestReportId()
        {
            return "507f1f77bcf86cd799439011";
        }

        public static string GetTestReport()
        {
            return "507f191e810c19729de860ea";
        }
    }
}
