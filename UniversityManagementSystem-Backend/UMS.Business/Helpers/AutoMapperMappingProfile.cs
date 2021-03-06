using System;
using AutoMapper;
using UMS.Core.Enums;
using UMS.Data;
using UMS.Data.Entities;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Dto;
using UMS.Dto.Student;
using UMS.Dto.Teacher;

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

            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

            CreateMap<StudentCourse, StudentCourseDto>();
            CreateMap<StudentCourseDto, StudentCourse>();

            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();

            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();

            CreateMap<OnlineCourse, OnlineCourseDto>();
            CreateMap<OnlineCourseDto, OnlineCourse>();

            CreateMap<OnsiteCourse, OnsiteCourseDto>();
            CreateMap<OnsiteCourseDto, OnsiteCourse>();

            CreateMap<StudentGrade, StudentGradeDto>();
            CreateMap<StudentGradeDto, StudentGrade>();

            CreateMap<UniversitySocialClub, UniversitySocialClubDto>();
            CreateMap<UniversitySocialClubDto, UniversitySocialClub>();

            CreateMap<ChatMessage, ChatMessageDto>();
            CreateMap<ChatMessageDto, ChatMessage>();

            CreateMap<CourseInstructor, CourseInstructorDto>();
            CreateMap<CourseInstructorDto, CourseInstructor>();

            CreateMap<University, UniversityDto>();
            CreateMap<UniversityDto, University>();

            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>(); 

            CreateMap<StudentsUniversitySocialClub, StudentsUniversitySocialClubDto>();
            CreateMap<StudentsUniversitySocialClubDto, StudentsUniversitySocialClub>();

            CreateMap<File, FileDto>();
            CreateMap<FileDto, File>();
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
