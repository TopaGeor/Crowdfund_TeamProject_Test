// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.js-product-category-button').on('click', () => {
    let button = $('.js-product-category-button');
    $('.js-product-category-dropdown').on('click', (evt) => {
        button.text(evt.target.textContent);
    });
});

$('#sandbox-container .input-group.date').datepicker({
    format: "yyyy/mm/dd",
    weekStart: 1,
    startDate: "Today",
    todayBtn: "linked",
    clearBtn: true,
    daysOfWeekHighlighted: "0,6",
    autoclose: true,
    todayHighlight: true
});