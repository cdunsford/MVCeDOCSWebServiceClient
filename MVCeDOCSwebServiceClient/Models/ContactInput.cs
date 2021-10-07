using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCeDOCSwebServiceClient.Models
{
    public class ContactInput
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(100)]
        [Display(Order = 1, Name = "Your Name")]
        public virtual string ContactName { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(254)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please enter a properly formatted email address.")]
        [Display(Order = 2, Name = "Your Email Address")]
        public virtual string ContactEmail { get; set; }

        [Required(ErrorMessage = "Please choose a subject from the list.")]
        [StringLength(254)]
        [Display(Order = 3, Name = "What is your comment about?")]
        public virtual string Subject { get; set; }

        [Required(ErrorMessage = "Please enter your comment.")]
        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        [Display(Order = 4, Name = "Comment")]
        public virtual string Message { get; set; }

        public string currentSearchMode { get; set; }
        public string SelectedSearch { get; set; }

        public IEnumerable<SelectListItem> Subjects { get; set; }

        public ContactInput()
        {
            this.Subjects = GetSubjects();
        }

        public List<SelectListItem> GetSubjects()
        {
            List<string> options = new List<string>
            {
                "I could not find the document I wanted",
                "I received an error message",
                "My document did not display",
                "I don't know how to search for what I want",
                "I have a suggestion for improvement"
            };


            var selectList = new List<SelectListItem>();
            foreach (string o in options)
            {

                selectList.Add(new SelectListItem { Value = o, Text = o });

            }


            return selectList;
        }
    }
}