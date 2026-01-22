using System;
using System.Collections.Generic;
using System.IO;
using R3;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    class Moduler : EditorWindow {
        void CreateGUI() {
            List<string> filteredList = new();
            ListView filteredView = new();
            VisualElement splitContainer = new();
            ModularView view = new(splitContainer, filteredView, rootVisualElement);
            ModulerLoading modulerLoading = new(filteredList);
            ModulerController controller = new(filteredList, modulerLoading);
            Subject<int> filteredViewClicked = new();
            ModulerListView filteredListStyle = new(filteredList, filteredView, filteredViewClicked);
            Button button = new();
            modulerLoading.Start();
            view.Start();
            filteredListStyle.Start();
            TheModuler.Bind_RemoveFromFilteredList(filteredViewClicked, controller);
            TheModuler.Bind_Rebuild(filteredViewClicked, filteredView);
            List<string> projectAssemblyList = new();
            ListView listView = new();
            Subject<int> listViewClicked = new();
            ModulerListView _listStyle = new(projectAssemblyList, listView, listViewClicked);
            ProjectAssemblyController _controller = new(projectAssemblyList);
            ModulerSelectionView _view = new(splitContainer, listView);
            SelectionComponentBinder binder = new(listViewClicked, projectAssemblyList, filteredView, filteredList, modulerLoading);
            ButtonController buttonController = new(_listStyle, _controller, _view, binder);
            ButtonView buttonView = new(button, rootVisualElement, buttonController);
            buttonView.Start();
        }
    }
}

//internal class Moduler : EditorWindow {
//    void CreateGUI() {
//        ModulerContext context = new(service);
//        ModularView view = new(splitContainer, filteredView, rootVisualElement);
//        ModulerLoading modulerLoading = new(filteredList);
//        ModulerController controller = new(filteredList, modulerLoading);
//        Subject<int> filteredViewClicked = new();
//        ModulerListView filteredListStyle = new(filteredList, filteredView, filteredViewClicked);
//        Button button = new();
//        modulerLoading.Start();
//        view.Start();
//        filteredListStyle.Start();
//        TheModuler.Bind_RemoveFromFilteredList(filteredViewClicked, controller);
//        TheModuler.Bind_Rebuild(filteredViewClicked, filteredView);
//        List<string> projectAssemblyList = new();
//        ListView listView = new();
//        Subject<int> listViewClicked = new();
//        ModulerListView _listStyle = new(projectAssemblyList, listView, listViewClicked);
//        ProjectAssemblyController _controller = new(projectAssemblyList);
//        ModulerSelectionView _view = new(splitContainer, listView);
//        SelectionComponentBinder binder = new(listViewClicked, projectAssemblyList, filteredView, filteredList, modulerLoading);
//        ButtonController buttonController = new(_listStyle, _controller, _view, binder);
//        ButtonView buttonView = new(button, rootVisualElement, buttonController);
//        buttonView.Start();
//    }
