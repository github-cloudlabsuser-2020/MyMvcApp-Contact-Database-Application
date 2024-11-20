using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();


        // GET: User
     public ActionResult Index(string searchString)
    {
        var users = from u in userlist
                    select u;

        if (!String.IsNullOrEmpty(searchString))
        {
            users = users.Where(s => s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }

        return View(users.ToList());
    }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
                // Buscar el usuario por ID en la lista
    var user = userlist.FirstOrDefault(u => u.Id == id);
    
    // Si no se encuentra el usuario, devolver un resultado de no encontrado
    if (user == null)
    {
        return NotFound();
    }
    
    // Pasar el usuario a la vista
    return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            return View();
            
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Implement the Create method (POST) here
    if (ModelState.IsValid)
    {
        // Agregar el nuevo usuario a la lista
        userlist.Add(user);
        
        // Redirigir al índice después de crear el usuario
        return RedirectToAction("Index");
    }
    
    // Si el modelo no es válido, mostrar el formulario nuevamente con los errores
    return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            var user = userlist.FirstOrDefault(u => u.Id.Equals(id) );
    
    // If no user is found, return HttpNotFoundResult
    if (user == null)
    {
        return NotFound();
    }
    
    // Pass the user to the Edit view
    return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
           var existingUser = userlist.FirstOrDefault(u => u.Id == id);
    
    // If no user is found, return HttpNotFoundResult
    if (existingUser == null)
    {
        return NotFound();
    }
    
    // Update the user's information
    existingUser.Name = user.Name;
    existingUser.Email = user.Email;
    // Add other fields as necessary
    
    // If successful, redirect to the Index action
    return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            var user = userlist.FirstOrDefault(u => u.Id == id);
    
    // If no user is found, return HttpNotFoundResult
    if (user == null)
    {
        return NotFound();
    }
    
    // Pass the user to the Delete view
    return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            // Implement the Delete method (POST) here
          var user = userlist.FirstOrDefault(u => u.Id == id);
    
    // If no user is found, return HttpNotFoundResult
    if (user == null)
    {
        return NotFound();
    }
    
    // Remove the user from the userlist
    userlist.Remove(user);
    
    // If successful, redirect to the Index action
    return RedirectToAction("Index");
        }
}
