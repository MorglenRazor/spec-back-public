using Specification.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.Core.Models
{
    public class ResponsibleCatChapter
    {
        ResponsibleCatChapter(Guid respId, Guid empId, Guid categoryChapterId)
        {
            RespId = respId;
            EmpId = empId;
            CategoryChapterId = categoryChapterId;
        }

        ResponsibleCatChapter(Guid respId, Guid empId, Guid categoryChapterId, string rsn)
        {
            RespId = respId;
            EmpId = empId;
            RespShortName = rsn;
            CategoryChapterId = categoryChapterId;
        }

        ResponsibleCatChapter(Guid respId, Guid empId, Guid categoryChapterId, User userData)
        {
            RespId = respId;
            EmpId = empId;
            UserData = userData;
            CategoryChapterId = categoryChapterId;
        }

        public static ResponsibleCatChapter Create(Guid respId, Guid empId, Guid categoryChapterId)
        {
            ResponsibleCatChapter rspChap = new ResponsibleCatChapter(respId, empId, categoryChapterId);
            return rspChap;
        }

        public static ResponsibleCatChapter Create(Guid respId, Guid empId, Guid categoryChapterId, string rsn)
        {
            ResponsibleCatChapter rspChap = new ResponsibleCatChapter(respId, empId, categoryChapterId, rsn);
            return rspChap;
        }

        public static ResponsibleCatChapter Create(Guid respId, Guid empId, Guid categoryChapterId, User userData)
        {
            ResponsibleCatChapter rspChap = new ResponsibleCatChapter(respId, empId, categoryChapterId, userData);
            return rspChap;
        }

        public Guid RespId { get; }
        public Guid EmpId { get; }
        public Guid CategoryChapterId { get; }
        public string RespShortName { get; } = string.Empty;
        public User UserData { get; set; } 
    }
}
