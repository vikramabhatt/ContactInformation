using ContactInformation.Business.Interface;
using ContactInformation.Business.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;

namespace ContactInforamtion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactManager _contactManager;

        public ContactInformationController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        [HttpGet]
        [Route("GetContact/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ContactModel> GetContactInformation(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                var contact = _contactManager.GetContactInformation(id);
                if (contact == null)
                {
                    return NotFound();
                }

                return Ok(contact);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Ok("Something went wrong. Please try again.");
            }
        }

        [HttpGet]
        [Route("GetContacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IList<ContactModel>> GetContactInformation()
        {
            try
            {
                var contacts = _contactManager.GetContactInformation();
                if (contacts == null)
                {
                    return NotFound();
                }

                return Ok(contacts);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Ok("Something went wrong. Please try again.");
            }
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> AddContactInformation(ContactModel contact)
        {
            try
            {
                var errorMessage = _contactManager.ValidateContact(contact, true);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    var id = _contactManager.AddContactInformation(contact);
                    return Ok($"Contact successfully added with Id: {id}");
                }
                else
                {
                    return ValidationProblem(new ValidationProblemDetails() { Detail = errorMessage });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Ok("Something went wrong. Please try again.");
            }
        }

        [HttpPut]
        [Route("Edit")]
        public ActionResult<string> EditContactInformation(ContactModel contact)
        {
            try
            {
                var errorMessage = _contactManager.ValidateContact(contact, false);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    var id = _contactManager.EditContactInformation(contact);
                    if (id > 0)
                    {
                        return Ok($"Contact successfully updated with Id: {id}");
                    }
                    else
                    {
                        return NotFound($"Contact not found.");
                    }
                }
                else
                {
                    return ValidationProblem(new ValidationProblemDetails() { Detail = errorMessage });
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Ok("Something went wrong. Please try again.");
            }
        }

        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> DeleteContactInformation(int id)
        {
            try
            {
                id = _contactManager.DeleteContactInformation(id);
                if (id > 0)
                {
                    return Ok($"Contact successfully deleted with Id: {id}");
                }
                else
                {
                    return NotFound($"Contact not found.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Ok("Something went wrong. Please try again.");
            }
        }
    }
}
