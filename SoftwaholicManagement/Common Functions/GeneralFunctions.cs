using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMDataLayer.Models;

namespace SM.Common_Functions
{
    public static class GeneralFunctions
    {
        public static void NavigateToIntroForm(ClothingStoreContext _dbContext, Form currentForm)
        {
            IntroForm introForm = new IntroForm(_dbContext);
            introForm.Show();
            currentForm.Hide();
        }
    }
}
