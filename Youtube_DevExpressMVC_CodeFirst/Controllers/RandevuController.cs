using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.Mvc;
using System;
using System.Linq;
using System.Web.Mvc;

namespace YoutubeDevExpressMVC.Web.Controllers
{
    public class RandevuController : Controller
    {
        // GET: Randevu
        public ActionResult Index()
        {
            return View();
        }

        YoutubeDevExpressMVC.Web.Models.DbRandevu.NorthwindRevEntitiesRandevu appointmentContext = new YoutubeDevExpressMVC.Web.Models.DbRandevu.NorthwindRevEntitiesRandevu();
        object resourceContext = null;

        public ActionResult SchedulerRandevuPartial()
        {
            var appointments = appointmentContext.Randevus;
            System.Collections.IEnumerable resources = null; // Get resources from the context

            ViewData["Appointments"] = appointments.ToList();
            ViewData["Resources"] = resources;

            return PartialView("_SchedulerRandevuPartial");
        }
        public ActionResult SchedulerRandevuPartialEditAppointment(bool confirmDelete = false)
        {
            var appointments = appointmentContext.Randevus;
            System.Collections.IEnumerable resources = null; // Get resources from the context

            try
            {
                RandevuControllerSchedulerRandevuSettings.UpdateEditableDataObject(appointmentContext, resourceContext, confirmDelete);
            }
            catch (Exception e)
            {
                ViewData["SchedulerErrorText"] = e.Message;
            }

            ViewData["Appointments"] = appointments.ToList();
            ViewData["Resources"] = resources;

            return PartialView("_SchedulerRandevuPartial");
        }
    }
    public class RandevuControllerSchedulerRandevuSettings
    {
        static DevExpress.Web.Mvc.MVCxAppointmentStorage appointmentStorage;
        public static DevExpress.Web.Mvc.MVCxAppointmentStorage AppointmentStorage
        {
            get
            {
                if (appointmentStorage == null)
                {
                    appointmentStorage = new DevExpress.Web.Mvc.MVCxAppointmentStorage();
                    appointmentStorage.Mappings.AppointmentId = "Id";
                    appointmentStorage.Mappings.Start = "StartDate";
                    appointmentStorage.Mappings.End = "EndDate";
                    appointmentStorage.Mappings.Subject = "Subject";
                    appointmentStorage.Mappings.Description = "Description";
                    appointmentStorage.Mappings.Location = "Location";
                    appointmentStorage.Mappings.AllDay = "AllDay";
                    appointmentStorage.Mappings.Type = "Type";
                    appointmentStorage.Mappings.RecurrenceInfo = "";
                    appointmentStorage.Mappings.ReminderInfo = "";
                    appointmentStorage.Mappings.Label = "Label";
                    appointmentStorage.Mappings.Status = "Status";
                    appointmentStorage.Mappings.ResourceId = "";
                    appointmentStorage.CustomFieldMappings.Add(
                        new DevExpress.Web.ASPxScheduler.ASPxAppointmentCustomFieldMapping("AppointmentCustomField", "HastaId"));
                }
                return appointmentStorage;
            }
        }

        public class CustomAppointmentTemplateContainer : AppointmentFormTemplateContainer
        {
            public CustomAppointmentTemplateContainer(MVCxScheduler scheduler) : base(scheduler) { }

            public int HastaId
            {
                get
                {
                    return Appointment.CustomFields["AppointmentCustomField"] != null ? (int)Appointment.CustomFields["AppointmentCustomField"] : 0;
                }

                set
                {
                    Appointment.CustomFields["AppointmentCustomField"] = value;
                }

            }
        }

        static DevExpress.Web.Mvc.MVCxResourceStorage resourceStorage;
        public static DevExpress.Web.Mvc.MVCxResourceStorage ResourceStorage
        {
            get
            {
                if (resourceStorage == null)
                {
                    resourceStorage = new DevExpress.Web.Mvc.MVCxResourceStorage();
                    resourceStorage.Mappings.ResourceId = "";
                    resourceStorage.Mappings.Caption = "";
                }
                return resourceStorage;
            }
        }

        public static void UpdateEditableDataObject(YoutubeDevExpressMVC.Web.Models.DbRandevu.NorthwindRevEntitiesRandevu appointmentContext, object resourceContext, bool confirmDelete = false)
        {
            InsertAppointments(appointmentContext, resourceContext);
            UpdateAppointments(appointmentContext, resourceContext);
            DeleteAppointments(appointmentContext, resourceContext, confirmDelete);
        }

        static void InsertAppointments(YoutubeDevExpressMVC.Web.Models.DbRandevu.NorthwindRevEntitiesRandevu appointmentContext, object resourceContext)
        {
            var appointments = appointmentContext.Randevus.ToList();
            System.Collections.IEnumerable resources = null;

            var newAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToInsert<YoutubeDevExpressMVC.Web.Models.DbRandevu.Randevu>("SchedulerRandevu", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in newAppointments)
            {
                appointmentContext.Randevus.Add(appointment);
            }
            appointmentContext.SaveChanges();
        }
        static void UpdateAppointments(YoutubeDevExpressMVC.Web.Models.DbRandevu.NorthwindRevEntitiesRandevu appointmentContext, object resourceContext)
        {
            var appointments = appointmentContext.Randevus.ToList();
            System.Collections.IEnumerable resources = null;

            var updAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToUpdate<YoutubeDevExpressMVC.Web.Models.DbRandevu.Randevu>("SchedulerRandevu", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in updAppointments)
            {
                var origAppointment = appointments.FirstOrDefault(a => a.Id == appointment.Id);
                appointmentContext.Entry(origAppointment).CurrentValues.SetValues(appointment);
            }
            appointmentContext.SaveChanges();
        }
        static void DeleteAppointments(YoutubeDevExpressMVC.Web.Models.DbRandevu.NorthwindRevEntitiesRandevu appointmentContext, object resourceContext, bool confirmDelete = false)
        {
            var appointments = appointmentContext.Randevus.ToList();
            System.Collections.IEnumerable resources = null;

            var delAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToRemove<YoutubeDevExpressMVC.Web.Models.DbRandevu.Randevu>("SchedulerRandevu", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in delAppointments)
            {
                var delAppointment = appointments.FirstOrDefault(a => a.Id == appointment.Id);
                if (delAppointment != null && confirmDelete)
                {
                    appointmentContext.Randevus.Remove(delAppointment);
                }
            }
            appointmentContext.SaveChanges();
        }
    }

}