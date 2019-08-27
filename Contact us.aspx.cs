using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text;


namespace albourj
{
    public partial class Contact_us : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            alborjsql1DataContext db = new alborjsql1DataContext();
            Gdetail de = (from d in db.Gdetails select d).FirstOrDefault();
            phonelb.Text = de.Gdetails_Mobile;
            maillb.Text = de.Gdetails_Email;
            addresslb.Text = de.Gdetails_Address;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SmtpClient smtp = new SmtpClient("mail.al-bourj.com",26);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("info@al-bourj.com","Info@1234@");
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = false;

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new MailAddress("info@al-bourj.com", "Al-Bourj LTD.");
                mail.To.Add(new MailAddress(TextBox3.Text));
                mail.Subject = "Arados Software - Confirmation";
                mail.Body = "يوم سعيد </br> شكرا لك " + TextBox1.Text + " سيتم الرد قريبا  </br> الرجاء التواصل على الرقم  0998648090";
                mail.IsBodyHtml = true;
                smtp.Send(mail);
                ////alborjsql1DataContext db = new alborjsql1DataContext();
                ////Submission_Message sub = new Submission_Message();
                ////sub.Sub_Name = TextBox1.Text;
                ////sub.Sub_Phone = TextBox2.Text;
                ////sub.Sub_Email = TextBox3.Text;
                ////sub.Sub_Date = DateTime.Now;
                ////sub.Sub_ContentMessage = TextBox4.Text;
                ////db.Submission_Messages.InsertOnSubmit(sub);
                ////db.SubmitChanges();
                ////Submission_Message ema= (from test in db.Submission_Messages where( test.Sub_Name ==TextBox1.Text & test.Sub_Email==TextBox3.Text)  select test).SingleOrDefault();

                //string to = TextBox3.Text; /*"mahmoudhamad.0992@gmail.com"; *///To address    
                //string from = "info@al-bourj.com"; //From address    
                //System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to);

                //string mailbody = "شكرا لتواصلك معنا سيتم الرد قريبا...الرجاء الاتصال على الرقم 0944525550";
                //message.Subject = "al-bourj";
                //message.Body = mailbody;
                //message.BodyEncoding = Encoding.UTF8;
                //message.IsBodyHtml = true;
                //SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                //System.Net.NetworkCredential basicCredential1 = new
                //System.Net.NetworkCredential("mahmoudshoiabhamad@gmail.com", "0992624814");
                //client.EnableSsl = true;
                //client.UseDefaultCredentials = true;
                //client.Credentials = basicCredential1;

                //client.Send(message);
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                Label1.Visible = false;
                DisplayMessage.Visible = true;

            }



            catch (Exception ex)
            {
                DisplayMessage.Visible = false;
                Label1.Visible = true;
                Label1.Text = ex.Message;

            }

        }
    }
}