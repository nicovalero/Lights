using Nanoleaf.Action.Actions.ShapesPanelsActions;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.EffectConfig.Creators.Classes;
using Nanoleaf.Network.Classes.Requests.ShapesRequests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanoleaf.Action.Factories
{
    internal static class ActionValuesFactory
    {
        internal static ShapesUpdateEffectsActionValues CreateShapesUpdateEffectsActionValues(List<IShapesPanel> panels, Color colorValue)
        {
            string COMMAND = "display";
            string VERSION = "2.0";
            string ANIMTYPE = "static";
            bool LOOP = false;
            string[] PALETTE = new string[] { };

            var animDataList = new List<AnimDataValues>();

            for (int i = 0; i < panels.Count; i++)
            {
                var panel = panels[i];
                var animData = new AnimDataValues(Convert.ToInt32(panel.GetPanelID()), 1, colorValue.R, colorValue.G, colorValue.B, colorValue.A, 1);
                animDataList.Add(animData);
            }

            var values = new ShapesUpdateEffectsActionValues(COMMAND, VERSION, ANIMTYPE, animDataList, LOOP, PALETTE);

            return values;
        }

        internal static ShapesPanelsColorWaveActionValues CreateShapesUpdateColorWaveActionValues(Queue<IShapesPanel> panels, Color colorValue, uint transitionTimeInMilliseconds)
        {
            var panelEffectActionValuesTupleList = new Queue<Tuple<IShapesPanel, ShapesUpdateEffectsActionValues>>();
            foreach (var panel in panels)
            {
                var panelList = new List<IShapesPanel> { panel };
                var effectActionValues = CreateShapesUpdateEffectsActionValues(panelList, colorValue);
                var tuple = new Tuple<IShapesPanel, ShapesUpdateEffectsActionValues>(panel, effectActionValues);

                panelEffectActionValuesTupleList.Enqueue(tuple);
            }

            return new ShapesPanelsColorWaveActionValues(panelEffectActionValuesTupleList, transitionTimeInMilliseconds);
        }
    }
}
