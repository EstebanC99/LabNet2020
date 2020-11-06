using Lab.Capas.Entities;
using Lab.Capas.Logic;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab.Capas.Forms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarDatos();
            switch (comboBox1.Text)
            {
                case "Regiones":
                    LoadTable(new RegionLogic());
                    break;
                case "Territorios":
                    LoadTable(new TerritoriesLogic());
                    break;
                case "Productos":
                    LoadTable(new ProductLogic());
                    break;
                default:
                    break;

            }
        }

        #region DataGridCarga
        private void LoadTable(RegionLogic entity)
        {
            var entitys = (from e in entity.GetAll()
                           select new { e.RegionID, e.RegionDescription });
            dataGridView1.DataSource = entitys.ToList();
        }

        private void LoadTable(TerritoriesLogic entity)
        {
            var entitys = (from e in entity.GetAll()
                           select new { e.TerritoryID, e.TerritoryDescription });
            dataGridView1.DataSource = entitys.ToList();
        }

        private void LoadTable(ProductLogic entity)
        {
            var entitys = (from e in entity.GetAll()
                           select new { e.ProductID, e.ProductName });
            dataGridView1.DataSource = entitys.ToList();
        }
        #endregion


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LimpiarDatos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.DataSource = "";
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label3.Text = comboBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != dataGridView1.CurrentRow.Cells[0].Value.ToString())
            {
                btUpdate.Enabled = true;
            } else
            {
                btUpdate.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != dataGridView1.CurrentRow.Cells[1].Value.ToString())
            {
                btUpdate.Enabled = true;
            }
            else
            {
                btUpdate.Enabled = false;
            }
        }


        #region ALTAS

        private void btInsert_Click(object sender, EventArgs e)
        {
            switch (label3.Text)
            {
                case "Regiones":
                    Insert(new RegionLogic());
                    break;
                case "Territorios":
                    Insert(new TerritoriesLogic());
                    break;
                case "Productos":
                    Insert(new ProductLogic());
                    break;
                default:
                    break;

            }
            LimpiarDatos();
        }

        private void Insert(RegionLogic regionLogic)
        {
            Entities.Region newEntity = new Entities.Region();
            newEntity.RegionID = int.Parse(textBox1.Text);
            newEntity.RegionDescription = textBox2.Text;
            regionLogic.Insert(newEntity);
        }

        private void Insert(TerritoriesLogic territoriesLogic)
        {
            Territories newEntity = new Territories();
            newEntity.TerritoryID = textBox1.Text;
            newEntity.TerritoryDescription = textBox2.Text;
            territoriesLogic.Insert(newEntity);
        }

        private void Insert(ProductLogic productLogic)
        {
            Products newEntity = new Products();
            newEntity.ProductID = int.Parse(textBox1.Text);
            newEntity.ProductName = textBox2.Text;
            productLogic.Insert(newEntity);
        }

        #endregion


        #region BAJAS
        private void btDelete_Click(object sender, EventArgs e)
        {
            switch (label3.Text)
            {
                case "Regiones":
                    Delete(new RegionLogic());
                    break;
                case "Territorios":
                    Delete(new TerritoriesLogic());
                    break;
                case "Productos":
                    Delete(new ProductLogic());
                    break;
                default:
                    break;

            }
            LimpiarDatos();
        }

        private void Delete(RegionLogic regionLogic)
        {
            regionLogic.Delete(int.Parse(textBox1.Text));
        }

        private void Delete(TerritoriesLogic territoriesLogic)
        {
            territoriesLogic.Delete(textBox1.Text);
        }

        private void Delete(ProductLogic productLogic)
        {
            productLogic.Delete(int.Parse(textBox1.Text));
        }
        #endregion


        #region MODIFICACIONES
        private void btUpdate_Click(object sender, EventArgs e)
        {
            switch (label3.Text)
            {
                case "Regiones":
                    Update(new RegionLogic());
                    break;
                case "Territorios":
                    Update(new TerritoriesLogic());
                    break;
                case "Productos":
                    Update(new ProductLogic());
                    break;
                default:
                    break;

            }
            LimpiarDatos();
        }


        private void Update(RegionLogic entity)
        {
            Entities.Region entityUpdated = new Entities.Region();
            entityUpdated.RegionID = int.Parse(textBox1.Text);
            entityUpdated.RegionDescription = textBox2.Text;
            entity.Update(entityUpdated);
        }

        private void Update(TerritoriesLogic entity)
        {
            Territories entityUpdated = new Territories();
            entityUpdated.TerritoryID = textBox1.Text;
            entityUpdated.TerritoryDescription = textBox2.Text;
            entity.Update(entityUpdated);
        }

        private void Update(ProductLogic entity)
        {
            Products entityUpdated = new Products();
            entityUpdated.ProductID = int.Parse(textBox1.Text);
            entityUpdated.ProductName = textBox2.Text;
            entity.Update(entityUpdated);
        }
        #endregion

    }
}
