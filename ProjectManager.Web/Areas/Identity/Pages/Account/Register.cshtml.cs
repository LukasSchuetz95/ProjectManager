﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Persistence;
using ProjectManager.Web.Models;
using ProjectManager.Web.Models.ViewModel.Employees;

namespace ProjectManager.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private IUnitOfWork _unitOfWork;
        private int resultId;
        private List<Department> departmentsList;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
            departmentsList = _unitOfWork.Departments.GetAll();
            DepartmentsSelect = new SelectList(departmentsList, nameof(Department.Id), nameof(Department.DeptName));
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public SelectList DepartmentsSelect { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Job { get; set; }

            //public SelectList Departments { get; set; }

            public int DepartmentId { get; set; }

        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                //Int32.TryParse(Input.Departments.DataValueField, out resultId);
                Employee employee = new Employee
                {
                    Firstname = Input.FirstName,
                    Lastname = Input.LastName,
                    Job = Input.Job,
                    //DepartmentId = resultId,
                    DepartmentId = Input.DepartmentId,
                    Status = Core.Enum.EmployeeStatusType.Beschäftigt
                };

                await _unitOfWork.Employees.AddAsync(employee);

                //_unitOfWork.Employees.Add(employee);

                //var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                var user = new ApplicationUser
                {
                    UserName = employee.ToString(),
                    Email = Input.Email,
                    EmployeeId = employee.Id
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                _userManager.AddToRoleAsync(user, "Member").GetAwaiter().GetResult();

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    RedirectToAction("CreateEmployee", "Employees");
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
