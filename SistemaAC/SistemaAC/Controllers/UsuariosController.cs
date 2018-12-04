using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaAC.Data;
using SistemaAC.Models;

namespace SistemaAC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUser.ToListAsync());
        }

        public async Task<List<ApplicationUser>> GetUsuario(string id)
        {
            List<ApplicationUser> usuario = new List<ApplicationUser>();
            var appUsuario = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            usuario.Add(appUsuario);
            return usuario;
        }

        public async Task<string> EditUsuario(string id, string userName, string email, string phoneNumber, int accessFailedCount, string concurrencyStamp, bool emailComfirmed, bool lockoutEnabled, DateTimeOffset lockoutEnd, string normalizedEmail, string normalizedUserName, string passwordHash, bool phoneNumberConfirmed, string securityStamp, bool twoFactoryEnable, ApplicationUser applicationUser)
        {
            var resp = "";
            try
            {
                applicationUser = new ApplicationUser
                {
                    Id = id,
                    UserName = userName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    EmailConfirmed = emailComfirmed,
                    LockoutEnabled = lockoutEnabled,
                    LockoutEnd = lockoutEnd,
                    NormalizedEmail = normalizedEmail,
                    NormalizedUserName = normalizedUserName,
                    SecurityStamp = securityStamp,
                    TwoFactorEnabled = twoFactoryEnable,
                    AccessFailedCount = accessFailedCount,
                    ConcurrencyStamp = concurrencyStamp,
                };

                _context.Update(applicationUser);
                await _context.SaveChangesAsync();
                resp = "Save";
            }
            catch
            {
                resp = "No Save";
            }

            return resp;
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
