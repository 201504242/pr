﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancoGT
{
    public partial class Debito : System.Web.UI.Page
    {
        Operaciones op = new Operaciones();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            ds = op.listadoDebito();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void debito_click(object sender, EventArgs e)
        {
           // string usuario = txtdescripcion.Text;
            // codigo para verificaciones
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            int correlativo = Int32.Parse(row.Cells[1].Text);
            int cuenta = Int32.Parse(row.Cells[2].Text);
            double monton = Double.Parse(row.Cells[3].Text);
            op.debitar(cuenta, monton, correlativo);
            Response.Redirect("Debito");
            alerta.Text = "Se han debitado Q" + monton + "a la cuenta: " + cuenta;
        }
    }
}