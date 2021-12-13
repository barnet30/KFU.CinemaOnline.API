﻿using System;
using System.Collections;
using System.Linq.Expressions;
using LinqKit;

namespace KFU.CinemaOnline.DAL
{
    public static class ExpressionStarterExtensions
    {
        public static ExpressionStarter<T> And<T>(this ExpressionStarter<T> self, object value,
            Expression<Func<T, bool>> exp)
        {
            if (CheckIfCanProcess(value)) self.And(exp);
            return self;
        }
        
        public static ExpressionStarter<T> Or<T>(this ExpressionStarter<T> self, object value,
            Expression<Func<T, bool>> exp)
        {
            if (CheckIfCanProcess(value)) self.Or(exp);
            return self;
        }

        /// <summary>
        /// Проверяет, не пустое ли переданное значение <paramref name="input"/>.
        /// </summary>
        /// <param name="input">Значение для проверки</param>
        /// <returns>FALSE, если значение <paramref name="input"/> это NULL, или пустая строка, или пустой список.</returns>
        private static bool CheckIfCanProcess(object input)
        {
            return input switch
            {
                null => false,
                string str => !string.IsNullOrWhiteSpace(str),
                IList list => list.Count > 0,
                _ => true
            };
        }
    }
}