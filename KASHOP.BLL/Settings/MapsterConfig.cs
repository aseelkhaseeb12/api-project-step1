using KASHOP.DAL.DTO.Requests;
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
            TypeAdapterConfig<Product, ProductResponse>.NewConfig()
                .Map(
                    dest => dest.Name, src => src.Translations
                    .Where(t => t.Language == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)
                    .Select(t => t.Name).FirstOrDefault()
                )
                .Map(
                    dest => dest.Description, src => src.Translations
                    .Where(t => t.Language == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)
                    .Select(t => t.Description).FirstOrDefault()
                )
                .Map(
                    dest => dest.MainImageUrl, src => $"/images/{src.MainImage}"
                )
                .Map(
                    dest => dest.CategoryName, src => src.Category.Translations
                    .Where(t => t.Language == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)
                    .Select(t => t.Name).FirstOrDefault()
                )
                ;
            TypeAdapterConfig<ProductRequest, Product>.NewConfig()
                .Ignore(dest => dest.MainImage);
        }
    }
}
