using AspWithVue.Data;
using AspWithVue.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspWithVue.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ContactsController : Controller
{
    private readonly AspDbContext dbContext;

    public ContactsController(AspDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
       return Ok( await  dbContext.Contacts.ToListAsync());
       
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetContactById([FromRoute]  Guid id)
    {
        var contact = await dbContext.Contacts.FindAsync(id);
        if (contact != null)
        {
            return Ok(contact);
        }

        return NotFound();

    }

    [HttpPost]
    public async Task<IActionResult> addContacts(AddContacts addContacts)
    {
        var contact = new Contact()
        {
            Id = Guid.NewGuid(),
            phone = addContacts.phone,
            FullNmae = addContacts.FullNmae,
            Email = addContacts.Email,
            Address = addContacts.Address
        };
        
        await dbContext.Contacts.AddAsync(contact);
        await dbContext.SaveChangesAsync();
        return Ok(contact);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateContacts([FromRoute] Guid id,UpdateContact updateContact )
    {
        var contactexist = await  dbContext.Contacts.FindAsync(id);
        
        if (contactexist != null)
        {
            contactexist.Address = updateContact.Address;
            contactexist.phone = updateContact.phone;
            contactexist.FullNmae = updateContact.FullNmae;
            contactexist.Email = updateContact.Email;

            await dbContext.SaveChangesAsync();
            return Ok(contactexist);
        }

        return NotFound();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
    {
        var deleteContact = await dbContext.Contacts.FindAsync(id);
        if (deleteContact != null)
        {
           dbContext.Remove(deleteContact);
           await dbContext.SaveChangesAsync();
           return Ok("Deleted");
        }
        return NotFound();
    }



}