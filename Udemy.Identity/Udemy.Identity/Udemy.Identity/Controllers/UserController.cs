﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Identity.Context;
using Udemy.Identity.Entities;
using Udemy.Identity.Models;

namespace Udemy.Identity.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UdemyContext _context;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, UdemyContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //var query = _userManager.Users;
            //var users = _context.Users.Join(_context.UserRoles, user => user.Id, userRole => userRole.UserId, (user, userRole) => new
            //{
            //    user,
            //    userRole
            //}).Join(_context.Roles, two => two.userRole.RoleId, role => role.Id, (two, role) => new { two.user, two.userRole, role }).Where(x =>
            //x.role.Name != "Admin").Select(x => new AppUser
            //{
            //    Id = x.user.Id,
            //    AccessFailedCount = x.user.AccessFailedCount,
            //    ConcurrencyStamp = x.user.ConcurrencyStamp,
            //    Email = x.user.Email,
            //    EmailConfirmed = x.user.EmailConfirmed,
            //    Gender = x.user.Gender,
            //    ImagePath = x.user.ImagePath,
            //    LockoutEnabled = x.user.LockoutEnabled,
            //    LockoutEnd = x.user.LockoutEnd,
            //    NormalizedEmail = x.user.NormalizedEmail,
            //    NormalizedUserName = x.user.NormalizedUserName,
            //    PasswordHash = x.user.PasswordHash,
            //    PhoneNumber = x.user.UserName,
            //}).ToList();

            // var users = await _userManager.GetUsersInRoleAsync("Member");
            //return View(users);

            List<AppUser> filteredUsers = new List<AppUser>();
            var users = _userManager.Users.ToList();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (!roles.Contains("Admin"))
                    filteredUsers.Add(user);
            }
            return View(filteredUsers);
        }

        public IActionResult Create()
        {
            return View(new UserAdminCreateModel());
        }

        [HttpPost]

        public async Task<IActionResult> Create(UserAdminCreateModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Email = model.Email,
                    Gender = model.Gender,
                    UserName = model.Username
                };
                var result = await _userManager.CreateAsync(user, model.Username + "123");
                if(result.Succeeded)
                {
                    var memberRole = await _roleManager.FindByNameAsync("Member");
                    if (memberRole == null)
                    {
                        await _roleManager.CreateAsync(new()
                        {
                            Name = "Member",
                            CreatedTime = DateTime.Now,
                        });
                    }

                    await _userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Id == id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.ToList();

            RoleAssignSendModel model = new RoleAssignSendModel();

            List<RoleAssignListModel> list = new List<RoleAssignListModel>();

            foreach (var role in roles)
            {
                list.Add(new()
                {
                    Name = role.Name,
                    RoleId = role.Id,
                    Exist = userRoles.Contains(role.Name)
                });
            }
            model.Roles = list;
            model.UserId = id;

            return View(model);

        }

        [HttpPost]

        public async Task<IActionResult> AssignRole(RoleAssignSendModel model)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Id == model.UserId);

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in model.Roles)
            {
                if(role.Exist)
                {
                    if (!userRoles.Contains(role.Name))
                        await _userManager.AddToRoleAsync(user, role.Name);
                }
                else
                {
                    if (userRoles.Contains(role.Name))
                        await _userManager.RemoveFromRoleAsync(user, role.Name);

                }
            }
            return RedirectToAction("Index");
        }

    }
}
