using System;
using AutoMapper;
using UMS.Core.Enums;
using UMS.Data;
using UMS.Data.Entities;
using UMS.Dto;

namespace UMS.Business.Helpers
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap(typeof(BatchDto<>), typeof(BatchDto<>));

            // automapper needs this variable for this configuration, although it does not use its value at runtime
            Language language = Language.English;
            CreateMap<MultiString, string>()
               .ConvertUsing(r => r == null ? null : language == Language.Turkish ? r.Turkish : language == Language.English ? r.English : r.English);
            CreateMap<string, MultiString>()
                .ForMember(dest => dest.English, opt => opt.MapFrom((src, dst, _, context) =>
                {
                    Enum.TryParse(context.Options.Items["Language"].ToString(), out language);
                    return MapLanguageBoundString(src, dst, Language.English, language);
                }))
                .ForMember(dest => dest.Turkish, opt => opt.MapFrom((src, dst, _, context) =>
                {
                    Enum.TryParse(context.Options.Items["Language"].ToString(), out language);
                    return MapLanguageBoundString(src, dst, Language.Turkish, language);
                }));

            //CreateMap<Course, CourseDto>();
            //CreateMap<CourseDto, Course>();
        }

        private static string MapLanguageBoundString(string source, MultiString destination, Language destinationLanguage, Language sourceLanguage)
        {
            if (sourceLanguage == destinationLanguage)
                return source;

            return destinationLanguage switch
            {
                Language.English => destination.English,
                Language.Turkish => destination.Turkish,
                _ => throw new Exception("Language mapping is missing")
            };
        }
    }
}
