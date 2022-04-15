
$(document).ready(function curdopr() {


    $.ajax
        (
            {

                type: 'GET',
                url: '/Home/Curd',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',

                _success: function (result) {

                    var MSfirstname = document.getElementById("mSfirstname")
                    var MSlastname = document.getElementById("mSlastname")
                    var MSemail = document.getElementById("mSemail")
                    var Msmobileno = document.getElementById("mSmobileno")
                    var Mszodiac = document.getElementById("mSzodiac")
                    var Msbirthdate = document.getElementById("mSbirthdate")

                    MSfirstname.value = result.firstName
                    MSlastname.value = result.lastName
                    MSemail.value = result.email
                    Msmobileno.value = result.mobileno
                    Mszodiac.value = result.zodiac
                    Msbirthdate.value = result.birthdate

                    var html = '' +
                        '<tr >' +
                        '    <td data-label="Firstname" class="text-center">' +
                        '        ' + result[i].Firstname +
                        '    </td>' +
                        '     <td data-label="Lastname" class="text-center">' +
                        '        ' + result[i].Lasttname +
                        '    </td>'
                    '            <td data-label="Birthdate" class="text-center">' +
                        '        ' + result[i].Birthdate +
                        '    </td>' +
                        '         <td data-label="zodiac" class="text-center">' +
                        '        ' + result[i].zodiac +
                        '    </td>'
                    '         <td data-label="email" class="text-center">' +
                        '        ' + result[i].email +
                        '    </td>'
                    '         <td data-label="mobileno" class="text-center">' +
                        '        ' + result[i].mobileno +
                        '    </td>';

                    $("#curdopr").append(html);
                }
            });
});

