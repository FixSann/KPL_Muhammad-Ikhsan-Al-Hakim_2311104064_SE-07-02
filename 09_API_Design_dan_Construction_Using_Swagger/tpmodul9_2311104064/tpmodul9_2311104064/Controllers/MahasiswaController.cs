using Microsoft.AspNetCore.Mvc;
using tpmodul9_2311104064.Models;

namespace tpmodul9_2311104064.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MahasiswaController : ControllerBase
{
    private static List<Mahasiswa> daftarMahasiswa = new()
    {
        new Mahasiswa { Nama = "Muhammad", Nim = "2311" },
        new Mahasiswa { Nama = "Ikhsan", Nim = "104" },
        new Mahasiswa { Nama = "Al-Hakim", Nim = "064" }

    };

    [HttpGet]
    public ActionResult<List<Mahasiswa>> GetAll() => daftarMahasiswa;

    [HttpGet("{index}")]
    public ActionResult<Mahasiswa> GetByIndex(int index)
    {
        if (index < 0 || index >= daftarMahasiswa.Count) return NotFound();
        return daftarMahasiswa[index];
    }

    [HttpPost]
    public IActionResult Add([FromBody] Mahasiswa mhs)
    {
        daftarMahasiswa.Add(mhs);
        return Ok("Mahasiswa ditambahkan.");
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        if (index < 0 || index >= daftarMahasiswa.Count) return NotFound();
        daftarMahasiswa.RemoveAt(index);
        return Ok("Mahasiswa dihapus.");
    }
}
