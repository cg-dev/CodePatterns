$('.datetime').datetimepicker({
    locale: 'en-gb',
    sideBySide: true,
    stepping: 15
});

$('.timeonly').datetimepicker({
    locale: 'en-gb',
    format: 'LT',
    enabledHours: [0, 1, 2, 3, 4],
    minDate: moment({ hour: 0, minute: 15 }),
    maxDate: moment({ hour: 4, minute: 0 }),
    stepping: 15
});