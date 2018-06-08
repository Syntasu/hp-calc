using hp_calc.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hp_calc.UI
{
    /// <summary>
    ///     A struct for storing information about a control we
    ///     added to the UIGenerator.
    /// </summary>
	public struct UIDesc
	{
		public string Name;
		public Vector2 Position;
		public Vector2 Size;
        public bool Visible;
		public Control ControlRef;

		public UIDesc(string name, bool visible, Vector2 position, Vector2 size, Control controlRef)
		{
			Name = name;
			Position = position;
            Visible = visible;
			Size = size;
			ControlRef = controlRef;
		}
	}
    
    /// <summary>
    ///     The class that is responsible for instantiating new controls, adding to the form
    ///     and keeping track of them (via the UIDesc).
    /// </summary>
	public class UIGenerator
	{
        /// <summary>
        ///     UIGrid is need translate the position and size to something that can be 
        ///     projected onto a grid.
        /// </summary>
		private UIGrid grid;

        /// <summary>
        ///     Storing the controls by name and their descriptions.
        /// </summary>
        public Dictionary<string, UIDesc> Controls { get; } = new Dictionary<string, UIDesc>();

        /// <summary>
        ///     Iterate of all the controls we want to render to the screen.
        /// </summary>
        public IEnumerable<Control> GetControlRenderList
		{
			get
			{
				foreach (var kvp in Controls)
				{
                    if (!kvp.Value.Visible) continue;

					yield return kvp.Value.ControlRef;
				}
			}
		}

        public UIGenerator(UIGrid grid)
		{
			this.grid = grid;
		}

        /// <summary>
        ///     Refresh the positions and the size of the user interface.
        ///     We adjust the grid and translate all the positions and sizes again.
        /// </summary>
        /// <param name="width"> The current width. </param>
        /// <param name="height"> The current height. </param>
        public void Refresh(int width, int height)
        {
            grid.Refresh(width, height);

            //Read in the descriptions, use that to determine location and size.
            foreach (var control in Controls)
            {
                UIDesc desc = control.Value;

                desc.ControlRef.Location = grid.Translate(desc.Position.x, desc.Position.y);
                desc.ControlRef.Size = grid.Translate(desc.Size.x, desc.Size.y);
            }
        }

        public T AddControl<T>(string name, float x, float y, float width, float height, UIArgumentList args)
            where T : Control
        {
            //Check if we are not adding any duplicates.
            if (Controls.ContainsKey(name))
            {
                MessageBox.Show("Layout error, trying to add elements with same name. Ignoring element....", "Layout parsing warning");
                return default(T);
            }

            //Translate the position and the size.
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(width, height);

            //Create and set the properties of a control.
            Control control = (Control)Activator.CreateInstance(typeof(T));
            control.Location = position;
            control.Size = size;
            control.Text = args.Get<string>(UIArgumentProperty.Value);

            //Add the specific properties for each type of control.
            if(control is TextBox)
            {
                TextBox textbox = (TextBox)control;
                textbox.Multiline = args.Get<bool>(UIArgumentProperty.Multiline);
                textbox.ReadOnly = args.Get<bool>(UIArgumentProperty.Readonly);
            }
            else if(control is CheckBox)
            {
                CheckBox checkbox = (CheckBox)control;
                checkbox.Checked = args.Get<bool>(UIArgumentProperty.Checked);
            }
            else if (control is RadioButton)
            {
                RadioButton radioButton = (RadioButton)control;
                radioButton.Checked = args.Get<bool>(UIArgumentProperty.Checked);
            }

            UIDesc description = new UIDesc(
                name, args.Get<bool>(UIArgumentProperty.Visible),
                new Vector2(x,y), new Vector2(width, height), control
            );

            //Add the control to the collection.
            Controls.Add(name, description);
            return control as T;
        }
	}
}
