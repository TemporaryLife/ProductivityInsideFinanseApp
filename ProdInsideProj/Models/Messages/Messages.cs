using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdInsideProj.Models.Messages
{
    internal static class Messages
    {
        public static string InvalidSumOrNullTypeCategoryMessage { get; set; } = "Вы ввели некорректную сумму или оставили пустыми категорию или тип операции. " +
                                                                                  "\nЗаполните поля, введите целую положительную сумму до 1млн $.";

        public static string SuccessfulInputMessage { get; set; } = "Запись успешно добавлена";
    }
}
