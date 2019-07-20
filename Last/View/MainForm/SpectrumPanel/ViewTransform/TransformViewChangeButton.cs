using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Transform view project plan
/*1. SignalView
 1.1 Differents
     */

namespace SpectrumVisor
{
    class TransformViewChangeBox : ComboBox
    {
            public TransformViewChangeBox(TransformControler controller)
            {
                Items.Add(new BoxItem(ViewVersion.Round, "Окружность"));

                SelectedIndexChanged += (sender, ev) => {
                    controller.SwitchView(((BoxItem)SelectedItem).Type);
                };
            }

            //добавляет enum'у строковое представление
            class BoxItem
            {
                public readonly ViewVersion Type;
                public string Name { get; private set; }

                public BoxItem(ViewVersion type, string name)
                {
                    Type = type;
                    Name = name;
                }

                public override string ToString()
                {
                    return Name;
                }
            }
    }
}
