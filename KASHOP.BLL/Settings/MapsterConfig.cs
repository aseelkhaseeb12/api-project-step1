using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using Mapster;
using System.Globalization;

namespace KASHOP.BLL.Settings
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Category, CategoryResponse>.NewConfig()
                .Map(
                    dest => dest.Name, src => src.Translations
                    .Where(t => t.Language == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)
                    .Select(t => t.Name).FirstOrDefault()
                );
        }
    }
}
