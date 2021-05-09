using AutoMapper;
using People.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace People.Models.UnitTest
{
    public static class TestHelper
    {
        public static DateTime DefaultDateTimeUtc => new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime DefaultDateTime => DefaultDateTimeUtc.ToLocalTime();

        public static IMapper MapperFor<T>() where T : Profile, new()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<T>());
            cfg.CompileMappings();
            return cfg.CreateMapper();
        }
        public static MapperConfiguration MapperConfigFor<T>() where T : Profile, new()
        {
            return new MapperConfiguration(cfg => { 
                cfg.AddMaps(typeof(T).Assembly);
            });
        }


        public static string FullName(this IPerson person)
        {
            var list = new List<string>
            {
                person.FirstName,
                person.LastName
            };
            if (!string.IsNullOrEmpty(person.MiddleName))
                list.Insert(1, person.MiddleName);
            return string.Join(" ", list);
        }

        public static string DefaultUsername => "SYSTEM";

    }
}
