using Microsoft.VisualStudio.TestTools.UnitTesting;
using People.Data.Entities;
using People.Models.Profiles;
using FluentAssertions;
using System.Linq;
using AutoMapper.QueryableExtensions;
using System.Data.Entity;
using System.Collections.Generic;
using AutoMapper;

namespace People.Models.UnitTest
{
    [TestClass]
    public class ClientProfileTests
    {
        [TestMethod]
        public void ProfileValid()
        {
            var config = TestHelper.MapperConfigFor<ClientProfile>();
            config.AssertConfigurationIsValid();
        }
        [TestMethod]
        public void ToClientListItem()
        {
            var client = CreateClient();

            var sut = TestHelper.MapperFor<ClientProfile>();

            var result = sut.Map<ClientListItem>(client);

            result.Code.Should().Equals(client.Code);
            result.FullName.Should().Equals(client.FullName());
            result.Id.Should().Equals(client.Id);
        }
        [TestMethod]
        public void ProjectToClientListItem()
        {
            var client = CreateClient();
            var clients = new[] { client }.AsQueryable();

            var cfg = TestHelper.MapperConfigFor<ClientProfile>();
            var result = clients.ProjectTo<ClientListItem>(cfg).ToArray();
            result.Count().Equals(1);
            result.First().Code.Should().Equals(client.Code);
            result.First().FullName.Should().Equals(client.FullName());
            result.First().Id.Should().Equals(client.Id);
        }

        [TestMethod]
        public void ToMeetingItem()
        {
            var date = TestHelper.DefaultDateTime.AddHours(15);
            var meeting = new Meeting
            {
                Id = 1,
                ActualEndTime = null,
                Agent = new Agent
                {
                    Id = 2,
                    FirstName = "Agent",
                    LastName = "Coulson"
                },
                AgentId = 2,
                ClientId = 3,
                Client = new Client
                {
                    FirstName = "Tony",
                    MiddleName = "Edward",
                    LastName = "Stark"
                }
                ,
                DateTime = date,
                ExpectedEndTime = date.AddHours(1),
                Location = new Location
                {
                    Name = "Avenger Tower"
                }
            };
            var sut = TestHelper.MapperFor<ClientProfile>();

            var result = sut.Map<MeetingListItem>(meeting);
            result.Date.Should().Equals(meeting.DateTime.Date.ToString());
            result.Time.Should().Equals(meeting.DateTime.TimeOfDay.ToString());
            result.Id.Should().Equals(meeting.Id);
            result.Location.Should().Equals(meeting.Location.Name);
            result.AgentName.Should().Equals(meeting.Agent.FullName());
        }

        private Agent CreateAgent()
        {
            return new Agent
            {
                Id = 2,
                FirstName = "Agent",
                LastName = "Coulson"
            };
        }

        private Client CreateClient()
        {
            return new Client
            {
                BirthDate = TestHelper.DefaultDateTimeUtc.AddYears(-40),
                Code = "LEFT-WING",
                Email = "tone.start@avenger.com",
                FirstName = "Tony",
                Gender = Data.Enums.Gender.Man,
                Id = 1,
                MiddleName = "Edward",
                LastName = "Stark",
                Since = TestHelper.DefaultDateTimeUtc.AddYears(-5),
                Meetings = new List<Meeting>()
            };

        }

        private Location CreateLocation()
        {
            return new Location
            {
                Id = 1,
                Name = "Stark Tower"
            };
        }

        [TestMethod]
        public void ToClientDetail()
        {
            var agent = CreateAgent();
            var client = CreateClient();

            client.Meetings.Add(new Meeting
            {
                DateTime = TestHelper.DefaultDateTime.AddHours(13),
                Agent = agent,
                AgentId = agent.Id,
                Location = CreateLocation(),
            });
            client.Meetings.Add(new Meeting
            {
                DateTime = TestHelper.DefaultDateTime.AddHours(13).AddDays(1),
                Agent = agent,
                AgentId = agent.Id,
                Location = CreateLocation(),

            });

            var sut = TestHelper.MapperFor<ClientProfile>();

            var result = sut.Map<ClientDetail>(client);

            result.Code.Should().Equals(client.Code);
            result.FullName.Should().Equals(client.FullName());
            result.Id.Should().Equals(client.Id);
            result.BirthDate.Should().Equals(client.BirthDate);
            result.Email.Should().Equals(client.Email);
            result.Gender.Should().Equals(client.Gender);
            result.Meetings.Count.Should().Equals(client.Meetings.Count);
        }

        [TestMethod]
        public void ProjectToArray()
        {
            var client = CreateClient();
            var cfg = TestHelper.MapperConfigFor<ClientProfile>();

            var array = new[] { client }.AsQueryable().ProjectToArray<ClientListItem>(cfg);

            array.Length.Should().Equals(1);
        }
    }
}
