﻿using hp_calc.Data;
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

        //TODO: Better method....
        public void AddTextbox(string name, float x, float y, float w, float h, UIArgumentList args)
		{
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            TextBox textBox = new TextBox
            {
                Text = args.Get<string>(UIArgumentProperty.Value),
                Multiline = args.Get<bool>(UIArgumentProperty.Multiline),
                ReadOnly = args.Get<bool>(UIArgumentProperty.Readonly),
                Location = position,
                Size = size
            };

            if (Controls.ContainsKey(name))
            {
                MessageBox.Show("Layout error, trying to add elements with same name. Ignoring element....", "Layout parsing warning");
                return;
            }

            Controls.Add(name, MakeUIDescription(
                name,
                args.Get<bool>(UIArgumentProperty.Visible),
                new Vector2(x, y),
                new Vector2(w, h), textBox)
            );
        }

        //TODO: Better method....
        public void AddButton(string name, float x, float y, float w, float h, UIArgumentList args)
		{
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            Button button = new Button
            {
                Text = args.Get<string>(UIArgumentProperty.Value),
                Location = position,
                Size = size
            };

            if (Controls.ContainsKey(name))
            {
                MessageBox.Show("Layout error, trying to add elements with same name. Ignoring element....", "Layout parsing warning");
                return;
            }

            Controls.Add(name, MakeUIDescription(
                name,
                args.Get<bool>(UIArgumentProperty.Visible),
                new Vector2(x, y),
                new Vector2(w, h), button)
            );
        }

        //TODO: Better method....
        public void AddCheckBox(string name, float x, float y, float w, float h, UIArgumentList args)
        {
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            CheckBox checkbox = new CheckBox
            {
                Text = args.Get<string>(UIArgumentProperty.Value),
                Checked = args.Get<bool>(UIArgumentProperty.Checked),
                Location = position,
                Size = size
            };

            if (Controls.ContainsKey(name))
            {
                MessageBox.Show("Layout error, trying to add elements with same name. Ignoring element....", "Layout parsing warning");
                return;
            }

            Controls.Add(name, MakeUIDescription(
                name,
                args.Get<bool>(UIArgumentProperty.Visible),
                new Vector2(x, y),
                new Vector2(w, h), checkbox)
            );
        }

        //TODO: Better method....
        public void AddLabel(string name, float x, float y, float w, float h, UIArgumentList args)
        {
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            Label label = new Label
            {
                Text = args.Get<string>(UIArgumentProperty.Value),
                Location = position,
                Size = size
            };

            if (Controls.ContainsKey(name))
            {
                MessageBox.Show("Layout error, trying to add elements with same name. Ignoring element....", "Layout parsing warning");
                return;
            }

            Controls.Add(name, MakeUIDescription(
                name,
                args.Get<bool>(UIArgumentProperty.Visible),
                new Vector2(x, y),
                new Vector2(w, h), label)
            );
        }

        //TODO: Better method....
        public void AddList(string name, float x, float y, float w, float h, UIArgumentList args)
        {
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            ListBox list = new ListBox
            {
                Location = position,
                Size = size,
            };

            if (Controls.ContainsKey(name))
            {
                MessageBox.Show("Layout error, trying to add elements with same name. Ignoring element....", "Layout parsing warning");
                return;
            }

            Controls.Add(name, MakeUIDescription(
                name,
                args.Get<bool>(UIArgumentProperty.Visible),
                new Vector2(x, y),
                new Vector2(w, h), list)
            );
        }

        //TODO: Better method....
        public void AddRadio(string name, float x, float y, float w, float h, UIArgumentList args)
        {
            Vector2 position = grid.Translate(x, y);
            Vector2 size = grid.Translate(w, h);

            RadioButton button = new RadioButton
            {
                Text = args.Get<string>(UIArgumentProperty.Value),
                Checked = args.Get<bool>(UIArgumentProperty.Checked),
                Location = position,
                Size = size,
            };

            if(Controls.ContainsKey(name))
            {
                MessageBox.Show("Layout error, trying to add elements with same name. Ignoring element....", "Layout parsing warning");
                return;
            }

            Controls.Add(name, MakeUIDescription(
                name, 
                args.Get<bool>(UIArgumentProperty.Visible), 
                new Vector2(x, y), 
                new Vector2(w, h), button)
            );
        }

        //TODO: Only call this one time and remove the method, inline it with the general method.
        private UIDesc MakeUIDescription(string name, bool visible, Vector2 position, Vector2 size, Control control)
		{
			return new UIDesc(name, visible, position, size, control);
		}
	}
}
