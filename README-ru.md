# Веб-приложение "Прием в больнице"

## Цель проекта

Проект разработан в соответствии с техническим заданием по теме автоматизированная информационная система "Регистратура поликлиники". 
Была выбрана платформа разработки приложений ASP.NET MVC на языке программирования C#.

## Системные требования

###### Версия: .NET framework 4.8
###### Требования ресурсов:
* Visual Studio (2019)
* MS SQL Server (2019)
* Git
###### Необходимые расширения:
* Bootstrap.V3.Datetimepicker, Bootstrap.V3.Datetimepicker.CSS
* EntityFramework
* JQuery, JQuery.UI.Combined

## Этапы монтажа, сборки, ввода в эксплуатацию

## Документация

* [Metanit.com](https://metanit.com/sharp/mvc5/) - ASP.NET MVC C#
* [Professorweb.ru](https://professorweb.ru/my/ASP_NET/mvc/level1/) - ASP.NET MVC C#
* [Работа с entity framework](https://docs.microsoft.com/ru-ru/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application)
* [DateTimePicker for ASP.NET](https://docs.microsoft.com/ru-ru/aspnet/mvc/overview/older-versions/using-the-html5-and-jquery-ui-datepicker-popup-calendar-with-aspnet-mvc/using-the-html5-and-jquery-ui-datepicker-popup-calendar-with-aspnet-mvc-part-4)

## Технологии в проекте

Для удобного выбора даты и времени на активных окнах добавления записей применены свойства отображения datetimepicker от bootstrap:
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
Данный элемент описан в блоках @Html.EditorFor() в качестве свойства @type = "date/time".

## Описание

На данный момент проект находится в начальном состоянии, и уже рассчитан круг задач для дальнейшей работы:
* введение личного кабинета (с разделением прав доступа); 
* более удобный переход к редактированию, добавлению записей;
* удаление записей без предварительного перехода на страницу удаления;
* введение адресов по участкам;
* добавление календаря смен для врачей;
* только авторизованный пользователь сможет добавлять записи о приеме;
* при входе на главную страницу, будет отображаться удобная структура отделений с выбором врача, при выборе врача будет выполнено переключение на календарь смены, чтобы забронировать билет на прием к врачу.
