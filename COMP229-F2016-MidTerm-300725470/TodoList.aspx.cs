using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP229_F2016_MidTerm_300725470.Models;
using System.Web.ModelBinding;

namespace COMP229_F2016_MidTerm_300725470
{
    public partial class TodoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the Todo data
                this.GetTodo();
            }
        }
        private void GetTodo()
        {
            // connect to EF DB
            using (TodoContext db = new TodoContext())
            {
                // query the Student Table using EF and LINQ
                var Todo = (from allTodo in db.Todos
                            select allTodo);

                // bind the result to the Todo GridView
                TodoGridView.DataSource = Todo.ToList();
                TodoGridView.DataBind();
            }
        }
    }
}   