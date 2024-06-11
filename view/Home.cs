using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Controller;

namespace View // Removido o ponto e vírgula desnecessário
{
    public class Home : Form
    {
        Font MediumFont = new Font("Arial", 10);
        Font LargeFont = new Font("Arial", 12);
        Size SizeBtn = new Size(200, 30);
        Size SizeInp = new Size(200, 20);

        private readonly Label LblNome;
        private readonly TextBox InpNome;
        private readonly Label LblIdade;
        private readonly TextBox InpIdade;
        private readonly Label LblIndex;
        private readonly TextBox InpIndex;

        private readonly Label LblWelcome;
        private readonly Button BtnCriar;
        private readonly Button BtnListar;
        private readonly Button BtnDeletar;

        private DataGridView dataGridView1;

        public Home()
        {
            Size = new Size(520, 550);
            StartPosition = FormStartPosition.CenterScreen;

            LblWelcome = new Label
            {
                Text = "Bem Vindo ao programa de Lista de Pessoas",
                Size = new Size(400, 20),
                Location = new Point(30, 25),
                Font = LargeFont
            };
            Controls.Add(LblWelcome);

            LblNome = new Label
            {
                Text = "Nome: ",
                Location = new Point(30, 65)
            };
            LblIdade = new Label
            {
                Text = "Idade: ",
                Location = new Point(30, 105)
            };
            LblIndex = new Label
            {
                Text = "ID: ",
                Location = new Point(30, 145)
            };
            InpNome = new TextBox
            {
                Name = "Nome",
                Size = SizeInp,
                Location = new Point(100, 65)
            };
            InpIdade = new TextBox
            {
                Name = "Idade",
                Size = SizeInp,
                Location = new Point(100, 105)
            };
            InpIndex = new TextBox
            {
                Name = "Index",
                Size = SizeInp,
                Location = new Point(100, 145)
            };
            Controls.Add(InpNome);
            Controls.Add(InpIndex);
            Controls.Add(InpIdade);
            Controls.Add(LblNome);
            Controls.Add(LblIdade);
            Controls.Add(LblIndex);

            BtnCriar = new Button
            {
                Text = "Criar",
                Size = SizeBtn,
                Location = new Point(33, 200),
                Font = MediumFont
            };
            BtnCriar.Click += clkCriar;

            BtnListar = new Button
            {
                Text = "Listar",
                Size = SizeBtn,
                Location = new Point(266, 200),
                Font = MediumFont
            };
            BtnListar.Click += clkListar;
            BtnDeletar = new Button
            {
                Text = "Deletar",
                Size = SizeBtn,
                Location = new Point(33, 245),
                Font = MediumFont
            };
            BtnDeletar.Click += clkDelet;

            Controls.Add(BtnCriar);
            Controls.Add(BtnListar);
            Controls.Add(BtnDeletar);

            // Inicializando o DataGridView
            dataGridView1 = new DataGridView();
            dataGridView1.Size = new Size(450, 200);
            dataGridView1.Location = new Point(33, 300);

            // Criando e preenchendo um DataTable com dados de exemplo
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Nome", typeof(string));
            dataTable.Columns.Add("Idade", typeof(int));

            dataGridView1.DataSource = dataTable;

            dataGridView1.CellDoubleClick += clkEditar;
            dataGridView1.CellClick += dataGridView1_CellClick;

            Controls.Add(dataGridView1);
        }

        private void clkCriar(object? sender, EventArgs e)
        {
            if (InpNome.Text.Length < 1)
            {
                MessageBox.Show("Input Nome não pode ser vazio");
                return;
            }
            if (string.IsNullOrEmpty(InpIdade.Text))
            {
                MessageBox.Show("Input Idade não pode ser vazio");
                return;
            }

            // Obtendo o DataTable do DataGridView
            DataTable dataTable = (DataTable)dataGridView1.DataSource;

            // Adicionando uma nova linha com dados de exemplo
            int newId = 1;
            if (dataTable.Rows.Count > 0)
            {
                // Obtendo o ID máximo atual
                int maxId = dataTable.AsEnumerable().Max(row => row.Field<int>("ID"));
                newId = maxId + 1;
            }

            dataTable.Rows.Add(newId, InpNome.Text, Convert.ToInt32(InpIdade.Text));

            // Atualizando o DataGridView para refletir as mudanças
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataTable;
        }

        private void clkListar(object? sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataTable;
        }

        private void clkDelet(object? sender, EventArgs e)
        {
            // Obtém o ID inserido no TextBox
            if (!int.TryParse(InpIndex.Text, out int id))
            {
                MessageBox.Show("ID inválido. Por favor, insira um número válido.");
                return;
            }

            // Procura o ID na primeira coluna do DataGridView
            bool found = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && (int)row.Cells[0].Value == id)
                {
                    found = true;
                    // Remove a linha correspondente ao ID
                    dataGridView1.Rows.Remove(row);
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("ID não encontrado. Por favor, insira um ID válido.");
            }
        }

        private void clkEditar(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a célula clicada é válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtém a linha clicada
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Obtém os valores das células da linha clicada
                row.Cells["Nome"].Value = InpNome.Text;
                row.Cells["Idade"].Value = Convert.ToInt32(InpIdade.Text);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a célula clicada é válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Verifica se a célula clicada pertence à coluna de ID
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "ID")
                {
                    // Obtém o valor do ID da célula clicada
                    object idValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // Atualiza o valor do TextBox com o ID clicado
                    InpIndex.Text = idValue.ToString();
                }
            }
        }

    }
}

// !  Trocar a parte que salva manual e colocar a parte que usa a Lista