using Controller;
using Model;
namespace View;
public class ViewPessoa : Form
{
    private readonly Label lblNome;
    private readonly Label lblIdade;
    private readonly Label lblCpf;
    private readonly TextBox inpNome;
    private readonly TextBox inpIdade;
    private readonly TextBox inpCpf;

    private readonly Button btnCreate;
    private readonly Button btnAlterar;
    private readonly Button btnDelete;

    private readonly DataGridView dgvPessoas;


    public ViewPessoa()
    {
        ControllerPessoa.Sincronizar();

        Size = new Size(500, 350);
        MinimumSize = new Size(500, 350);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Pessoa";

        lblNome = new Label
        {
            Text = "Nome: ",
            Location = new Point(30, 25),
            Size = new Size(100, 20)
        };
        lblIdade = new Label
        {
            Text = "Idade: ",
            Location = new Point(30, 50),
            Size = new Size(100, 20)
        };
        lblCpf = new Label
        {
            Text = "Cpf: ",
            Location = new Point(30, 75),
            Size = new Size(100, 20)
        };

        inpNome = new TextBox
        {
            Name = "Nome",
            Location = new Point(130, 25),
            Size = new Size(245, 20)
        };
        inpIdade = new TextBox
        {
            Name = "Idade",
            Location = new Point(130, 50),
            Size = new Size(245, 20)
        };
        inpCpf = new TextBox
        {
            Name = "Cpf",
            Location = new Point(130, 75),
            Size = new Size(245, 20)
        };

        btnCreate = new Button
        {
            Text = "Create",
            Location = new Point(30, 120),
            Size = new Size(100, 20)
        };
        btnCreate.Click += ClickCreate;

        btnAlterar = new Button
        {
            Text = "Alterar",
            Location = new Point(150, 120),
            Size = new Size(100, 20)
        };

        btnDelete = new Button
        {
            Text = "Delete",
            Location = new Point(275, 120),
            Size = new Size(100, 20)
        };
        btnDelete.Click += ClickDeletar;

        dgvPessoas = new DataGridView
        {
            Location = new Point(30, 150),
            Size = new Size(430, 150)
        };



        Controls.Add(lblNome);
        Controls.Add(lblIdade);
        Controls.Add(lblCpf);

        Controls.Add(inpNome);
        Controls.Add(inpIdade);
        Controls.Add(inpCpf);

        Controls.Add(btnCreate);
        Controls.Add(btnAlterar);
        Controls.Add(btnDelete);

        Controls.Add(dgvPessoas);

        Listar();

    }
    private void ClickCreate(object? sender, EventArgs e)
    {
        if (inpNome.Text == "")
        {
            MessageBox.Show("Preencha o nome");
            return;
        }
        if (inpIdade.Text == "")
        {
            MessageBox.Show("Preencha a idade");
            return;
        }
        if (inpCpf.Text == "")
        {
            MessageBox.Show("Preencha o cpf");
            return;
        }


        ControllerPessoa.CriarPessoa(inpNome.Text, Convert.ToInt32(inpIdade.Text), inpCpf.Text);
        Listar();
    }

    private void ClickDeletar(object? sender, EventArgs e)
    {
        int index = dgvPessoas.SelectedRows[0].Index;
        ControllerPessoa.DeletarPessoa(index);
        Listar();
    }
    private void Listar()
    {
        List<Pessoa> pessoas = ControllerPessoa.ListarPessoa();
        dgvPessoas.Columns.Clear();
        dgvPessoas.AutoGenerateColumns = false;
        dgvPessoas.DataSource = pessoas;

        dgvPessoas.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Nome",
            HeaderText = "Nome"
        });
        dgvPessoas.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Id",
            HeaderText = "Id"
        });
        dgvPessoas.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Idade",
            HeaderText = "Idade"
        });
        dgvPessoas.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Cpf",
            HeaderText = "Cpf"
        });
    }
}