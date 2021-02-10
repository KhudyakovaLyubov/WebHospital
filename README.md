# The Web-application "The reception in the hospital"

## The purpose of the project

The project was developed according to the technical task on the topic automated information system "Polyclinic registry". The application development platform was selected ASP.NET MVC in the C# programming language.

## System requirements

###### Version: .NET framework 4.8
###### Resource requirements:
* Visual Studio (2019)
* MS SQL Server (2019)
* Git
###### Required extensions:
* Bootstrap.V3.Datetimepicker, Bootstrap.V3.Datetimepicker.CSS
* EntityFramework
* JQuery, JQuery.UI.Combined

## Steps for installation, assembly, commissioning

## Documentation

* [Metanit.com](https://metanit.com/sharp/mvc5/) - ASP.NET MVC C#
* [Professorweb.ru](https://professorweb.ru/my/ASP_NET/mvc/level1/) - ASP.NET MVC C#
* [Работа с entity framework](https://docs.microsoft.com/ru-ru/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application)
* [DateTimePicker for ASP.NET](https://docs.microsoft.com/ru-ru/aspnet/mvc/overview/older-versions/using-the-html5-and-jquery-ui-datepicker-popup-calendar-with-aspnet-mvc/using-the-html5-and-jquery-ui-datepicker-popup-calendar-with-aspnet-mvc-part-4)

## Technologies in the project

Added an element for easy date and time selection:
~~~
<form method="post" action="@Url.Action("CreateReception", "Reception")">
    @using (Html.BeginForm())
    {
        @Html.LabelFor(model => model.Employee, "Врач")
        <br />
        @Html.DropDownListFor(model => model.Employee, ViewBag.employees as SelectList, new { @class = "form-control" })
        <br />
        <br />
        @Html.LabelFor(model => model.Patient, "Пациент")
        <br />
        @Html.DropDownListFor(model => model.Patient, ViewBag.patients as SelectList, new { @class = "form-control" })
        <br />
        <br />
        @Html.LabelFor(model => model.LogInDate, "Дата")
        <br />
        @Html.EditorFor(model => model.LogInDate, new { htmlAttributes = new { @class = "form-control", @type = "date" } })
        <br />
        <br />
        @Html.LabelFor(model => model.LogInTime, "Время")
        <br />
        @Html.EditorFor(model => model.LogInTime, new { htmlAttributes = new { @class = "form-control", @type = "time" } })
        <br />
        <br />
        <input type="submit" class="btn btn-primary" value="Добавить" />
    }
</form>
~~~
By including the type attributes in EditFor (), the datetimepicker from bootstrap is displayed.

## Description

At the moment, the project is in its initial state, and a range of tasks has been calculated for further work:
* introduction of the personal account (with the separation of access rights); 
* more convenient transition to editing, adding records;
* deleting records without first going to the delete page;
* introduction of addresses by section;
* adding a shift calendar for doctors;
* only an authorized user will be able to add appointment entries;
* when you enter the main page, you will see a nice structure of departments with the choice of a doctor and when you select a doctor, you will switch to the shift calendar to reserve a ticket for an appointment with a doctor.
