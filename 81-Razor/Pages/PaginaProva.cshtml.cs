using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _81_Razor.Pages
{
    public class PaginaProva : PageModel
    {
        private readonly ILogger<PaginaProva> _logger;

        public PaginaProva(ILogger<PaginaProva> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}