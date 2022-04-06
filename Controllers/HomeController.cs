using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestPostfix.DB;
using TestPostfix.Models;
using TestPostfix.DAL;
using TestPostfix.DBContext;
using TestPostfix.DBModels;


namespace TestPostfix.Controllers
{
    public class HomeController : Controller
    {


        private readonly IDomainRepository _domainRepository;
        private readonly IAliasRepository _aliasRepository;
        private readonly IMailRepository _mailRepository;
        public HomeController(IDomainRepository domainRepository, IAliasRepository aliasRepository, IMailRepository mailRepository)
        {

            _domainRepository = domainRepository;
            _aliasRepository = aliasRepository;
            _mailRepository = mailRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DomainList()
        {
            var dom = _domainRepository.DomainList();
            dom = dom.OrderBy(d => d.Id);
            return View(dom);
        }

        public IActionResult AliasList()
        {
            var al = _aliasRepository.AliasList();
            al = al.OrderBy(a => a.Id);
            return View(al);
        }
        [HttpGet]
        public IActionResult DomainAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DomainAdd(Domain domain)
        {
            ViewData["Mess"] = _domainRepository.DomainAdded(domain);
            return View("Answer");
        }
        [HttpGet]
        public IActionResult Answer(string answer)
        {
            return View(answer);
        }


        [HttpGet]
        public IActionResult DomainEdit(int id)
        {
            Domain domain = _domainRepository.DomainGet(id);
            if (domain.DError == null) { return View(domain); }
            else
            {
                ViewData["Mess"] = "Error";
                return View("Answer");
            }
        }

        [HttpPost]
        public IActionResult DomainEdit(Domain domain)
        {
            ViewData["Mess"] = _domainRepository.DomainEdit(domain);
            return View("Answer");
        }

        [HttpGet]
        [ActionName("DomainDelete")]
        public IActionResult ConfirmDomainDelete(int id)
        {
            Domain domain = _domainRepository.DomainGet(id);
            if (domain != null) return View(domain);
            else
            {

                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult DomainDelete(int id)
        {
            ViewData["Mess"] = _domainRepository.DomainDel(id);
            return View("Answer");
        }

        [HttpGet]
        public IActionResult AliasAdd()
        {
            ViewBag.Domains = _domainRepository.DomainList();
            return View();
        }

        [HttpPost]
        public IActionResult AliasAdd(Alias alias)
        {
            ViewData["Mess"] = _aliasRepository.AddAlias(alias);
            return View("Answer");
        }

        [HttpGet]
        public IActionResult AliasEdit(int id)
        {
            var alias = _aliasRepository.GetAlias(id);
            if (alias.AError == null)
            {
                ViewBag.Domains = _domainRepository.DomainList();
                return View(alias);
            }
            else
            {
                ViewData["Mess"] = alias.AError;
                return View("Answer");
            }
        }

        [HttpPost]
        public IActionResult AliasEdit(Alias alias)
        {
            ViewData["Mess"] = _aliasRepository.EditAlias(alias);
            return View("Answer");
        }

        [HttpGet]
        [ActionName("AliasDelete")]
        public IActionResult ConfirmAliasDelete(int id)
        {
            Alias alias = _aliasRepository.GetAlias(id);
            if (alias != null) return View(alias);
            else return View("Error");
        }
        [HttpPost]
        public IActionResult AliasDelete(int id)
        {
            ViewData["Mess"] = _aliasRepository.DelAlias(id);
            return View("Answer");
        }
        public IActionResult MailboxList()
        {
            var mlist = _mailRepository.ListMailbox();
            mlist = mlist.OrderBy(m => m.Id);
            return View(mlist);
        }
        [HttpGet]
        public IActionResult MailboxAdd()
        {
            ViewBag.Domains = _domainRepository.DomainList();
            return View();
        }
        [HttpPost]
        public IActionResult MailboxAdd(Mailbox mailbox)
        {
            ViewData["Mess"] = _mailRepository.AddMail(mailbox);
            return View("Answer");
        }
        [HttpGet]
        public IActionResult MailboxEdit(int id)
        {
            Mailbox mail = _mailRepository.GetMailbox(id);
            if (mail.MError == null)
            {
                ViewBag.Domains = _domainRepository.DomainList();
                return View(mail);
            }
            else
            {
                ViewData["Mess"] = mail.MError;
                return View("Answer");
            }
        }
        [HttpPost]
        public IActionResult MailboxEdit(Mailbox mailbox)
        {
            ViewData["Mess"] = _mailRepository.EditMail(mailbox);
            return View("Answer");
        }

        [HttpGet]
        [ActionName("MailboxDelete")]
        public IActionResult ConfirmMailboxDelete(int id)
        {
            Mailbox mailbox = _mailRepository.GetMailbox(id);
            return View(mailbox);
        }

        [HttpPost]
        public IActionResult MailboxDelete(int id)
        {
            ViewData["Mess"] = _mailRepository.DelMail(id);
            return View("Answer");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
