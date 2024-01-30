using Nanoleaf.Action.Actions;
using Nanoleaf.Action.Actions.ShapesActions;
using Nanoleaf.Action.Classes;
using Nanoleaf.Action.Factories;
using Nanoleaf.Action.Interfaces;
using Nanoleaf.Devices.Factories;
using Nanoleaf.Devices.Interfaces;
using Nanoleaf.Devices.ShapesFinderClasses;
using Nanoleaf.EffectConfig.Creators.Interfaces;
using Nanoleaf.Effects.Enums;
using Nanoleaf.Network;
using Nanoleaf.Network.Classes;
using Nanoleaf.Network.Classes.Responses;
using Nanoleaf.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nanoleaf.Devices.Classes
{
    public class ShapesController
    {
        internal Dictionary<IShapesPanel, INanoleafShapes> panelShapesDictionary { get; private set; }
        private HashSet<INanoleafShapes> controllers;
        private ActionController actionController;
        private ShapesFinder shapesFinder;
        private ShapesFactory shapesFactory;
        private readonly ActionFactory actionFactory;
        private readonly List<AvailableEffects> allAvailableEffectsList;

        public ShapesController()
        {
            shapesFactory = new ShapesFactory();
            actionController = new ActionController();
            shapesFinder = new ShapesFinder();
            controllers = new HashSet<INanoleafShapes>();
            shapesFinder.FoundControllerHandler += FoundController;
            panelShapesDictionary = new Dictionary<IShapesPanel, INanoleafShapes>();
            actionFactory = new ActionFactory();

            allAvailableEffectsList = new List<AvailableEffects>();
            allAvailableEffectsList.Add(AvailableEffects.TurnOff);
            allAvailableEffectsList.Add(AvailableEffects.TurnOn);
            allAvailableEffectsList.Add(AvailableEffects.ColorChange);
            allAvailableEffectsList.Add(AvailableEffects.FadeIn);
            allAvailableEffectsList.Add(AvailableEffects.Flash);
            allAvailableEffectsList.Add(AvailableEffects.FadeIn);
            allAvailableEffectsList.Add(AvailableEffects.FadeOut);
        }

        //public void UpdateBrightness(UpdateBrightnessActionValues values)
        //{
        //    var action = new ShapesUpdateBrightnessAction(LinkedShapes, values);
        //    action.Perform();
        //}

        //public void UpdateEffects(ShapesUpdateEffectsActionValues values)
        //{
        //    var action = new ShapesUpdateEffectsAction(LinkedShapes, values);
        //    action.Perform();
        //}

        public void InitializeSystem()
        {
            shapesFinder.FindShapesControllers();
        }

        private void FoundController(object sender, Uri controllerUri)
        {
            var shapes = shapesFactory.CreateShapes(controllerUri);

            if (shapes != null)
            {
                if (!controllers.Contains(shapes))
                {
                    controllers.Add(shapes);

                    foreach(IShapesPanel panel in shapes.Panels)
                    {
                        if(!panelShapesDictionary.ContainsKey(panel))
                            panelShapesDictionary.Add(panel, shapes);
                        else
                            panelShapesDictionary[panel] = shapes;
                    }
                }
            }
        }

        public List<IShapesPanel> GetAllAvailableDevices()
        {
            List<IShapesPanel> list = new List<IShapesPanel>();

            foreach (INanoleafShapes controller in controllers)
            {
                list.AddRange(controller.Panels);
            }

            return list;
        }

        public AllLightControllerInfoResponse GetAllLightControllerInfo(INanoleafShapes shapes)
        {
            var action = new GetAllLightControllerInfoAction(shapes);
            var result = action.Perform();

            return result;
        }

        public void PerformSimpleAction(IAction action)
        {
            actionController.PerformSimpleAction(panelShapesDictionary, action);
        }

        public void PerformEffectAction(INanoleafEffectAction action)
        {
            actionController.PerformEffectAction(panelShapesDictionary, action);
        }

        public List<AvailableEffects> GetAllEffectList()
        {
            return allAvailableEffectsList;
        }

        public int GetShapesControllerCount()
        {
            return controllers.Count;
        }

        public IAction CreateAction(HashSet<IShapesPanel> shapesPanels, AvailableEffects chosenEffect, IEffectConfigSet effectConfigSet)
        {
            var dictionary = new Dictionary<IShapesPanel, INanoleafShapes>();

            foreach(IShapesPanel panel in shapesPanels)
            {
                if (panelShapesDictionary.ContainsKey(panel))
                    dictionary.Add(panel, panelShapesDictionary[panel]);
            }

            var action = actionFactory.CreatePanelsAction(dictionary, chosenEffect, effectConfigSet);

            return action;
        }

        public IAction CreateShapesAction(HashSet<INanoleafShapes> shapesSet, AvailableEffects chosenEffect, IEffectConfigSet effectConfigSet)
        {
            var list = new List<INanoleafShapes>();

            foreach (INanoleafShapes shapes in shapesSet)
            {
                if (controllers.Contains(shapes))
                    list.Add(shapes);
            }

            var action = actionFactory.CreateShapesAction(list, chosenEffect, effectConfigSet);

            return action;
        }

        public List<INanoleafShapes> GetAllShapes(List<string> ids)
        {
            List<INanoleafShapes> results = new List<INanoleafShapes>();
            var controllersList = controllers.ToList();

            foreach (string id in ids)
            {
                var controller = controllers.Select(x => x).Where(x => Convert.ToString(x.ID) == id).FirstOrDefault();

                if (controller != null)
                    results.Add(controller);
            }

            return results;
        }

        public List<IShapesPanel> GetAllPanels(List<string> ids)
        {
            List<IShapesPanel> results = new List<IShapesPanel>();
            var panels = panelShapesDictionary.Keys.ToList();

            foreach (string id in ids)
            {
                var controller = panels.Select(x => x).Where(x => Convert.ToString(x.GetPanelID()) == id).FirstOrDefault();

                if (controller != null)
                    results.Add(controller);
            }

            return results;
        }
    }
}