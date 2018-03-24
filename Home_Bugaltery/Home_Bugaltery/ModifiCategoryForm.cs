using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home_Bugaltery
{
    public partial class ModifiCategoryForm : Form
    {

        bool type = false;

        HomeBugaltery homeBugaltery;
        HomeBugalteryAction actHomeBogaltery;

        Categories curentCategory = null;

        int typeValue = -1;

        public ModifiCategoryForm(HomeBugaltery homeBugaltery, HomeBugalteryAction actHomeBogaltery)
        {
            InitializeComponent();

            this.homeBugaltery = homeBugaltery;
            this.actHomeBogaltery = actHomeBogaltery;

            updateCategory();

            comboBoxType.SelectedIndex = 0;

        }

        private void updateCategory()
        {
            dataGridViewCategory.Rows.Clear();


            foreach (Categories category in homeBugaltery.ListCategories)
            {
                if (category.Type == false)
                    typeValue = 0;
                else
                    typeValue = 1;

                int rowIndex = dataGridViewCategory.Rows.Add(category.Name);
                dataGridViewCategory.Rows[rowIndex].Cells[1].Value = typeValue;
                dataGridViewCategory.Rows[rowIndex].Tag = category.Id;
            }


        }

  

        private void dataGridViewCategory_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridViewCategory.SelectedRows.Count == 0 || dataGridViewCategory.SelectedRows[0].Tag == null)
            {
                labelAddEdit.Text = "Додати нову категорію :";

                textBoxNewCategory.ReadOnly = false;

                textBoxNewCategory.Text = "";
                comboBoxType.SelectedIndex = 0;
                curentCategory = null;
                return;
            }

            labelAddEdit.Text = "Редагувати категорію :";

            int curentCategoryId = (int)dataGridViewCategory.SelectedRows[0].Tag;

            curentCategory = homeBugaltery.ListCategories.Find(c => c.Id == curentCategoryId);

            // Change category
            textBoxNewCategory.Text = curentCategory.Name;
            if (curentCategory.Type == false)
                comboBoxType.SelectedIndex = 0;
            else
                comboBoxType.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBoxNewCategory.Text == "" && comboBoxType.SelectedIndex == -1)
            {
                MessageBox.Show("Cannot add category!\nPlease check inputed data and try again!!!");
                return;
            }

            if (comboBoxType.SelectedIndex == 1)
                type = true;


            // Add New Category
            if (curentCategory == null)
            {
                actHomeBogaltery.SetCommand((int)HomeActionEnum.addCategory,
                                                                 new AddCategoryCommand(homeBugaltery, textBoxNewCategory.Text, type));

                actHomeBogaltery.DoAction((int)HomeActionEnum.addCategory);
            } // Change curent Categoruy
            else
            {
                actHomeBogaltery.SetCommand((int)HomeActionEnum.changeCategory,
                                                                new ChangeCategoryCommand(homeBugaltery, curentCategory.Id, textBoxNewCategory.Text, type));

                actHomeBogaltery.DoAction((int)HomeActionEnum.changeCategory);
            }

            updateCategory();

            textBoxNewCategory.Clear();
        }

        // DElete selected category
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Видалити? \nВи впевнені?");
            if (dataGridViewCategory.SelectedRows.Count > 0)
            {
                try
                {
                    homeBugaltery.deleteCategory(curentCategory.Id);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Не можливо видалити категорію!!!\nДетально:\n" + exc.Message, "Помилка!!!");
                }
                
            }
            updateCategory();
        }

        //Go to the last ROW in GRID
        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            labelAddEdit.Text = "Додати нову категорію :";

            int lastIndex = dataGridViewCategory.Rows.Count - 1;
            dataGridViewCategory.Rows[lastIndex].Selected = true;
            dataGridViewCategory.FirstDisplayedScrollingRowIndex = lastIndex;
        }

        private void btnClouse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
