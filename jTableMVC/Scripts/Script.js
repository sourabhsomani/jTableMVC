﻿/// <reference path="jtable/jquery.jtable.js" />
$(document).ready(function () {
    $('#MarksTable').jtable({
        title: 'Marks Detail',
        paging: true,
        pageSize: 10,
        sorting: true,
        defaultSorting: 'RollNumber ASC',

        actions: {
            listAction: '/Marks/GetStudentMarks',
            createAction: '/Marks/Create',
            updateAction: '/Marks/Edit',
            deleteAction: '/Marks/Delete'
        },
        fields: {
            ID: {
                key: true,
                list: false
            },
            RollNumber: {
                title: 'Roll Number',
                width: '15%'
            },
            Name: {
                title: 'Student Name',
                width: '45%'
            },
            MarksObtained: {
                title: 'Marks Obtained',
                width: '15%'
            },
            TotalMarks: {
                title: 'Total Marks',
                width: '15%',
                sorting:false
            }
        }
    });
    $('#MarksTable').jtable('load');
});
