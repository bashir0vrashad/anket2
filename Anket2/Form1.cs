using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Anket2
{
    public partial class Form1 : Form
    {
        List<Anket> ankets = new List<Anket>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void yazma_oxuma<t>(string fayl_adi, List<t> yeni, List<t> data)
        {
            if (ankets.Count == 0 && listBox1.Items.Count == 0) MessageBox.Show("ListBox Bosdu...");
            else
            {
                if (!File.Exists(fayl_adi)) using (FileStream fs = File.Create(fayl_adi)) ;
                else
                {
                    string old_json = File.ReadAllText(fayl_adi);
                    data = JsonConvert.DeserializeObject<List<t>>(old_json);
                }
                for (int i = 0; i < yeni.Count; i++) data.Add(yeni[i]);
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText(fayl_adi, json);
            }
        }
        private List<t> oxuma<t>(string fayl_ad)
        {
            List<t> data = new List<t>();
            if (!File.Exists(fayl_ad)) return data;

            string old_json = File.ReadAllText(fayl_ad);
            data = JsonConvert.DeserializeObject<List<t>>(old_json);
            return data;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Anket yeni = new Anket(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value);
                ankets.Add(yeni);
                listBox1.Items.Add(yeni.Ad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Fayl adi") textBox5.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Anket> yeni = new List<Anket>();
            if (textBox5.Text == "" || textBox5.Text == "Fayl adi") MessageBox.Show("Fayl Adi daxil etmelisiniz...");
            else yazma_oxuma<Anket>(textBox5.Text + ".json", ankets, yeni);
            listBox1.Items.Clear();
            textBox5.Text = "Fayl adi";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ankets.Count != 0 && listBox1.Items.Count!= 0)
            {
                DialogResult result = MessageBox.Show("Listbox içeriğini kaydetmek istiyor musunuz?", "Kaydetme Onayı", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    List<Anket> yeni = new List<Anket>();
                    if (textBox5.Text == "" || textBox5.Text == "Fayl adi") MessageBox.Show("Fayl Adi daxil etmelisiniz...");
                    else yazma_oxuma<Anket>(textBox5.Text + ".json", ankets, yeni);
                }
                else { }
            }
            if (textBox5.Text == "" || textBox5.Text == "Fayl adi") MessageBox.Show("Fayl Adi daxil etmelisiniz...");
            else
            {
                List<Anket> cari = oxuma<Anket>(textBox5.Text + ".json");
                if (cari.Count == 0) MessageBox.Show("Bu Fayl Bosdu.");
                else
                {
                    listBox1.Items.Clear();
                    for (int i = 0; i < cari.Count; i++)
                    {
                        listBox1.Items.Add(cari[i].Ad);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count == 0) { MessageBox.Show("Deyisdirmek Ucun Element Yoxdu.."); }
            else
            {
                if (listBox1.SelectedIndex != -1)
                {
                    if (ankets.Count != 0) {
                        textBox1.Text = ankets[listBox1.SelectedIndex].Ad;
                        textBox2.Text = ankets[listBox1.SelectedIndex].Soyad;
                        textBox3.Text = ankets[listBox1.SelectedIndex].Email;
                        textBox4.Text = ankets[listBox1.SelectedIndex].Tel;
                        dateTimePicker1.Value = ankets[listBox1.SelectedIndex].Date;

                    }
                    else
                    {
                        textBox1.Text = oxuma<Anket>(textBox5.Text + ".json")[listBox1.SelectedIndex].Ad;
                        textBox2.Text = oxuma<Anket>(textBox5.Text + ".json")[listBox1.SelectedIndex].Soyad;
                        textBox3.Text = oxuma<Anket>(textBox5.Text + ".json")[listBox1.SelectedIndex].Email;
                        textBox4.Text = oxuma<Anket>(textBox5.Text + ".json")[listBox1.SelectedIndex].Tel;
                        dateTimePicker1.Value = oxuma<Anket>(textBox5.Text + ".json")[listBox1.SelectedIndex].Date;
                    }
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
                else MessageBox.Show("Element seçilmedi.");
            }
            
        }
    }
}
