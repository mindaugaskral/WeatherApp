using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace OraiApp
{
    public partial class Orai : Form
    {
        public int OriginalWidth;
        public int OriginalHeight;

        const string APPID = "c00fc7f90959e33d05937d2a776e4662";
        string CityName = "Kaunas";
        
        
        
        public Orai()
        {
            InitializeComponent();
            GetWeather("Kaunas");
            WeatherForcast("Kaunas");
            OriginalWidth = this.Width;
            OriginalHeight = this.Height;

        }
        void GetWeather(string CityName)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=6", CityName, APPID);

                var json = web.DownloadString(url);
                var resut = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                WeatherInfo.root outPut = resut;

                Miestas.Text = string.Format("{0}", outPut.name);
                Šalis.Text = string.Format("{0}", outPut.sys.country);
                Temp.Text = string.Format("{0:0} \u00B0" + "C", outPut.main.temp);
                Dangus.Text = string.Format("{0}", outPut.weather[0].description);
                Vejas.Text = string.Format("{0} km/h", outPut.wind.speed);
                Humidity1.Text = string.Format("{0} %", outPut.main.humidity);
                Pressure1.Text = string.Format("{0} hPa", outPut.main.pressure);
                Sauletekis.Text = string.Format("{0}", getDate(outPut.sys.sunrise).TimeOfDay);
                Saulelydis.Text = string.Format("{0}", getDate(outPut.sys.sunset).TimeOfDay);

                DangusPicture.Image = SetIcon(outPut.weather[0].icon);

            }
        }
        void WeatherForcast(string CityName)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}&units=metric&cnt=8", CityName, APPID);
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<WeatherForcast>(json);

                WeatherForcast forcast = Object;

                data1.Text = string.Format("{0}", getDate(forcast.list[0].dt).TimeOfDay);
                temp1.Text = string.Format("{0:0} \u00B0" + "C", forcast.list[0].main.temp);
                sky1.Text = string.Format("{0}", forcast.list[0].weather[0].description);
                wind1.Text = string.Format("{0} km/h", forcast.list[0].wind.speed);
                humid1.Text = string.Format("{0} %", forcast.list[0].main.humidity);
                presu1.Text = string.Format("{0} hPa", forcast.list[0].main.pressure);
                Dangus1.Image = SetIcon(forcast.list[0].weather[0].icon);

                data2.Text = string.Format("{0}", getDate(forcast.list[1].dt).TimeOfDay);
                temp2.Text = string.Format("{0:0} \u00B0" + "C", forcast.list[1].main.temp);
                sky2.Text = string.Format("{0}", forcast.list[1].weather[0].description);
                wind2.Text = string.Format("{0} km/h", forcast.list[1].wind.speed);
                humid2.Text = string.Format("{0} %", forcast.list[1].main.humidity);
                presu2.Text = string.Format("{0} hPa", forcast.list[1].main.pressure);
                Dangus2.Image = SetIcon(forcast.list[1].weather[0].icon);

                data3.Text = string.Format("{0}", getDate(forcast.list[2].dt).TimeOfDay);
                temp3.Text = string.Format("{0:0} \u00B0" + "C", forcast.list[2].main.temp);
                sky3.Text = string.Format("{0}", forcast.list[2].weather[0].description);
                wind3.Text = string.Format("{0} km/h", forcast.list[2].wind.speed);
                humid3.Text = string.Format("{0} %", forcast.list[2].main.humidity);
                presu3.Text = string.Format("{0} hPa", forcast.list[2].main.pressure);
                Dangus3.Image = SetIcon(forcast.list[2].weather[0].icon);

                data4.Text = string.Format("{0}", getDate(forcast.list[3].dt).TimeOfDay);
                temp4.Text = string.Format("{0:0} \u00B0" + "C", forcast.list[3].main.temp);
                sky4.Text = string.Format("{0}", forcast.list[3].weather[0].description);
                wind4.Text = string.Format("{0} km/h", forcast.list[3].wind.speed);
                humid4.Text = string.Format("{0} %", forcast.list[3].main.humidity);
                presu4.Text = string.Format("{0} hPa", forcast.list[3].main.pressure);
                Dangus4.Image = SetIcon(forcast.list[3].weather[0].icon);

                data5.Text = string.Format("{0}", getDate(forcast.list[4].dt).TimeOfDay);
                temp5.Text = string.Format("{0:0} \u00B0" + "C", forcast.list[4].main.temp);
                sky5.Text = string.Format("{0}", forcast.list[4].weather[0].description);
                wind5.Text = string.Format("{0} km/h", forcast.list[4].wind.speed);
                humid5.Text = string.Format("{0} %", forcast.list[4].main.humidity);
                presu5.Text = string.Format("{0} hPa", forcast.list[4].main.pressure);
                Dangus5.Image = SetIcon(forcast.list[4].weather[0].icon);

                data6.Text = string.Format("{0}", getDate(forcast.list[5].dt).TimeOfDay);
                temp6.Text = string.Format("{0:0} \u00B0" + "C", forcast.list[5].main.temp);
                sky6.Text = string.Format("{0}", forcast.list[5].weather[0].description);
                wind6.Text = string.Format("{0} km/h", forcast.list[5].wind.speed);
                humid6.Text = string.Format("{0} %", forcast.list[5].main.humidity);
                presu6.Text = string.Format("{0} hPa", forcast.list[5].main.pressure);
                Dangus6.Image = SetIcon(forcast.list[5].weather[0].icon);

                data7.Text = string.Format("{0}", getDate(forcast.list[6].dt).TimeOfDay);
                temp7.Text = string.Format("{0:0} \u00B0" + "C", forcast.list[6].main.temp);
                sky7.Text = string.Format("{0}", forcast.list[6].weather[0].description);
                wind7.Text = string.Format("{0} km/h", forcast.list[6].wind.speed);
                humid7.Text = string.Format("{0} %", forcast.list[6].main.humidity);
                presu7.Text = string.Format("{0} hPa", forcast.list[6].main.pressure);
                Dangus7.Image = SetIcon(forcast.list[6].weather[0].icon);

                data8.Text = string.Format("{0}", getDate(forcast.list[7].dt).TimeOfDay);
                temp8.Text = string.Format("{0:0} \u00B0" + "C", forcast.list[7].main.temp);
                sky8.Text = string.Format("{0}", forcast.list[7].weather[0].description);
                wind8.Text = string.Format("{0} km/h", forcast.list[7].wind.speed);
                humid8.Text = string.Format("{0} %", forcast.list[7].main.humidity);
                presu8.Text = string.Format("{0} hPa", forcast.list[7].main.pressure);
                Dangus8.Image = SetIcon(forcast.list[7].weather[0].icon);
            }
        }
        DateTime getDate(double milliseconds)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(milliseconds).ToLocalTime();
            day = day.AddHours(1);
            return day;
        }

        private void DetaliauB_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1324, 598);
        }

        private void UzdarytiB_Click(object sender, EventArgs e)
        {
            this.Size = new Size(310, 598);
        }
        Image SetIcon(string iconID)
        {
            string url = string.Format("https://openweathermap.org/img/w/{0}.png", iconID);
            var request = WebRequest.Create(url);
            using (var response = request.GetResponse())
            using (var weatherIcon = response.GetResponseStream())
            {
                Image weatherImg = Bitmap.FromStream(weatherIcon);
                return weatherImg;
            }
        }

        private void SearchB_Click(object sender, EventArgs e)
        {
            try
            {
                if (Searchtxt.Text != "")
                {
                    GetWeather(Searchtxt.Text);
                    WeatherForcast(Searchtxt.Text);
                }
                else
                {
                    MessageBox.Show("Blogai ivestas miestas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Netinkamas miestas" + ex.ToString());
            }
 
        }
    }
    }
