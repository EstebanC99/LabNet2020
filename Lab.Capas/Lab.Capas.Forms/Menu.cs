using Lab.Capas.Entities;
using Lab.Capas.Logic;
using System;
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
            dataGridView1.DataSource = "";
            switch (comboBox1.Text)
            {
                case "Regiones":
                    LoadTableRegion(new RegionLogic());
                    break;
                case "Territorios":
                    LoadTableTerritories(new TerritoriesLogic());
                    break;
                case "Empleados":
                    LoadTableEmployees(new EmployeeLogic());
                    break;
                default:
                    break;

            }
        }


        private void LoadTableRegion(RegionLogic entity)
        {
            dataGridView1.DataSource = entity.GetAll();
        }

        private void LoadTableTerritories(TerritoriesLogic entity)
        {
            dataGridView1.DataSource = entity.GetAll();
        }

        private void LoadTableEmployees(EmployeeLogic entity)
        {
            dataGridView1.DataSource = entity.GetAll();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
