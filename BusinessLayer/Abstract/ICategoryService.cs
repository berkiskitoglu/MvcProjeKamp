﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        void CategoryAdd(Category category);
        Category GetByID(int id);

        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
    }
}
