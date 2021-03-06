﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;

using dms.tools;

namespace dms.view_models
{
    public class LearningScenarioViewModel : ViewmodelBase
    {
        private ActionHandler createHandler;
        private ActionHandler cancelHandler;

        public LearningScenarioViewModel()
        {
            createHandler = new ActionHandler(() => { }, e => false);
            cancelHandler = new ActionHandler(() => { }, e => true);
            Name = "Сценарий";
            MixSeed = "123";
            TeacherType = TeacherTypesList[0];
            SelectionType = SelectionTypesList[0];
        }

        public string Name { get; set; }
        public string TeacherType { get; set; }
        public string SelectionType { get; set; }
        public string MixSeed { get; set; }
        public string[] TeacherTypesList { get { return new string[] { "Обучатель 1", "Обучатель 2" }; } }
        public string[] SelectionTypesList { get { return new string[] { "Тестовая/обучающая", "Кроссвалидация" }; } }
        public ICommand CreateCommand { get { return createHandler; } }
        public ICommand CancelHandler { get { return cancelHandler; } }

    }

    public class LearningScenarioManagerViewModel : ViewmodelBase
    {
        private LearningScenarioViewModel selectedScenario;
        private ActionHandler propertiesHandler;
        private ActionHandler deleteHandler;
        private ActionHandler createHandler;

        public LearningScenarioManagerViewModel()
        {
            ScenarioList = new ObservableCollection<LearningScenarioViewModel>() 
            {
                new LearningScenarioViewModel 
                {
                    Name="Сценарий 1", 
                    TeacherType = "Обучатель 1", 
                    SelectionType="Тестовая/обучающая"
                },
                new LearningScenarioViewModel 
                {
                    Name="Сценарий 2", 
                    TeacherType = "Обучатель 2", 
                    SelectionType="Кроссвалидация"
                },
            };
            propertiesHandler = new ActionHandler(() => requestShowLearningScenario?.Invoke(SelectedScenario), e => SelectedScenario != null);
            deleteHandler = new ActionHandler(() => { }, e => SelectedScenario != null);
            createHandler = new ActionHandler(() => requestCreateLearningScenario?.Invoke(), e => true);
        }

        public event Action requestCreateLearningScenario;
        public event Action<LearningScenarioViewModel> requestShowLearningScenario;
        public ObservableCollection<LearningScenarioViewModel> ScenarioList { get; private set; }
        public LearningScenarioViewModel SelectedScenario 
        {
            get { return selectedScenario; }
            set 
            { 
                selectedScenario = value;
                deleteHandler.RaiseCanExecuteChanged();
                propertiesHandler.RaiseCanExecuteChanged();
            }
        }
        public ICommand PropertiesCommand { get { return propertiesHandler; } }
        public ICommand DeleteCommand { get { return deleteHandler; } }
        public ICommand CreateCommand { get { return createHandler; } }
    }
}
