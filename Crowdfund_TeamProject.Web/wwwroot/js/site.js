// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function validateEmail(email) {

    if (!email || email.trim().length === 0) {
        return false;
    }

    if (!email.includes('@')) {
        return false;
    }

    if (!email.includes('.')) {
        return false;
    }

    return true;
}
let emailOk = false;


let $emailInput = $('.js-email');
$emailInput.on('input', (evt) => {
    let $email = $(evt.currentTarget).val();
    let result = validateEmail($email);
    let $validationMessage = $('.js-validation-email');

    if (!result) {
        $validationMessage.show();
    } else {
        $validationMessage.hide();
        emailOk = true;
    }
    button();
});

function button() {
    if (emailOk) {
        let $button = $('.js-submit-creator');
        $button.attr('disabled', false);
    }
}

$('.js-submit-creator').on('click', () => {
    $('.js-submit-creator').attr('disabled', true);
    let name = $('.js-name').val();
    let email = $('.js-email').val();

    let data = JSON.stringify({
        name: name,
        email: email
    });

    $.ajax({
        url: '/creator/CreateCreator',
        type: 'POST',
        contentType: 'application/json',
        data: data
    }).done((creator) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-creator-alert');
        $alertArea.attr("class", "alert alert-success");
        $alertArea.html(`Successfully added Creatot Account  ${creator.name}`);
        $alertArea.show();
        $('form.js-create-creator').hide();
    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-creator-alert');
        $alertArea.attr("class", "alert alert-danger");
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();

        setTimeout(function () {
            $('.js-submit-creator').attr('disabled', false);
        }, 300);
    });
});


let $emailBacker = $('.js-email');
$emailBacker.on('input', (evt) => {
    let $email = $(evt.currentTarget).val();
    let result = validateEmail($email);
    let $validationMessage = $('.js-validation-email');

    if (!result) {
        $validationMessage.show();
    } else {
        $validationMessage.hide();
        emailOk = true;
    }
    buttonBacker();
});

function buttonBacker() {
    if (emailOk) {
        let $button = $('.js-submit-backer');
        $button.attr('disabled', false);
    }
}

$('.js-submit-backer').on('click', () => {
    $('.js-submit-backer').attr('disabled', true);
    let name = $('.js-name').val();
    let email = $('.js-email').val();

    let data = JSON.stringify({
        name: name,
        email: email
    });

    $.ajax({
        url: '/backer/Create',
        type: 'POST',
        contentType: 'application/json',
        data: data
    }).done((backer) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-backer-alert');
        $alertArea.attr("class", "alert alert-success");
        $alertArea.html(`Successfully added Backer Account  ${backer.name}`);
        $alertArea.show();
        $('form.js-create-backer').hide();
    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-backer-alert');
        $alertArea.attr("class", "alert alert-danger");
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();

        setTimeout(function () {
            $('.js-submit-backer').attr('disabled', false);
        }, 300);
    });
});
