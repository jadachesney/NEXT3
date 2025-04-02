using NEXTGroup3.Data;
using NEXTGroup3.Models;

namespace NEXTGroup3.Services
{
  public class CookieService
  {
    private readonly AzureContext context;
    public bool CookieConsented { get; set; } = false;

    // TRACKS IF COOKIE HAS BEEN CONSENTED TO BY THE USER AND SAVES THE STATE
    public CookieService(AzureContext c)
    {
      context = c;
    }
    public void ConsentCookie()
    {
      CookieConsented = true;
    }
  }
}
