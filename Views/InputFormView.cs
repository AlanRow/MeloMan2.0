using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpectrumVisor.Contexts;
using SpectrumVisor.Controllers;
using SpectrumVisor.Parameters;

namespace SpectrumVisor.Views
{
    class InputFormView : ISelfView
    {
        static int FieldHeight = 50;
        static int FieldWidth = 150;
        static int FieldSpace = 10;
        static int Padding = 50;

        private IInputFormController controller;
        private Form inputForm;
        private Label error;
        private List<Tuple<Param, Control>> inputs;
        private int rows;
        private int columns;

        public InputFormView(IInputFormController creator, InputFormContext context)
        {
            controller = creator;
            var fields = context.GetParamtersByColumns();
            //установка размеров
            rows = fields.Select(column => column.Length)
                                        .Max();
            columns = fields.Length;

            inputForm = new Form
            {
                Width = (columns + 1) * FieldWidth + columns * FieldSpace + Padding,
                Height = (rows + 2) * FieldHeight + (rows + 1) * FieldSpace + Padding,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };
            
            //разметка формы
            var table = new TableLayoutPanel();
            
            for (var i = 0; i < columns; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, FieldWidth + FieldSpace));
            }

            for (var i = 0; i < rows; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, FieldHeight + FieldSpace));
            }
            //ErrorString
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, FieldHeight + FieldSpace));
            //OK-Cancel
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, FieldHeight + FieldSpace));

            //размещение элементов
            inputs = new List<Tuple<Param, Control>>();
            for (var i = 0; i < columns; i++)
            {
                var column  = i;
                for (var j = 0; j < rows; j++)
                {
                    var row = j;

                    if (fields[i].Length <= j || fields[i][j] == null)
                        table.Controls.Add(new Panel(), column, row);
                    else
                    {
                        var field = new Panel();
                        field.Dock = DockStyle.Fill;
                        field.Width = FieldWidth;

                        var name  = new Label
                        {
                            Font = new System.Drawing.Font("Arial", 10),
                            Text = fields[i][j].Label,
                            AutoSize = true
                        };

                        Control input = new Panel();

                        if (fields[i][j] is SwitchParam)
                        {
                            var param = (fields[i][j] as SwitchParam);
                            input = new ComboBox
                            {
                                Width = FieldWidth,
                                Text = param.GetStrValue(),
                                Location = new Point(0, name.Height)
                            };
                            var inputBox = (input as ComboBox);
                            inputBox.Items.AddRange(param.GetValidValues().ToArray());
                        }
                        else
                        {
                            input = new TextBox
                            {
                                Width = FieldWidth,
                                Text = fields[i][j].GetStrValue(),
                                Location = new Point(0, name.Height)
                            };
                        }

                        inputs.Add(Tuple.Create(fields[i][j], input));
                        field.Controls.Add(name);
                        field.Controls.Add(input);

                        table.Controls.Add(field, column, row);
                    }
                }
            }

            //строка ошибок
            error = new Label
            {
                ForeColor = Color.Red
            };
            table.Controls.Add(error, 0, rows + 1);
            table.SetColumnSpan(error, columns);


            //кнопки отправки и отмены
            var okButton = new Button
            {
                Text = "Ок"
            };
            okButton.Click += (sender, ev) =>
            {
                foreach (var inp in inputs)
                {
                    try
                    {
                        inp.Item1.SetValue(inp.Item2.Text);
                    }
                    catch (InvalidParamException ex)
                    {
                        View(ex.Message);
                        return;
                    }
                }

                controller.Send(context.InputParameters);
                Close();
            };
            var cancelButton = new Button
            {
                Text = "Отмена"
            };
            cancelButton.Click += (sender, ev) =>
            {
                Close();
            };

            table.Controls.Add(okButton, (columns - 1) / 2, rows);
            table.Controls.Add(cancelButton, (columns - 1) / 2 + 1, rows);
            
            table.Dock = DockStyle.Fill;
            inputForm.Controls.Add(table);
        }

        public void Close()
        {
            inputForm.Close();
        }

        public void View()
        {
            View("");
        }

        public void View(string errorMessage)
        {
            error.Text = errorMessage;

            if (inputForm.Visible)
                inputForm.Invalidate();
            else
                inputForm.ShowDialog();
        }
    }
}
