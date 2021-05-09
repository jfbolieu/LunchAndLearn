using AutoMapper;
using People.Data.Interfaces;
using People.Models.Interfaces;

namespace People.Models.Profiles
{
    public class FullnamValueConverter<TPerson> : IValueConverter<TPerson, string>
        where TPerson : IPerson
    {
        public string Convert(TPerson sourceMember, ResolutionContext context)
        {
            return string.IsNullOrEmpty(sourceMember.MiddleName) ?
                sourceMember.FirstName + " " + sourceMember.MiddleName + " " + sourceMember.LastName :
                sourceMember.FirstName + " " + sourceMember.LastName;

        }
    }

    public class FullnamValueResolver<TPerson, TModel> : IValueResolver<TPerson, TModel, string>, IMemberValueResolver<TPerson, TModel, TPerson, string>
     where TPerson : IPerson, new()
       where TModel : IWithFullName, new()
    {
        public string Resolve(TPerson source, TModel destination, string destMember, ResolutionContext context)
        {
           return string.IsNullOrEmpty(source.MiddleName) ?
                   source.FirstName + " " + source.MiddleName + " " + source.LastName :
                   source.FirstName + " " + source.LastName;
        }

        public string Resolve(TPerson source, TModel destination, TPerson sourceMember, string destMember, ResolutionContext context)
        {
           return string.IsNullOrEmpty(source.MiddleName) ?
                   source.FirstName + " " + source.MiddleName + " " + source.LastName :
                   source.FirstName + " " + source.LastName;
        }
    }
}
