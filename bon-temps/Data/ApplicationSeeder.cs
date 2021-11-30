using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using bon_temps.Models;

namespace bon_temps.Data
{
    public class ApplicationSeeder
    {
        private const string _password = "Password123!";

        private List<string> _roleNames = new List<string> { "Manager","Kok", "Ober", "Serveerster", "Klant", "Owner" };


        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        protected async Task SeedRoles()
        {
            foreach (var roleName in _roleNames)
            {
                var exists = await _roleManager.RoleExistsAsync(roleName);
                if (!exists)
                {
                    IdentityRole role = new IdentityRole { Name = roleName };
                    await _roleManager.CreateAsync(role);
                }
            }
        }
        public async Task Seedusers()
        {
            await SeedRoles();

            var owner = new ApplicationUser
            {
                Email = "ralf@bontemps.com",
                Voornaam = "Ralf",
                Tussenvoegsel = "",
                Achternaam = "Goedertijd",
                EmailConfirmed = true,
            };
            var user = await _userManager.FindByEmailAsync(owner.Email);
            if (user == null)
            {
                owner.UserName = owner.Email;
                var result = await _userManager.CreateAsync(owner, _password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(owner, "Owner");
                }
            }
            var owner2 = new ApplicationUser
            {
                Email = "henry@bontemps.com",
                Voornaam = "Henry",
                Tussenvoegsel = "",
                Achternaam = "Goedertijd",
                EmailConfirmed = true,
            };
            var user2 = await _userManager.FindByEmailAsync(owner2.Email);
            if (user2 == null)
            {
                owner2.UserName = owner2.Email;
                var result = await _userManager.CreateAsync(owner2, _password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(owner2, "Owner");
                }
            }
            var manager = new ApplicationUser
            {
                Email = "carla@bontemps.com",
                Voornaam = "Carla",
                Tussenvoegsel = "de",
                Achternaam = "Breij",
                EmailConfirmed = true,
            };
            var user3 = await _userManager.FindByEmailAsync(manager.Email);
            if (user3 == null)
            {
                manager.UserName = manager.Email;
                var result = await _userManager.CreateAsync(manager, _password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(manager, "Manager");
                }
            }
            var kok = new ApplicationUser
            {
                Email = "zouhair@bontemps.com",
                Voornaam = "Zouhair",
                Tussenvoegsel = "",
                Achternaam = "Binaissa",
                EmailConfirmed = true,
            };
            var user4 = await _userManager.FindByEmailAsync(kok.Email);
            if (user4 == null)
            {
                kok.UserName = kok.Email;
                var result = await _userManager.CreateAsync(kok, _password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(kok, "Kok");
                }
            }
            var serveerster = new ApplicationUser
            {
                Email = "emma@bontemps.com",
                Voornaam = "Emma",
                Tussenvoegsel = "",
                Achternaam = "Pontius",
                EmailConfirmed = true,
            };
            var user5 = await _userManager.FindByEmailAsync(serveerster.Email);
            if (user5 == null)
            {
                serveerster.UserName = serveerster.Email;
                var result = await _userManager.CreateAsync(serveerster, _password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(serveerster, "Serveerster");
                }
            }

        }
    }
}
