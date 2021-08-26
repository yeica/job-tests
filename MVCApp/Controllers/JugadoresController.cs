using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCApp.Data;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly DatabaseContext _context;

        public JugadoresController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Jugadores
        public async Task<IActionResult> Index(string statusOrder = "Todos")
        {
            ViewData["setActive"] = statusOrder;
            var databaseContext = _context.Jugadores.Include(j => j.Equipo).Include(j => j.Estado);
            List<Jugador> players = new List<Jugador> { };

            switch (statusOrder)
            {
                case "Activo":
                    await databaseContext.Where(j => j.Estado.NombreEstado == Estados.Activo).ForEachAsync(p => players.Add(p));
                    break;

                case "Cancelado":
                    await databaseContext.Where(j => j.Estado.NombreEstado == Estados.Cancelado).ForEachAsync(p => players.Add(p));
                    break;

                case "Agente Libre":
                    await databaseContext.Where(j => j.Estado.NombreEstado == Estados.AgenteLibre).ForEachAsync(p => players.Add(p));
                    break;

                default:
                    await databaseContext.ForEachAsync(p => players.Add(p));
                    break;
            }
            return View(players);
        }

        // GET: Jugadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores
                .Include(j => j.Equipo)
                .Include(j => j.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugadores/Create
        public IActionResult Create()
        {
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Nombre");
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "NombreEstado");
            return View();
        }

        // POST: Jugadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,FechaNacimiento,Pasaporte,Direccion,Sexo,EquipoId,EstadoId")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Id", jugador.EquipoId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Id", jugador.EstadoId);
            return View(jugador);
        }

        // GET: Jugadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Nombre", jugador.EquipoId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "NombreEstado", jugador.EstadoId);
            return View(jugador);
        }

        // POST: Jugadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,FechaNacimiento,Pasaporte,Direccion,Sexo,EquipoId,EstadoId")] Jugador jugador)
        {
            if (id != jugador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Id", jugador.EquipoId);
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Id", jugador.EstadoId);
            return View(jugador);
        }

        // GET: Jugadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores
                .Include(j => j.Equipo)
                .Include(j => j.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);
            _context.Jugadores.Remove(jugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugadores.Any(e => e.Id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
