using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Сountries.Dates.Contexts;
using Сountries.Dates.Models;

namespace Сountries.Services.Classes
{
    public class LoadToDb
    {
        public CountryContext countryContext { get; set; } = new();
        public LoadToDb(CountryContext Contex) { countryContext = Contex; }

        public void LoadFronDb(int take)
        {
            DataBase.ClearAll();
            DataBase.AllFunck();

            //AddPosition();
            //AddPresident();
            //AddGovertment();

            //countryContext.SaveChanges();

            fromCountry(take);
            HeadOfState();
        }

        
       
        public void fromCountry(int take)
        {
            var context = countryContext.Countrys.Take(take);
            foreach (var country in context)
            {
                DataBase.Countries.Add(country);
            }
        }

        public void HeadOfState()
        {
            foreach (var item in countryContext.HeadOfStates)
            {
                DataBase.HeadOfStates.Add(item);
            }
        }
        public void ReturnThisCount(int skip, int take) 
        {
            if (take <= countryContext.Countrys.Include(c => c.HeadOfStates).Include(c => c.Government).Take(take).Count() )
            {
                var countries = countryContext.Countrys.Include(c => c.HeadOfStates).Include(c => c.Government).Skip(skip).Take(take);

                foreach (var country in countries)
                {
                    DataBase.Countries.Add(country);
                }
            }
        }
       

        public void  Filtration<T>(Func<Country, T> funck)
        {
            IEnumerable<Country> orderedCountry  = countryContext.Countrys.OrderBy(funck);
            DataBase.Countries.Clear();

            foreach (Country country in orderedCountry)
            {
                DataBase.Countries.Add(country);
            }
        }

        public void AddGovertment()
        {
            countryContext.Governments.Add(new Government() { GovernmentForm = "Парламентские монархии" });
            countryContext.Governments.Add(new Government() { GovernmentForm = "Дуалистические монархии" });
            countryContext.Governments.Add(new Government() { GovernmentForm = "Абсолютные монархии" });
            countryContext.Governments.Add(new Government() { GovernmentForm = "Диктатура" });
            countryContext.Governments.Add(new Government() { GovernmentForm = "Авторитаризм " });
            countryContext.Governments.Add(new Government() { GovernmentForm = "Тоталитаризм" });
            countryContext.Governments.Add(new Government() { GovernmentForm = "Смешанные республики" });
        }
        public void AddPosition()
        {
            countryContext.HeadOfStatePositions.Add(new HeadOfStatePosition() { Position = "Президент" });
            countryContext.HeadOfStatePositions.Add(new HeadOfStatePosition() { Position = "Император" });
            countryContext.HeadOfStatePositions.Add(new HeadOfStatePosition() { Position = "Король" });
            countryContext.HeadOfStatePositions.Add(new HeadOfStatePosition() { Position = "Королева" });
            countryContext.HeadOfStatePositions.Add(new HeadOfStatePosition() { Position = "Монах" });

        }
        public void AddPresident()
        {

            countryContext.HeadOfStates.Add(new HeadOfState
            {

                Name = "Чарльз",
                Surname = "Фили́пп",
                Patronymic = "Артур",
                BirthDate = DateTime.Parse("14/10/1948"),
                ImgLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e5/Prince_Charles_in_Aotearoa_%28cropped%29.jpg/375px-Prince_Charles_in_Aotearoa_%28cropped%29.jpg",
                Description = "Карл III",
                PositionId = countryContext.HeadOfStatePositions.Where(x => x.Position == "Император").First().Id,
                Position = countryContext.HeadOfStatePositions.Where(x => x.Position == "Император").First()

            });

            countryContext.HeadOfStates.Add(new HeadOfState
            {

                Name = "Ильхам",
                Surname = "Алиев",
                Patronymic = "Гейдар",
                BirthDate = DateTime.Parse("14/10/1961"),
                ImgLink = "data:image/jpeg;base64,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",
                Description = "Президент Азербайджана",
                PositionId = countryContext.HeadOfStatePositions.Where(x => x.Position == "Президент").First().Id,
                Position = countryContext.HeadOfStatePositions.Where(x => x.Position == "Президент").First()

            });

            countryContext.HeadOfStates.Add(new HeadOfState
            {

                Name = "Владимир",
                Surname = "Зеленьский",
                Patronymic = "Александович",
                BirthDate = DateTime.Parse("25/01/1978"),
                ImgLink = "https://www.president.gov.ua/storage/j-image-storage/33/93/85/576f2a99a8a999e9c732a25f01c6b850_1686396856_extra_large.jpeg",
                Description = "Президент Украины",
                PositionId = countryContext.HeadOfStatePositions.Where(x => x.Position == "Монах").First().Id,
                Position = countryContext.HeadOfStatePositions.Where(x => x.Position == "Монах").First()

            });

            countryContext.HeadOfStates.Add(new HeadOfState
            {

                Name = "Путин",
                Surname = "Владимор",
                Patronymic = "Владиморович",
                BirthDate = DateTime.Parse("24/5/1951"),
                ImgLink = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBYVFRgVFRUYGBgYGhgaGRgYGBgYGBoaHBgZGhgYGBgcIS4lHB4rIRgYJjgmKy8xNTU1GiQ7QDs0Py40NTEBDAwMEA8QHhISHjQrJSQ0NDQ0MTQ0NDQ0NDQ0NDQ0NDQ0MTQ0NDE0NDQ0NDQ0NDQ+NDQ0MTQ0NDQ0NDQ0NDQ0Mf/AABEIAMIBAwMBIgACEQEDEQH/xAAcAAABBQEBAQAAAAAAAAAAAAACAAEDBQYEBwj/xABJEAACAQIDBAYFCAcGBQUAAAABAgADEQQSIQUxQVEGImFxgZEHEzKhsRRCUmJygsHRIzNzkrLS8BY0U1ST8RUXJMLDZHSis+H/xAAaAQACAwEBAAAAAAAAAAAAAAAAAQIDBAUG/8QAJBEAAgICAgICAwEBAAAAAAAAAAECEQMSITEEQRNRBSIyYYH/2gAMAwEAAhEDEQA/AMoBCIhLaOyyYiOEDEISrEAlaSesMC0JRABzUMHKYTQlOkKAitCCxyI6mOiI1orQooUAEcQgkL1clqx2RkRrSTLFlj1YrI7RWkvq44pySxsLI8sWWS+riyyxYwsjyxwkIiKTUEKwCsZlkloxEk4oVnOywQJO4kYEoceR2OojOkmVY7JL1C0R2ONhBIk7rISJlnGmTTBIjEQ7QTKiQFoodooAdYwr2vlNoQw7/RM2legoAHbukWOCooMZHYxxw7fRMcUWtexmrwTo63tu0kz0UKG1u6AbGLtHCyaqtmPeY0KJEeWEBChIJKKIkYSGEkoWNllqgKyP1cWSShYYWSWMVkFoamBXcroFLE7gJcbI2NUYBnsvYRY+IlGXPHFx7LseGU+isI7D5RpucNgMo598g2j0fNRC1NVzCxtoGtx+149krh5sW6kic/FlFXZjSI6iG9EqbMLGILOjBKStGXrhgZYssktGMnqFkeWK0KNaOiLkCVglZJaMRBoLIGEC0nZYAWVOPIbBIIRkiLE1OXLorcjkqCQATpqJOdhMmZcl8GA0a0MrEomYsI7RSb1cUKA21XGKQN2+VW2MbnAUSNQLRNQBliiitFns0ItOTvXRUI98qQLC15xuxOlzaNY7YHLWN2J5kwAsmdZEYSjRJMG0NRGAkyCEEJiCGEscNDAvNMY/RBsaCZLkiIA1JsBvJv8AhJy4VsFy6Rd7Kwy5M5AutgDxvYlvfp4S6wdiAecoNm129WUYAHMSfwEt8HVVVu7KovpcgfGedzS2m2dnBHWJcKkkVcuoM5sPjEYXV1I7DceYkOJ2xRRghe7Hco1Mqoskys6Q4IFHcbwVbtsTkYdxJU+Ey9pvcSyMjqTdXVhcakacBzH4TCATt/j57Qcfo5PlR1lf2BaAwkxEVp0GZXIgtHtJcsYiRuiLkR2jESS0VoOQrIchO6Blmm2bs5SO0yLH7NAa4md5VtRKuCnpJJGE6/kZEFsIZbuiNMrKqTkZJbNhiYzYOVZGmWQbRUFZIlOWSYKPVwPKZHVmldFfpFJvkhikiNlk9JQIVMDiY725zirOeBmiMLKbOwqOcr6y6x1c84iZbHE12GxA14ssmdZGJXOFMakAFkiiJUkwWEIClIBUkypaHTUSUrNcMfBU5EaiPkB37uMcCPJzxqUWn7HGbi016OpEZCcxBLEnqiwHLxtaFW6PNUzEVEIt1Q6OR4lWU27oHrr7wBYDXnbie2WeztogDU3t5TyuWDxzcX2j0OOSyQtdM4di9G2oYhTmBRlN1AYLfeLAsTbQ8eMsBsBi1mqDISSwNNGZr3Is3zbGxuNZBR2+gqZ6pKJchCVOXLpY5t1yb6crS+THde1iUPstYjUbxrv4G/fIW7sbS6IcXh1pUWszEqjm7HUkqVF/EzGBZqOkOIOSw3OQD3DrfECZq07P46FY3L7Zx/Ol+6j9AEQTDIiyzdJmKyMiNaGwjWldBYNorRzFEBpNkVhlAJ4SLH4oA6cTKNKrLuMcVCx1MqePmye3BYvixB+Vgi04wBBKiTUVVCslGIF78oBxQHxkFQCQZbmEoKicLstBi1MJ8SsrWw1heQFGmbVM0uLR21K4uYpX6xSehXydDk3iIvOs0xHCCboyivRS0zjAiInZkEToLRfKm6oVezmVYhThERgTJSQlIYQrRgJMoijEUpAqLSRY9oaJL4qiDYyrHKStxm26aGyddvqmyjvbj4XlFtTbde3tZQbiyC3jm3yrJ5UI8dv/AAsjilI0K49TVekpF0QOw4+0A37oKk9jE/NM7MKo1C2udVB3Hs7p5vhcWyOKitZlOYE63JuCGB9oEEgg7wSOM22FL1qfynBjME/W4e93pN9X6dM2JB38NSDOF5UXkk5L2dXxsihHVlmcaw6lQYY6+y7Oh7CrZSDbummoV6rhSwp5Da+RyxB4MLqLiZjZ3SxQOvRs3MAH/eabZGN+WtkpgIBq+ozAAi5y8N48xMmkuqNjyRqzOdMduik6UwheylmIYKBfcNxubAnxEz9PpKnzkde4hvyj9MdmVcLi6xJco7lgWuwCuf0ZudCLDL2ZbTNu2uo17J08OSWOCin0cnLGM5OT9mtp7aoH5xHep/C86F2jSLBQ4u264IBPK5Fr9kwxW8NkuLE/1zly8iXuip4Ym+KQbSs6NY41aZVzdksO0jt7iCJasJri1KKaM0k4uiJhGUQzEBJahYDCBaSkQSItQTEoiaODETLVBBYFpIEgCT0qZmbO6RtwRsj6x0jE2Gs7hYSHEIDMMZW6Ns8aSuyutGnVlimi19GTUjJMQeM0YCdFmAkiiBhqsi0rFYEdTCIgWifA1yO0JTEsNVh7sdg4jFLSRnY2VRc23ngAO0mwmN2j0hqVtLBE+gpOo+u3zvh2Sy6b4jKlNL6MzMfugAD/AOd/CZJHExeTmltqnwaMMFWzLahXA7vf3SHENna+7l2TmRu2SMeMylwJp93hLboztd8FiErpcgdV0+mh9pT28QeBA7ZWLUF+w/GSxUB7T0swNKvgjicDhlrVK6qFdQAVVvadkJALgArqLhiL7jPLNiYhsPUFNg1Fyy56pzrUpsrmzBSbaIzC2XW/ntPRB0iyO2Cc9V8z0b8HAvUQfaAzAc1fnIvSnhlbEpe9hTyva1yGbQLfebX37rEyt8MvxU+Dcba2T8qw+TEKC4U2dPYqC17g8DcK1vq6aXt4JiaDI7I46y6G43i1wfEET37oBtlcVhVUgZ6P6N132t7DC+8Fba8ww4TC+mPYoSpTxKIFVlyVCoAGYElSQOOtvGNOmVNVwedqto5goYQMsIi2fjGouXXgdRwKtvB8RNzh6wdFddzAEX39xnn7jrd4I/EfjLnZ23/VIiMMygkNzCkk5l5m53dkvwZdXT6KckNla7NSRFJUIIDKQQQCCNxB3GMUnQMpETGkrJGRICRCY1pM6wlSPakTirOdN87FaQkayRNJkzLY6GB0gnQkXnK7HdO7OBI0AJmaP63aLpPZnF6topa5Fii+b/BfEVQELJI1MkDzrWcd2EqRxEHgM0QKw2iCwV1kiwY+hgsMCATECZEDP9NsNmppUtfIxU9zAWJ8VA+9Mik3/SKtlw1S4vcBfFmC38L38JgEEweSkp39mvC/1J0QHfBquUIvqPw/r4yRBIsY4Kdun+8zlpKUt3GSI0iwj3FjukyUSWyjzOgA4kngBrGB04B3SotRGyNTZXD/AESpBB7dbC3G9uM0u38V8o9XiS5Y1MxYWsEa/sKOAGU68bDsAy1SoLZV9kHedCzfSI+A4DtJv04PF2Q0zuLBlP0W3NpyIt+6O2QkrRbhlrNNmk6C7b+SY5CzWp17UqnIEn9G57mIF+AZp6l0+2OcThmVQSVuco4i2unOeF4imGFp7t0A22cXgkdjepT/AEdTmXUCzH7SlW+9IvonnjUrPnt0KMVbQqSp7xGtxmr9ImxWw+IZyrBKhNiRoSNRY7jp8JlkGuvlLE7RnYLqTrbdr+fuglFK8b3ueU6rC4tOFCo4sSPKMDb9GMQGohCeshJ+6xuPeT7pfAACeaUNpuhGQ2I5aE9h5zS7G22agZHK5wLrbS45Ht7pphnWtS9FLxvbj2aJqLZc+U5SbA8L8pFmAnWuLL4dV+tu03AW/EThZZd4+V5YbNUVeRiWOeqY7GM0WWODaXvohAKgkVVNdICPrOkJMmVuLs3YmmgSmkZKdtYSb5M6zNObXBoUbYKiKFFKLLaKhVj5ZIFjlZ27ODZFaGLRwkLKJKwsQtHAiyx1Ei2ISpO3A0gWsVB75zCdmAbrSnNJ6OiWN/sjW4XYGHqoBUw9JxobNcjxFrQNsdE8DTw9aouBw5ZKdRgFpqDdVJFjbQ6Sx2PU6onXt3EqmGru3srSqMe4IxM5ezb5OgqXR8t0iSBx+HfGbrXFvLURkJyhe6TEAJpzkwIsNQe5CjNYXsN9hvIG89wnXRqMcwuRfQi5AIBBsRx1UHwHKRISGDA2Nib9wvOtgUSi5CHOjPqNdKjoQx+dql/vQAgZD4wVe/4ySpWudAB5+7WWPR3YbY7EJQpHKxVmdyMyqqjVmAIO8qo7WEGxkSVbgX/rnNj6LttihjDRY2TEgLruFRblD2XBZe0lZTdJei7YBlpvXpuzjMAuYMBqLkEaA5Tx4Srp7PrllKU3LdVkZVJHAq4a1raA33SHBqb3iepelVFanlZuFxfXKb6EeNp4/e4B4jfPetn9J29TT9bSvVIAcXXKGsL3IvfW+6ecekTo+yV2xVKn+hqAO+S59W9usWFuqpte+65N7aXjGcbqyiUJVdGRpVgBrOCs4uRfidJOXWwO9ibAczyHPeJybSwlWk49bTemXUModSrFblc1jY2up8pbZWCte2gsO3lND0YdQXZrMAALEcyb/CZMGbTo1s7/AKf11ma7kMFBJIAARVUak3DnQbiLyrK/1Zbh/tGy2Zi6VQGiECMCShGgIbVdfC1jygOLSbC7SSnh2qPhmT1aMS1SmysSLkZcwBNzYac5zO+YKwFg6o4HIOocDwzW8Jf+PnKnF9ein8hGOykv+iSDUEdRaO86ZgiQIustARllaJJTr62lPkRcufo2YJUiYi0NnuIa9aEyCc2b5OjBJoiCxSW8UjZOmVIMK8YJHAnaPOiMGxkq07yUIBHYXQCCS5YLDlBzGRZHslCyXBDrjxlRj9s06Fg7HMRcKoJJG6/IbjvMj2X0mpvVRFRwWYKC2QDXnZjp+cpyTjq4tlsIStOj1nYrdURdNTbZ+M/9tX/+tpFsfRLmZHpv0pNRK2ERQoemxzswAIUgshvuzAMN85vs3o8XoUmbcIVjmyZgASAWIJA4Em2todXGPu0UfVGnmb3nMuupkgO1qQUMRVRwFIGUMCQWC3sRpvnftGgMmGBqIlqF8rK5PXrVnv1VIsbjjeUqWF9N4t7wfwnZjsStRaXVbPTTI7EgqwU9TKOFgTe8AArLlsFdHvf2VcWtuvmA39nLW02fo26V0MA1T11Jj60qDWXrMireylOK3LElTfUaGwmDtCuYPkDfdPOkQrY5WoeqrIaaIhIZgc4sVtcZTckWP0jcTYU9mJRuEGUMScq2VQSTeyjdw95njOCuHDgi6MrAE+0QwIFhv3X8Js8F0trO60a1MrVuQQQUI0ucyMLjQXlGaMnSRowyirbNzgcNZ7uRcaqCb/0ZdM/VbS5F+qdzaaiYjA7MxFdw+ZrKdAxKr3kAXOnObfB4Bl61Vw50IUCwUjjcnraHkJSsMmyx5o0FsXY9Cjmelh6dN2yszKi57sST1tSBqdBoOE829NGCLVcO43iiQba3Cuxvfj7V562pNyLi5NvJec819Ldw+Ebi1OuovuLA0mAPmZs6RjuzyGlSGZA91RiLta5y5rMyjjbXynoWzdpYLDqKabQr5VNwFpqQN50LAjifOU1PDI9JEdQbA7uBub5TwmdxuzWRrbxwPMfnItKXDLIycejfbVxi4pPVJXRaNw9SpUxFEuwU5gBTV8wF7HVb34TT4nZNVQD6lwmVQthmsoUBc2W9jYC955b0U6PvWxCF1tTR0ZywsGUMCVW/tEi8+g6OLJGbhz4X75Zil8L4RVmj8vbPOahMaxtPSa6U6g/SIj9rAX8G3iVWK6M0X9h2Q8vbXyOvvmuPlxfaoz/BJdGKpDWSV6HGW2J6MYhDdQKi80PW8UNj5Xle51ysCrDepBBHeDqJOeRNpxdlmKNKmh8M9pOz3gogtCQCYJu3Z0odCyxSS8UrLbZnqmORNGOW/O4/CX2zdnI6K7OwzjMAtvZPsm55jXxmS2rSDFL7uJ4gE6mXWJ6TW6tKkSBYAvoABoLKPzE2TlKMmkzjxjFq6NB/w6iv0z94fgJHVSggu4VRzd8vmSR8JiMVtjE1N7so5IMg8xr75WPTJN2vfiTv8zIbz+yWkfo3lXbeATTqsfqGq/vuBOKr0pw3zMMW+07L8GMx4SGKJ5HyhvL7YaR+i5xOIwlVi74amGa1/wBLXO4ADc4A3DcJA9PB50dESmyWIKM5FwbgkOWF9N4nAKJ+ifIxeqP0fdI9kjZ0umhVcoamb881/jK19qUKjhnRHe/VOeopB7CjCZ71J+ifIx8OlnXTjFqh2es4X0c7MqItQ4ZgXVXP6evvYZjc59TrvM5T6J9nZjb14H0RV0F9Ra4vpu3zb7J/UUv2dP8AhEkY9ZvD4SBIwo9E2z//AFH+r+Swf+Uuz/pYj/UX+Sb0GVOLr4hWcopZVIyDKCGutzexBsCQPfrARmP+Uuz/AKWI/wBRf5IZ9FOzrWy1+/1pv79PdNAMVirsfVi28BlNtLAoLNcm9+sd9tAAZYYJ3K3qAA30FrG1hv5m991oAUWxeguCwzB6dMsy6gu2frcGsdL/AAl/idm0qpVnRXZL5WZVLLoQcrWuNCd3OT3ktI6RMaOT/h6qCFFgeEhKgGxGoB07Dz7JaTmxTKqlmsAo1JIAA43JIAhYUVW09pph6BrkZltcBSAW8908T6adMm2gyKaK0hSLlOuXZs2XUtYD5o0A8Z6dtDpbsynSelVxFOql+qig1G11tZQbWPHSeBbVxKNUdqKsqZiVvvAvppwjTEaPo4nrT6rMA1ywB4g6tbmd5tNWmwFX2zccrfjPLqGNKsGuVZSCGU2II3EcjPQdj9LUqqBWYK40L3AVh9Ire69ulu0bgmvodl5TRaa2W+k0XR3aFyyE79R4e0PK3kZl2qK4DKwZeakEHxEKjiijKy71N/zHjrEBtsVmBzJqOKjeO0DiJDRx4PGPRxIdQ6nRgCP65yq2q+SqlQi6OQHHC+4+Y+BiJGlw9YsNNbcOPfOj1CVxldFccMwvbuO9e8GVWFpOtTq6px117Vmmwqi2YfO1/KHXQjM7Q6ICxNBsp+gxuvcG3jxvMriKDISrAqymxB4T1iecdKcQGxTr9DIvf1QT/Fbwkk2y7FJ3RT+sijeqijNVlHtVhmXuPxnEHnVtkWZO4/Gc9LDk79BNGX+mcjH/AChryX5IX7O+dFOkF3Dxk6mVkzjpYZV4a9slCCS1F4yO8AEQI6IDGJkg0iJDOZVIeuO+WTmVQexvyjIn0Jsn9RS/Z0/4RDb2m8PgJmthdMcGcPSz10RgiqysSGDKoB4ajTfOo9KsHmJ+UUze3zjytylXsmy7vK7aeMqIy5EDLkqO5I3BQuXXMLb9wDX7N84n6XYIb8TTH3j/ACwP7a4D/NUv3m/ljETVtq1V66qjqWTKqqwYozsGIbMQxKrcaDeJbYaoWRGO9lVj3lQT8ZRHpvgP81T82/li/ttgP8zT83/lgBoTJaW7zmdpdLcG5stdGJ4AOf8AslthNp03Fle5G+wbje28dhikCLASq6T0c+DxKDe1CsBzuabWI7by0Uzm2p+pq/s3/gMSJHyy4Z+s9ydN/KA+FB4eQ/ASKgTlHcPhJ0rWlpErXQ3tYjsO+NlMtlxDd/YdQfCBiKa+0Bl5jh3j8oqA4qFaohujMp5gkHzllR2/iV0z3+0AT5nWcTf1z/8AyD/X9GFAavZnT3E0lyFKTrcmxDg677EHd4cZbUvSQT7eGUj6rnwsGUzz2OrRaodnruzvSZhhcPTrLfiAjD+IH3TW7M9IezqnVGICHT9ar0x+8wy++fO14dMaxaoLPrHD10dQ6MrqdzKwZT3EaGeY7WYGvWPOo/uYgfCeW7K2pXwrh8PVdGvc5To3Y6+y47CDNtsXHnEoznRwxzgbrtrmHYdfIxqNE8b5LK8UH1RjwpGmymxg1UnfY/GRhoWLbUd0hBl2X+mc7H/KJgYQaRAwgZWSJc0hfSFeCTAkOnOEWggxCAAsZxLg2J4Ac5YgRiYwNn6OdiYerQqNUpK7CrbMwubZENu65M1/9mcH/lqf7olB6Lv7vV/bf+OnNreVSbsZmtrbDw9JUq06FNSjrchB7LXQg/vCdowtP/Cp/uJ+U69sU81CoPqkjvXrD3iceGfMinmAfdBMQXyWn/hp+4n5RfJ0/wANP3F/KHeK8QAikg3Ig7kX8pX4ZMtdwOJRh43/ABJllecVUWrA86f8Lj+aDA0KbpV9IMTkoVD9Rh5giWKNpKLpef8Apqv2YkM+ZqbdUdwg5oFFtISi5lojsw5h1zIKbayWu2l4wOVjb+t8Emac+j/aRswwbWIBHXpbraaZ7ic1foRtFNTgq33VD/wkxWgKC8YHlJ8XgatIgVqdSmTuD03QnuzAXgJaADA2kjNuHOQrqY4frE8tBADpz7zyt7tTL7ovjjTxCi/VcFDyvvU+Yt94zOE2Tvv752YRirIeKuh8iI0NOnZ6d8rEUr8hil3xxJ/Izixe8eMhEUUjk/plEP5QUIRRSsmOY0UUACENIooAMYzRRQA9D9Fv93rftv8Ax05toopVLsER1/Yb7LfCUey/1NP7I+EUUEM64oooCEZzYj21+y38SRooMC7p7hKLpZ/dqn2YookM+a8cgB0AGrbtOIkNOKKWoRJR3zopi9gdRfd94RoowPrKKKKUskZfp9QR8FVzqrWUEZgDY89Z80Uo8UlETAp7x4xl3HviikxHRX9keE6V3+P/AHCKKNAelxRRTWSP/9k=",
                Description = "Президент России",
                PositionId = countryContext.HeadOfStatePositions.Where(x => x.Position == "Король").First().Id,
                Position = countryContext.HeadOfStatePositions.Where(x => x.Position == "Король").First()

            });

            countryContext.HeadOfStates.Add(new HeadOfState
            {
                Name = "Е́ва",
                Surname = "Ка́талин",
                Patronymic = "Ве́решне-Но́вак",
                BirthDate = DateTime.Parse("6/9/1977"),
                ImgLink = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b0/Katalin_Nov%C3%A1k%2C_2023_%28cropped%29.jpg/375px-Katalin_Nov%C3%A1k%2C_2023_%28cropped%29.jpg",
                Description = "Красавица",
                PositionId = countryContext.HeadOfStatePositions.Where(x => x.Position == "Королева").First().Id,
                Position = countryContext.HeadOfStatePositions.Where(x => x.Position == "Королева").First()

            });
        }

    }
}
