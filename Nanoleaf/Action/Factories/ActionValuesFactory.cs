using Nanoleaf.Action.Actions.ShapesPanelsActions;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.EffectConfig.Creators.Classes;
using Nanoleaf.Network.Classes.Requests.ShapesRequests;
using Nanoleaf.RequestAttributes;
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
        internal static ShapesUpdateEffectsActionValues CreateShapesUpdateEffectsActionValues(List<IShapesPanel> panels, Color colorValue, uint transitionTimeInMilliseconds)
        {
            string COMMAND = "display";
            string VERSION = "2.0";
            string ANIMTYPE = "static";
            bool LOOP = false;
            Palette palette = new Palette();
            int transitionTimeInTenthsOfSeconds = Convert.ToInt16(transitionTimeInMilliseconds) / 100;

            var animDataList = new List<AnimDataValues>();

            for (int i = 0; i < panels.Count; i++)
            {
                var panel = panels[i];
                var animData = new AnimDataValues(Convert.ToInt32(panel.GetPanelID()), 1, colorValue.R, colorValue.G, colorValue.B, colorValue.A, transitionTimeInTenthsOfSeconds);
                animDataList.Add(animData);
            }

            var values = new ShapesUpdateEffectsActionValues(COMMAND, VERSION, ANIMTYPE, animDataList, LOOP, palette);

            return values;
        }

        internal static ShapesUpdateEffectsActionValues CreateShapesFlashActionValues(List<IShapesPanel> panels, Color color, uint transitionTimeInTenthsOfSeconds)
        {
            string COMMAND = "display";
            string VERSION = "2.0";
            string ANIMTYPE = "static";
            bool LOOP = false;
            Palette palette = new Palette();

            var animDataList = new List<AnimDataValues>();

            for (int i = 0; i < panels.Count; i++)
            {
                var panel = panels[i];
                var animData = new AnimDataValues(Convert.ToInt32(panel.GetPanelID()), 1, color.R, color.G, color.B, color.A, Convert.ToInt16(transitionTimeInTenthsOfSeconds));
                animDataList.Add(animData);
            }

            var values = new ShapesUpdateEffectsActionValues(COMMAND, VERSION, ANIMTYPE, animDataList, LOOP, palette);

            return values;
        }

        internal static ShapesPanelsColorWaveActionValues CreateShapesUpdateColorWaveActionValues(Queue<IShapesPanel> panels, Color colorValue, uint transitionTimeInMilliseconds, uint intervalTimeInMilliseconds)
        {
            var panelEffectActionValuesTupleList = new Queue<Tuple<IShapesPanel, ShapesUpdateEffectsActionValues>>();
            foreach (var panel in panels)
            {
                var panelList = new List<IShapesPanel> { panel };
                var effectActionValues = CreateShapesUpdateEffectsActionValues(panelList, colorValue, transitionTimeInMilliseconds);
                var tuple = new Tuple<IShapesPanel, ShapesUpdateEffectsActionValues>(panel, effectActionValues);

                panelEffectActionValuesTupleList.Enqueue(tuple);
            }

            return new ShapesPanelsColorWaveActionValues(panelEffectActionValuesTupleList, transitionTimeInMilliseconds, intervalTimeInMilliseconds);
        }
    }
}
