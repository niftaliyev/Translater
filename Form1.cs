using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Translater4
{

    public class TranslateRequest
    {
        public string q { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string format { get; set; }
    }


    public class TranslateResponse
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Translation[] translations { get; set; }
    }

    public class Translation
    {
        public string translatedText { get; set; }
    }

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            InitializeComponent();

        }



      


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string url = "https://translation.googleapis.com/language/translate/v2?key=AIzaSyCqwaXLLd9JraElDHNGKFIN2zfbSAgAHms";
            WebClient web = new WebClient();
            web.Encoding = System.Text.Encoding.UTF8;

            TranslateRequest translate = new TranslateRequest() { q = richTextBox1.Text.ToString(), source = comboBox1.Text.ToString(), target = comboBox2.Text.ToString(), format = "text" };


            string answer = web.UploadString(url, JsonConvert.SerializeObject(translate));
            var response = JsonConvert.DeserializeObject<TranslateResponse>(answer);



            string returnAnswer = response.data.translations[0].translatedText;

            richTextBox2.Text = returnAnswer;
        }
    }
}