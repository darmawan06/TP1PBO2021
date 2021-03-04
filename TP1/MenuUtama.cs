using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class MenuUtama : Form
    {
        List<TambahBarang> dataBarang = new List<TambahBarang>();
        public MenuUtama()
        {
            InitializeComponent();
            createNavFilter();
            isiTambahBarang(this.dataBarang);
            filterProses(null, 0, 0);  
        }
        private void createNavFilter()
        {
            panelNavFilter.Controls.Clear();
            string jenisBarang = null;
            int minHarga = 0;
            int highHarga = 0;

            Button Search = new Button();
            Search.Location = new System.Drawing.Point(33, 208);
            Search.Name = "btnFilter";
            Search.Size = new System.Drawing.Size(75, 23);
            Search.TabIndex = 2;
            Search.BackColor = System.Drawing.SystemColors.GrayText;
            Search.Text = "Cari";
            Search.Cursor = System.Windows.Forms.Cursors.Hand;
            Search.Click += new EventHandler((object sender, EventArgs e) =>
            {
                filterProses(jenisBarang, minHarga, highHarga);
            });
            
            ComboBox Harga = new ComboBox();
            Harga.FormattingEnabled = true;
            Harga.Items.AddRange(new object[] { "100rb - 200rb", "200rb - 500rb", "500rb - 1juta" });
            Harga.Location = new System.Drawing.Point(12, 156);
            Harga.Name = "cbHarga";
            Harga.Text = "Harga Barang";
            Harga.Size = new System.Drawing.Size(121, 21);
            Harga.TabIndex = 1;
            Harga.FlatStyle = FlatStyle.Flat;
            Harga.SelectedIndexChanged += new EventHandler((object sender, EventArgs e) =>
            {
                ComboBox value = (ComboBox)sender;
                value.DropDownStyle = ComboBoxStyle.DropDownList;
                FilterHarga fH = new FilterHarga(value.SelectedItem.ToString());
                minHarga = fH.getMinHarga();
                highHarga = fH.getHighHarga();
            });
            
            ComboBox Product = new ComboBox();
            Product.FormattingEnabled = true;
            Product.Items.AddRange(new object[] { "Elektronik", "Makanan", "Pakaian" });
            Product.Location = new System.Drawing.Point(12, 101);
            Product.Name = "cbJenisBarang";
            Product.Size = new System.Drawing.Size(121, 21);
            Product.TabIndex = 0;
            Product.Text = "Jenis Barang";
            Product.FlatStyle = FlatStyle.Flat;
            Product.SelectedIndexChanged += new EventHandler((object sender, EventArgs e) =>
            {
                ComboBox value = (ComboBox)sender;
                value.DropDownStyle = ComboBoxStyle.DropDownList;
                jenisBarang = value.SelectedItem.ToString().ToLower();
            });
            panelNavFilter.Controls.Add(Harga);
            panelNavFilter.Controls.Add(Search);
            panelNavFilter.Controls.Add(Product);
        }
        private Panel createListProduct(string setNamaBarang,int setHarga,int setId)
        {
            Panel box = new Panel();
            Label namaBarang = new Label();
            Label harga = new Label();
            Button btnBeli = new Button();
            PictureBox pBProduct = new PictureBox();

            box.BackColor = System.Drawing.Color.NavajoWhite;
            box.Controls.Add(pBProduct);
            box.Controls.Add(btnBeli);
            box.Controls.Add(harga);
            box.Controls.Add(namaBarang);
            box.Location = new System.Drawing.Point(3, 3);
            box.Name = "panel1";
            box.Size = new System.Drawing.Size(200, 210);
            box.TabIndex = 0;

            namaBarang.AutoSize = true;
            namaBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            namaBarang.Location = new System.Drawing.Point(22, 120);
            namaBarang.Name = "label1";
            namaBarang.Size = new System.Drawing.Size(79, 13);
            namaBarang.TabIndex = 0;
            namaBarang.Text = setNamaBarang.ToString();
            // 
            // label2
            // 
            harga.AutoSize = true;
            harga.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            harga.Location = new System.Drawing.Point(22, 142);
            harga.Name = "label2";
            harga.Size = new System.Drawing.Size(41, 13);
            harga.TabIndex = 1;
            harga.Text = setHarga.ToString();
            // 
            // button1
            // 
            btnBeli.BackColor = System.Drawing.SystemColors.ControlLight;
            btnBeli.FlatAppearance.BorderSize = 0;
            btnBeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBeli.Location = new System.Drawing.Point(102, 167);
            btnBeli.Name = setId.ToString();
            btnBeli.Size = new System.Drawing.Size(75, 23);
            btnBeli.TabIndex = 2;
            btnBeli.Text = "Beli";
            btnBeli.UseVisualStyleBackColor = false;
            btnBeli.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBeli.Click += new EventHandler((object sender, EventArgs e) =>
            {
                Button btn = (Button)sender;
                int Id = int.Parse(btn.Name);
                prosesBeli(Id);
            });
            // 
            // pictureBox1
            //
            pBProduct.BackgroundImage = global::TP1.Properties.Resources.shop;
            pBProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pBProduct.Location = new System.Drawing.Point(15, 21);
            pBProduct.Name = "pictureBox1";
            pBProduct.Size = new System.Drawing.Size(171, 84);
            pBProduct.TabIndex = 3;
            pBProduct.TabStop = false;

            return box;
        }
        private void isiTambahBarang(List<TambahBarang> dataBarang)
        {
            dataBarang.Add(new TambahBarang(1, "Iphone 1", 900000, "elektronik", "Garansi Indonesia, Memiliki Ram 10Gb , External 100Gb"));
            dataBarang.Add(new TambahBarang(2, "Iphone 2", 600000, "elektronik", "Garansi Indonesia, Memiliki Ram 10Gb , External 100Gb"));
            dataBarang.Add(new TambahBarang(3, "Iphone 3", 700000, "elektronik", "Garansi Indonesia, Memiliki Ram 10Gb , External 100Gb"));
            dataBarang.Add(new TambahBarang(4, "Iphone 4", 300000, "elektronik", "Garansi Indonesia, Memiliki Ram 10Gb , External 100Gb"));
            dataBarang.Add(new TambahBarang(5, "Iphone 5", 500000, "elektronik", "Garansi Indonesia, Memiliki Ram 10Gb , External 100Gb"));
            dataBarang.Add(new TambahBarang(6, "Iphone 6", 1000000, "elektronik", "Garansi Indonesia, Memiliki Ram 10Gb , External 100Gb"));

            dataBarang.Add(new TambahBarang(7, "Somay", 100000, "makanan", "Murah Banget"));
            dataBarang.Add(new TambahBarang(8, "Baso", 200000, "makanan", "Murah Banget"));
            dataBarang.Add(new TambahBarang(9, "Tulang", 400000, "makanan", "Murah Banget"));
            dataBarang.Add(new TambahBarang(10, "Piscok", 500000, "makanan", "Murah Banget"));
            dataBarang.Add(new TambahBarang(11, "Cimol", 600000, "makanan", "Murah Banget"));
            dataBarang.Add(new TambahBarang(12, "Martabak", 3000000, "makanan", "Murah Banget"));

            dataBarang.Add(new TambahBarang(13, "Baju", 300000, "pakaian", "Pakaian Import dari Batam"));
            dataBarang.Add(new TambahBarang(14, "Celana", 200000, "pakaian", "Pakaian Import dari Batam"));
            dataBarang.Add(new TambahBarang(15, "Sepatu", 500000, "pakaian", "Pakaian Import dari Batam"));
            dataBarang.Add(new TambahBarang(16, "Kaos Kaki", 300000, "pakaian", "Pakaian Import dari Batam"));
            dataBarang.Add(new TambahBarang(17, "Topi", 500000, "pakaian", "Pakaian Import dari Batam"));
            dataBarang.Add(new TambahBarang(18, "Kemeja", 400000, "pakaian", "Pakaian Import dari Batam"));

        }
        private void filterProses(string jenisBarang, int minHarga, int highHarga)
        {
            panelListProduct.Controls.Clear();
            foreach (var obj in this.dataBarang)
            {
                if (obj.jenisBarang == jenisBarang)
                {
                    if (obj.harga >= minHarga && obj.harga <= highHarga)
                    {
                        panelListProduct.Controls.Add(createListProduct(obj.nama, obj.harga, obj.id));
                    }
                    else if (minHarga == 0)
                    {
                        panelListProduct.Controls.Add(createListProduct(obj.nama, obj.harga, obj.id));
                    }
                }
                else if(jenisBarang == null)
                {
                    if (obj.harga >= minHarga && obj.harga <= highHarga)
                    {
                        panelListProduct.Controls.Add(createListProduct(obj.nama, obj.harga, obj.id));
                    }
                    else if (minHarga == 0)
                    {
                        panelListProduct.Controls.Add(createListProduct(obj.nama, obj.harga, obj.id));
                    }
                }
            }
        }
        public Button createButtonKembali()
        {
            Button btnKembali = new Button();
            btnKembali.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            btnKembali.FlatAppearance.BorderSize = 0;
            btnKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnKembali.ForeColor = System.Drawing.SystemColors.Control;
            btnKembali.Location = new System.Drawing.Point(3, 186);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new System.Drawing.Size(134, 23);
            btnKembali.TabIndex = 0;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Cursor = System.Windows.Forms.Cursors.Hand;
            btnKembali.Click += new EventHandler((object sender, EventArgs e) =>
             {
                 createNavFilter();
                 header.Controls.Clear();
                 filterProses(null, 0, 0);
             });
            return btnKembali;
        }

        public void detailProduct(string setNamaBarang,int setHarga,int setId,string setDeskripsi)
        {

            Panel BackPanel = new Panel();
            Label harga = new Label();
            Label title = new Label();
            BackPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            BackPanel.Controls.Add(harga);
            BackPanel.Controls.Add(title);
            BackPanel.Location = new System.Drawing.Point(3, 3);
            BackPanel.Name = "panel7s2";
            BackPanel.Size = new System.Drawing.Size(65, 241);
            BackPanel.TabIndex = 3;
            harga.AutoSize = true;
            harga.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            harga.Location = new System.Drawing.Point(0, 119);
            harga.Name = "hargas2";
            harga.Size = new System.Drawing.Size(48, 18);
            harga.TabIndex = 5;
            harga.Text = setHarga.ToString();
            title.AutoSize = true;
            title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title.Location = new System.Drawing.Point(3, 66);
            title.Name = "label1s2";
            title.Size = new System.Drawing.Size(48, 18);
            title.TabIndex = 4;
            title.Text = "Harga";

            panelListProduct.Controls.Add(BackPanel);

            PictureBox pct = new PictureBox();
            pct.BackgroundImage = global::TP1.Properties.Resources.shop;
            pct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pct.Location = new System.Drawing.Point(74, 3);
            pct.Name = "pictureBox1s2";
            pct.Size = new System.Drawing.Size(200, 241);
            pct.BackColor = System.Drawing.Color.NavajoWhite;
            pct.TabIndex = 0;
            pct.TabStop = false;
            panelListProduct.Controls.Add(pct);

            Panel pNB = new Panel();
            Label titleNB = new Label();
            Label NB = new Label();
            pNB.BackColor = System.Drawing.SystemColors.ControlDark;
            pNB.Controls.Add(titleNB);
            pNB.Controls.Add(NB);
            pNB.Location = new System.Drawing.Point(280, 3);
            pNB.Name = "panel1s2";
            pNB.Size = new System.Drawing.Size(206, 60);
            pNB.TabIndex = 1;
            panelListProduct.Controls.Add(pNB);

            titleNB.AutoSize = true;
            titleNB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            titleNB.Location = new System.Drawing.Point(24, 18);
            titleNB.Name = "namaBarangs2";
            titleNB.Size = new System.Drawing.Size(132, 25);
            titleNB.TabIndex = 1;
            titleNB.Text = setNamaBarang;
           

            NB.AutoSize = true;
            NB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            NB.Location = new System.Drawing.Point(3, 0);
            NB.Name = "namas2";
            NB.Size = new System.Drawing.Size(99, 18);
            NB.TabIndex = 0;
            NB.Text ="Nama Barang";

            Panel pD = new Panel();
            Label d = new Label();
            Label lD = new Label();
            pD.BackColor = System.Drawing.SystemColors.ControlDark;
            pD.Controls.Add(d);
            pD.Controls.Add(lD);
            pD.Location = new System.Drawing.Point(280, 69);
            pD.Name = "panel6s2";
            pD.Size = new System.Drawing.Size(349, 175);
            pD.TabIndex = 2;
            panelListProduct.Controls.Add(pD);

            d.BackColor = System.Drawing.SystemColors.Control;
           d.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           d.Location = new System.Drawing.Point(3, 29);
           d.MaximumSize = new System.Drawing.Size(346, 133);
           d.Name = "deskripsis2";
           d.Size = new System.Drawing.Size(343, 131);
            d.Text = setDeskripsi;
           d.TabIndex = 3;


            lD.AutoSize = true;
            lD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lD.Location = new System.Drawing.Point(3, 0);
            lD.Name = "labelDess2";
            lD.Size = new System.Drawing.Size(70, 18);
            lD.TabIndex = 2;
            lD.Text = "Deskripsi";

            Button Beli = new Button();

            Beli.BackColor = System.Drawing.Color.SlateGray;
            Beli.FlatAppearance.BorderSize = 0;
            Beli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Beli.ForeColor = System.Drawing.Color.Lime;
            Beli.Location = new System.Drawing.Point(271, 37);
            Beli.Name = "Belis2";
            Beli.Size = new System.Drawing.Size(130, 41);
            Beli.TabIndex = 0;
            Beli.Text = "Beli Barang";
            Beli.UseVisualStyleBackColor = false;
            header.Controls.Add(Beli);
        }
        private void prosesBeli(int noId )
        {
            panelNavFilter.Controls.Clear();
            Button cbk = createButtonKembali();
            panelNavFilter.Controls.Add(cbk);

            panelListProduct.Controls.Clear();
            foreach (var obj in this.dataBarang)
            {
                if(obj.id == noId)
                {
                    detailProduct(obj.nama, obj.harga, obj.id, obj.deskripsi);
                }
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            createNavFilter();
            header.Controls.Clear();
            filterProses(null, 0, 0);
        }

        private void Catalog_Click(object sender, EventArgs e)
        {
            linkkotolog();
        }

        void linkkotolog()
        {
            System.Diagnostics.Process.Start("http://Www.tokopedia.com");
        }
    }
}
