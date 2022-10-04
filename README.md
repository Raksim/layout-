# Задание на экзамен по ПМ.05 (вариант 2 ДЭ2021)

<!-- 

Разобрать импорт на примерах (траблы экселя)

Количество продаж за год: геттер для выборки из другой таблицы

Показ картинки-заглушки

сортировка по двум независимым критериям (выбор из выпадающего списка)

Тестовые сценарии

Руководство пользователя

 -->

## Описание предметной области

Вашей задачей является разработка системы для производственной компании, которая ежедневно выпускает продукцию в большом объеме, а также реализует ее агентам, которые в дальнейшем продают эти товары конечным потребителям.

### Основное задание на разработку

Наша компания производит туалетную бумагу под брендом “Лопушок”. На протяжении нескольких лет мы выпускаем бумагу различной плотности и с разным количеством слоев. Сейчас мы хотим расширить наше производство, а для этого в первую очередь нам необходима система для хранения информации о нашей продукции.
Вам предстоит разработать подсистему для работы с продукцией нашей компании, которая должна включать в себя следующий функционал:

* просмотр списка продукции,
* добавление/удаление/редактирование данных о продукции,
* управление списком материалов, необходимых для производства продукции.

### Название приложения

Используйте соответствующие названия для ваших приложений и файлов. Так, например, наименование настольного приложения должно обязательно включать название компании-заказчика.

### Руководство по стилю

Визуальные компоненты должны соответствовать руководству по стилю, предоставленному в качестве ресурсов к заданию в соответствующем файле. Обеспечьте соблюдение требований всех компонентов в следующих областях:
* цветовая схема,
* размещение логотипа,
* использование шрифтов,
* установка иконки приложения.

### Обратная связь с пользователем

Уведомляйте пользователя о совершаемых им ошибках или о запрещенных в рамках задания действиях, запрашивайте подтверждение перед удалением, предупреждайте о неотвратимых операциях, информируйте об отсутствии результатов поиска и т.п. Окна сообщений соответствующих типов (например, ошибка, предупреждение, информация) должны отображаться с соответствующим заголовком и пиктограммой. Текст сообщения должен быть полезным и информативным, содержать полную информацию о совершенных ошибках пользователя и порядок действий для их исправления. Также можно использовать визуальные подсказки для пользователя при вводе данных.

### Обработка ошибок

Не позволяйте пользователю вводить некорректные значения в текстовые поля сущностей. Например, в случае несоответствия типа данных или размера поля введенному значению.

Оповестите пользователя о совершенной им ошибке.

Обратите внимание на использование абсолютных и относительных путей к изображениям. Приложение должно корректно работать в том числе и при перемещении папки с исполняемым файлом.

При возникновении непредвиденной ошибки приложение не должно аварийно завершать работу.

### Предоставление результатов

Все практические результаты должны быть переданы заказчику путем загрузки файлов на публичный репозиторий системы контроля версий git. Практическими результатами являются
* исходный код приложения (в виде коммита текущей версии проекта, но не архивом), 
* исполняемые файлы, 
* прочие графические/текстовые файлы.

Для оценки работы будет учитываться только содержимое репозитория. При оценке рассматриваются заметки только в электронном виде (`readme.md`). Рукописные примечания не будут использоваться для оценки.

### Проектирование требований

Для согласования процесса разработки с заказчиком Вам необходимо ознакомиться с описанием предметной области и сделать диаграмму прецедентов (Use Case) для основных пользователей системы.

Сохраните файл с диаграммой в формате PDF:
`UseCase.pdf`.

### Спецификации к UseCase

Создайте спецификации к 3 самым важным прецедентам предметной области по вашему мнению. Не забудьте указать в каждой спецификации название прецедента, актера, цель выполнения прецедента, предусловия, главную последовательность по шагам, альтернативные последовательности и постусловия.

### Восстановление базы данных из скрипта

Для восстановления таблиц в созданную базы данных воспользуйтесь предоставленным скриптом (`ms.sql`). В процессе разработки приложения Вы можете изменять базу данных на свое усмотрение.

### Импорт данных

Заказчик системы предоставил файлы с данными (с пометкой import в ресурсах) для переноса в новую систему. Подготовьте данные файлов для импорта и загрузите в разработанную базу данных.

### Разработка desktop-приложений

#### Список агентов

В связи с тем, что компания не реализует продукцию конечным потребителям, у нас есть множество агентов по всей стране, которые продают нашу продукцию от лица нашего бренда. Необходимо вести учёт всех агентов, а также статистику по их продажам.

Реализуйте окно для показа краткой информации об агентах: логотип, наименование, количество продаж за год, телефон и тип агента.

При отсутствии изображения необходимо вывести картинку-заглушку из ресурсов (`picture.png`).

Количество продаж вычисляется как общее количество проданных единиц продукции за последний год
(365 дней).

Пользователь должен иметь возможность отсортировать агентов (по возрастанию и убыванию) по следующим параметрам: наименование и приоритет агента. Выбор сортировки должен быть реализован с помощью выпадающего списка.

Кроме этого, пользователь должен иметь возможность отфильтровать данные по типу агента. Все типы из
базы данных должны быть выведены в выпадающий список для фильтрации. Первым элементом в выпадающем списке должен быть “Все типы”, при выборе которого настройки фильтра сбрасываются.

Пользователь должен иметь возможность искать агентов, используя поисковую строку. Поиск должен осуществляться по наименованию и контактным данным (email и номер телефона агента).

Поиск, сортировка и фильтрация должны происходить в реальном времени, без необходимости нажатия
кнопки “найти”/”отфильтровать” и т.п. Фильтрация и поиск должны применяться совместно. Параметры сортировки, выбранные ранее пользователем, должны сохраняться и во время фильтрации с поиском.

#### Добавление/редактирование агентов

Необходимо добавить возможность редактирования данных существующего агента, а также добавление
нового агента в новом окне - форме для добавления/редактирования агента.

На форме должны быть предусмотрены следующие поля: наименование, тип агента (выпадающий
список), приоритет, логотип компании, адрес, ИНН, КПП, имя директора, телефон и email компании.

При открытии формы для редактирования все поля выбранного объекта должны быть подгружены в соответствующие поля из базы данных, а таблица заполнена актуальными значениями.

Приоритет агента и количество продукции должны быть целыми неотрицательными числами.

Пользователь может добавить/заменить логотип агента.

Для того чтобы администратор случайно не изменял несколько агентов, предусмотрите невозможность открытия более одного окна редактирования.

#### Удаление агента

В главном должна присутствовать кнопка “Удалить”, которая удаляет агента из базы данных. При этом должны соблюдаться следующие условия. Если у агента есть информация о точках продаж агентов или история изменения приоритета, то эта информация должна быть удалена вместе с агентом. Но если у агента есть информация о реализации продукции, то удаление агента из базы данных должно быть запрещено. После удаления агента система должна сразу вернуть пользователя обратно к списку агентов.

После редактирования/добавления/удаления агента данные в окне списка агентов должны быть обновлены. 

### Разработка тестовых сценариев (Test-cases)

Для выполнения процедуры тестирования удаления агентов Вам нужно описать пять сценариев. Удаление может быть выполнимо, а может быть отклонено согласно требованиям предметной области.

Необходимо, чтобы варианты тестирования демонстрировали различные исходы работы алгоритма. Для описания тестовых сценариев в ресурсах предоставлен шаблон `testing-template.docx.`

### Создание руководства пользователя

Вам необходимо разработать руководство пользователя для вашего настольного приложения, которое описывает последовательность действий для выполнения всех функций вашей системы.

При подготовке документации старайтесь использовать живые примеры и скриншоты вашей системы для более наглядного пояснения шагов работы с различным функционалом.

Обратите внимание на оформление документа: оформите титульный лист, используйте автоматическую нумерацию страниц, разделите руководство на подразделы и сформируйте оглавление, используйте ссылки на рисунки, нумерованные и маркированные списки для описания шагов и т.д.

Сохраните итоговый документ с руководством пользователя в формате PDF, используя в качестве названия следующий шаблон: `Руководство пользователя.pdf`.
