# A management system for job applications

## Introduction
This project was created as a useful tool for me to keep track of my job applications. Its purpose is to not be something to contribute to nor to test it yourself, more just a showcase of something that I did. This README is also more of a showcase rather than a proper document. Technologies used to create it are as follows:
- WPF
- XAML
- .NET
- C#
- MySQL
- SQL

WPF and XAML were used as the backbone of the project, while .NET and C# were used to give functionality to everything and MySQL was used for the database. The version of the project seen here in this repository has functional code and everything to make it work, but I've removed some of the information used to access the database in the configuration file. Examples of the functional application will be given in this README. 

## Functionality and features

### Initial planning
Before I set out in actually creating this project, I spent some time planning out in my head as well as on a personal Word-document. What I had layed out have to be in the projects were as follows:
- The ability to add, edit and delete information.
- Editing information should be possible directly from the program so that it happens immediately in the database visibly to the user.
- The information to be added should include: the employer, job title, address, has the job application been replied to, did an interview happen and did employment happen.
- Some of the information has to be mandatory, some optional. 

I would say that I succeeded in these initial goals very well and ontop of them, I added in other features along the way. Some of these later features were:
- The about section, in which the user can see information about the program. 
- The ability to change language between Finnish and English or vice versa. 
- The date in which the application was sent.
- A link to the job posting.


### Information
With this management system, the user is able to upload, alter and delete information in relation to the job applications present in the database. Information to be included are as follows:
- The ID of the job application used as the primary key within the database. (**Required for entry into the database**)
- The name of the employer the job application is directed towards.(**Required for entry into the database**)
- The title or role of the job. (**Required for entry into the database**)
- The address in which the job is to take place or otherwise be located. (**Optional for entry into the database**)
- A link to the job posting. (**Optional for entry into the database**)
- The date in which the job application has been sent. (**Required for entry into the database**)
- Checkboxes for if the job application has been answered to, if an interview will or has happened and if hiring took place. (Checking the boxes will result in "YES" within the database and abstaining will result in "NO". 

Do note that the ID used for the job applications is created automatically using a function to generate a random number. The user cannot alter this ID and if the ID for whatever reason matches an ID already in the database, the user will be informed of it. The button used to clear all information also creates a new random ID. 

<p float="left">
<img src = "https://user-images.githubusercontent.com/63291585/213402006-c5c9e893-b2d1-4469-864b-de64b8c1ae35.JPG" width="450" height="450" />
</p>

### Buttons
The buttons for adding, altering and deleting information can be found at the bottom of the application window as well as a general clear button, which will clear all fields. In the top left cornet of the window, there is also a button to view information about the application. This button in turn opens a menu of buttons containing:
- Ability to access information about the version of the project and it's creator and creation date.
- The ability to switch language between Finnish and English.
-The ability to exit and close the application. 

<p float="left">
<img src = "https://user-images.githubusercontent.com/63291585/213402181-d94a5b70-d0ce-46e2-a338-2e9702f02a70.png" width="450" height="450" />
</p>

To show the information of the database to the user, a DataGrid is utilized with it being linked to the database and it's contents. A function to bring in already existing and update the information changed after certain functions is also present, so that the DataGrid is always kept updated. 
<p float="left">
<img src = "https://user-images.githubusercontent.com/63291585/213405395-e5df4cab-bf5c-4dd4-a311-ef0e3db8c056.JPG" width="350" height="350" />
<img src = "https://user-images.githubusercontent.com/63291585/213405458-f8a6dfd3-ca24-40a8-8ddd-f5f7b014399e.JPG" width="350" height="350" />
</p>

### Managing conflicts and errors
There are various different ways in which the program handles conflicts or errors related to duplicate IDs, required information missing and trying to alter information without having selected the job application to alter. 

<p float="left">
<img src = "https://user-images.githubusercontent.com/63291585/213416716-9d6f7322-3070-4ffd-8866-90eeb96748b1.JPG" width="350" height="350" />
<br>
(Error message for when a user attempts to add an application with the same ID as an already existing one)
</p>

<br>

<p float="left">
<img src = "https://user-images.githubusercontent.com/63291585/213417874-a19be829-3f55-4f74-8ea2-1312ad4eb795.JPG" width="350" height="350" />
<br>
(Error message for when a user attempts to add default values for the fields, which are mandatory to be filled)
</p>

<br>

<p float="left">
<img src = "https://user-images.githubusercontent.com/63291585/213418046-4b011827-9878-4805-9b69-b95dde070e4e.JPG" width="350" height="350" />
<br>
(Error message for when a user attempts to edit an application not found in the database)
</p>

<br>

<p float="left">
<img src = "https://user-images.githubusercontent.com/63291585/213418235-99760b50-3577-4cd2-8c8f-b8bec7ce21c2.JPG" width="350" height="350" />
<br>
(Error message for when a user attempts to delete an application not found in the database)
</p>

<br>

<p float="left">
<img src = "https://user-images.githubusercontent.com/63291585/213418411-5536b6d7-071b-4f6f-a5d7-8028abcd2ce9.JPG" width="350" height="350"/>
<br>
(Error message for when a user attempts to select an already selected language)
</p>
